/*
 * LaunchDarkly REST API
 *
 * # Overview  ## Authentication  LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.  All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.  LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.  | Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          | | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | [Personal or service access tokens](https://docs.launchdarkly.com/home/account/api) | Can be customized on a per-token basis                                                                | Building scripts, custom integrations, data export. | | SDK keys                                                                                        | Can only access read-only resources specific to server-side SDKs. Restricted to a single environment. | Server-side SDKs                     | | Mobile keys                                                                                     | Can only access read-only resources specific to mobile SDKs, and only for flags marked available to mobile keys. Restricted to a single environment.           | Mobile SDKs                                        | | Client-side ID                                                                                  | Can only access read-only resources specific to JavaScript-based client-side SDKs, and only for flags marked available to client-side. Restricted to a single environment.           | Client-side JavaScript                             |  > #### Keep your access tokens and SDK keys private > > Access tokens should _never_ be exposed in untrusted contexts. Never put an access token in client-side JavaScript, or embed it in a mobile application. LaunchDarkly has special mobile keys that you can embed in mobile apps. If you accidentally expose an access token or SDK key, you can reset it from your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page. > > The client-side ID is safe to embed in untrusted contexts. It's designed for use in client-side JavaScript.  ### Authentication using request header  The preferred way to authenticate with the API is by adding an `Authorization` header containing your access token to your requests. The value of the `Authorization` header must be your access token.  Manage personal access tokens from the [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.  ### Authentication using session cookie  For testing purposes, you can make API calls directly from your web browser. If you are logged in to the LaunchDarkly application, the API will use your existing session to authenticate calls.  If you have a [role](https://docs.launchdarkly.com/home/account/built-in-roles) other than Admin, or have a [custom role](https://docs.launchdarkly.com/home/account/custom-roles) defined, you may not have permission to perform some API calls. You will receive a `401` response code in that case.  > ### Modifying the Origin header causes an error > > LaunchDarkly validates that the Origin header for any API request authenticated by a session cookie matches the expected Origin header. The expected Origin header is `https://app.launchdarkly.com`. > > If the Origin header does not match what's expected, LaunchDarkly returns an error. This error can prevent the LaunchDarkly app from working correctly. > > Any browser extension that intentionally changes the Origin header can cause this problem. For example, the `Allow-Control-Allow-Origin: *` Chrome extension changes the Origin header to `http://evil.com` and causes the app to fail. > > To prevent this error, do not modify your Origin header. > > LaunchDarkly does not require origin matching when authenticating with an access token, so this issue does not affect normal API usage.  ## Representations  All resources expect and return JSON response bodies. Error responses also send a JSON body. To learn more about the error format of the API, read [Errors](/#section/Overview/Errors).  In practice this means that you always get a response with a `Content-Type` header set to `application/json`.  In addition, request bodies for `PATCH`, `POST`, and `PUT` requests must be encoded as JSON with a `Content-Type` header set to `application/json`.  ### Summary and detailed representations  When you fetch a list of resources, the response includes only the most important attributes of each resource. This is a _summary representation_ of the resource. When you fetch an individual resource, such as a single feature flag, you receive a _detailed representation_ of the resource.  The best way to find a detailed representation is to follow links. Every summary representation includes a link to its detailed representation.  ### Expanding responses  Sometimes the detailed representation of a resource does not include all of the attributes of the resource by default. If this is the case, the request method will clearly document this and describe which attributes you can include in an expanded response.  To include the additional attributes, append the `expand` request parameter to your request and add a comma-separated list of the attributes to include. For example, when you append `?expand=members,maintainers` to the [Get team](/tag/Teams#operation/getTeam) endpoint, the expanded response includes both of these attributes.  ### Links and addressability  The best way to navigate the API is by following links. These are attributes in representations that link to other resources. The API always uses the same format for links:  - Links to other resources within the API are encapsulated in a `_links` object - If the resource has a corresponding link to HTML content on the site, it is stored in a special `_site` link  Each link has two attributes:  - An `href`, which contains the URL - A `type`, which describes the content type  For example, a feature resource might return the following:  ```json {   \"_links\": {     \"parent\": {       \"href\": \"/api/features\",       \"type\": \"application/json\"     },     \"self\": {       \"href\": \"/api/features/sort.order\",       \"type\": \"application/json\"     }   },   \"_site\": {     \"href\": \"/features/sort.order\",     \"type\": \"text/html\"   } } ```  From this, you can navigate to the parent collection of features by following the `parent` link, or navigate to the site page for the feature by following the `_site` link.  Collections are always represented as a JSON object with an `items` attribute containing an array of representations. Like all other representations, collections have `_links` defined at the top level.  Paginated collections include `first`, `last`, `next`, and `prev` links containing a URL with the respective set of elements in the collection.  ## Updates  Resources that accept partial updates use the `PATCH` verb. Most resources support the [JSON patch](/reference#updates-using-json-patch) format. Some resources also support the [JSON merge patch](/reference#updates-using-json-merge-patch) format, and some resources support the [semantic patch](/reference#updates-using-semantic-patch) format, which is a way to specify the modifications to perform as a set of executable instructions. Each resource supports optional [comments](/reference#updates-with-comments) that you can submit with updates. Comments appear in outgoing webhooks, the audit log, and other integrations.  When a resource supports both JSON patch and semantic patch, we document both in the request method. However, the specific request body fields and descriptions included in our documentation only match one type of patch or the other.  ### Updates using JSON patch  [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) is a way to specify the modifications to perform on a resource. JSON patch uses paths and a limited set of operations to describe how to transform the current state of the resource into a new state. JSON patch documents are always arrays, where each element contains an operation, a path to the field to update, and the new value.  For example, in this feature flag representation:  ```json {     \"name\": \"New recommendations engine\",     \"key\": \"engine.enable\",     \"description\": \"This is the description\",     ... } ``` You can change the feature flag's description with the following patch document:  ```json [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"This is the new description\" }] ```  You can specify multiple modifications to perform in a single request. You can also test that certain preconditions are met before applying the patch:  ```json [   { \"op\": \"test\", \"path\": \"/version\", \"value\": 10 },   { \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" } ] ```  The above patch request tests whether the feature flag's `version` is `10`, and if so, changes the feature flag's description.  Attributes that are not editable, such as a resource's `_links`, have names that start with an underscore.  ### Updates using JSON merge patch  [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) is another format for specifying the modifications to perform on a resource. JSON merge patch is less expressive than JSON patch. However, in many cases it is simpler to construct a merge patch document. For example, you can change a feature flag's description with the following merge patch document:  ```json {   \"description\": \"New flag description\" } ```  ### Updates using semantic patch  Some resources support the semantic patch format. A semantic patch is a way to specify the modifications to perform on a resource as a set of executable instructions.  Semantic patch allows you to be explicit about intent using precise, custom instructions. In many cases, you can define semantic patch instructions independently of the current state of the resource. This can be useful when defining a change that may be applied at a future date.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header.  Here's how:  ``` Content-Type: application/json; domain-model=launchdarkly.semanticpatch ```  If you call a semantic patch resource without this header, you will receive a `400` response because your semantic patch will be interpreted as a JSON patch.  The body of a semantic patch request takes the following properties:  * `comment` (string): (Optional) A description of the update. * `environmentKey` (string): (Required for some resources only) The environment key. * `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the instruction requires parameters, you must include those parameters as additional fields in the object. The documentation for each resource that supports semantic patch includes the available instructions and any additional parameters.  For example:  ```json {   \"comment\": \"optional comment\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  Semantic patches are not applied partially; either all of the instructions are applied or none of them are. If **any** instruction is invalid, the endpoint returns an error and will not change the resource. If all instructions are valid, the request succeeds and the resources are updated if necessary, or left unchanged if they are already in the state you request.  ### Updates with comments  You can submit optional comments with `PATCH` changes.  To submit a comment along with a JSON patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"patch\": [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }] } ```  To submit a comment along with a JSON merge patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"merge\": { \"description\": \"New flag description\" } } ```  To submit a comment along with a semantic patch, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  ## Errors  The API always returns errors in a common format. Here's an example:  ```json {   \"code\": \"invalid_request\",   \"message\": \"A feature with that key already exists\",   \"id\": \"30ce6058-87da-11e4-b116-123b93f75cba\" } ```  The `code` indicates the general class of error. The `message` is a human-readable explanation of what went wrong. The `id` is a unique identifier. Use it when you're working with LaunchDarkly Support to debug a problem with a specific API call.  ### HTTP status error response codes  | Code | Definition        | Description                                                                                       | Possible Solution                                                | | - -- - | - -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | 400  | Invalid request       | The request cannot be understood.                                    | Ensure JSON syntax in request body is correct.                   | | 401  | Invalid access token      | Requestor is unauthorized or does not have permission for this API call.                                                | Ensure your API access token is valid and has the appropriate permissions.                                     | | 403  | Forbidden         | Requestor does not have access to this resource.                                                | Ensure that the account member or access token has proper permissions set. | | 404  | Invalid resource identifier | The requested resource is not valid. | Ensure that the resource is correctly identified by ID or key. | | 405  | Method not allowed | The request method is not allowed on this resource. | Ensure that the HTTP verb is correct. | | 409  | Conflict          | The API request can not be completed because it conflicts with a concurrent API request. | Retry your request.                                              | | 422  | Unprocessable entity | The API request can not be completed because the update description can not be understood. | Ensure that the request body is correct for the type of patch you are using, either JSON patch or semantic patch. | 429  | Too many requests | Read [Rate limiting](/#section/Overview/Rate-limiting).                                               | Wait and try again later.                                        |  ## CORS  The LaunchDarkly API supports Cross Origin Resource Sharing (CORS) for AJAX requests from any origin. If an `Origin` header is given in a request, it will be echoed as an explicitly allowed origin. Otherwise the request returns a wildcard, `Access-Control-Allow-Origin: *`. For more information on CORS, read the [CORS W3C Recommendation](http://www.w3.org/TR/cors). Example CORS headers might look like:  ```http Access-Control-Allow-Headers: Accept, Content-Type, Content-Length, Accept-Encoding, Authorization Access-Control-Allow-Methods: OPTIONS, GET, DELETE, PATCH Access-Control-Allow-Origin: * Access-Control-Max-Age: 300 ```  You can make authenticated CORS calls just as you would make same-origin calls, using either [token or session-based authentication](/#section/Overview/Authentication). If you are using session authentication, you should set the `withCredentials` property for your `xhr` request to `true`. You should never expose your access tokens to untrusted entities.  ## Rate limiting  We use several rate limiting strategies to ensure the availability of our APIs. Rate-limited calls to our APIs return a `429` status code. Calls to our APIs include headers indicating the current rate limit status. The specific headers returned depend on the API route being called. The limits differ based on the route, authentication mechanism, and other factors. Routes that are not rate limited may not contain any of the headers described below.  > ### Rate limiting and SDKs > > LaunchDarkly SDKs are never rate limited and do not use the API endpoints defined here. LaunchDarkly uses a different set of approaches, including streaming/server-sent events and a global CDN, to ensure availability to the routes used by LaunchDarkly SDKs.  ### Global rate limits  Authenticated requests are subject to a global limit. This is the maximum number of calls that your account can make to the API per ten seconds. All service and personal access tokens on the account share this limit, so exceeding the limit with one access token will impact other tokens. Calls that are subject to global rate limits may return the headers below:  | Header name                    | Description                                                                      | | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | | `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |  We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.  ### Route-level rate limits  Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:  | Header name                   | Description                                                                                           | | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | | `X-Ratelimit-Route-Remaining` | The maximum number of requests to the current route the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`           | The time at which the current rate limit window resets in epoch milliseconds.                         |  A _route_ represents a specific URL pattern and verb. For example, the [Delete environment](/tag/Environments#operation/deleteEnvironment) endpoint is considered a single route, and each call to delete an environment counts against your route-level rate limit for that route.  We do not publicly document the specific number of calls that an account can make to each endpoint per ten seconds. These limits may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limits.  ### IP-based rate limiting  We also employ IP-based rate limiting on some API routes. If you hit an IP-based rate limit, your API response will include a `Retry-After` header indicating how long to wait before re-trying the call. Clients must wait at least `Retry-After` seconds before making additional calls to our API, and should employ jitter and backoff strategies to avoid triggering rate limits again.  ## OpenAPI (Swagger) and client libraries  We have a [complete OpenAPI (Swagger) specification](https://app.launchdarkly.com/api/v2/openapi.json) for our API.  We auto-generate multiple client libraries based on our OpenAPI specification. To learn more, visit the [collection of client libraries on GitHub](https://github.com/search?q=topic%3Alaunchdarkly-api+org%3Alaunchdarkly&type=Repositories). You can also use this specification to generate client libraries to interact with our REST API in your language of choice.  Our OpenAPI specification is supported by several API-based tools such as Postman and Insomnia. In many cases, you can directly import our specification to explore our APIs.  ## Method overriding  Some firewalls and HTTP clients restrict the use of verbs other than `GET` and `POST`. In those environments, our API endpoints that use `DELETE`, `PATCH`, and `PUT` verbs are inaccessible.  To avoid this issue, our API supports the `X-HTTP-Method-Override` header, allowing clients to \"tunnel\" `DELETE`, `PATCH`, and `PUT` requests using a `POST` request.  For example, to call a `PATCH` endpoint using a `POST` request, you can include `X-HTTP-Method-Override:PATCH` as a header.  ## Beta resources  We sometimes release new API resources in **beta** status before we release them with general availability.  Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  We try to promote resources into general availability as quickly as possible. This happens after sufficient testing and when we're satisfied that we no longer need to make backwards-incompatible changes.  We mark beta resources with a \"Beta\" callout in our documentation, pictured below:  > ### This feature is in beta > > To use this feature, pass in a header including the `LD-API-Version` key with value set to `beta`. Use this header with each call. To learn more, read [Beta resources](/#section/Overview/Beta-resources). > > Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  ### Using beta resources  To use a beta resource, you must include a header in the request. If you call a beta resource without this header, you receive a `403` response.  Use this header:  ``` LD-API-Version: beta ```  ## Federal environments  The version of LaunchDarkly that is available on domains controlled by the United States government is different from the version of LaunchDarkly available to the general public. If you are an employee or contractor for a United States federal agency and use LaunchDarkly in your work, you likely use the federal instance of LaunchDarkly.  If you are working in the federal instance of LaunchDarkly, the base URI for each request is `https://app.launchdarkly.us`. In the \"Try it\" sandbox for each request, click the request path to view the complete resource path for the federal environment.  To learn more, read [LaunchDarkly in federal environments](https://docs.launchdarkly.com/home/infrastructure/federal).  ## Versioning  We try hard to keep our REST API backwards compatible, but we occasionally have to make backwards-incompatible changes in the process of shipping new features. These breaking changes can cause unexpected behavior if you don't prepare for them accordingly.  Updates to our REST API include support for the latest features in LaunchDarkly. We also release a new version of our REST API every time we make a breaking change. We provide simultaneous support for multiple API versions so you can migrate from your current API version to a new version at your own pace.  ### Setting the API version per request  You can set the API version on a specific request by sending an `LD-API-Version` header, as shown in the example below:  ``` LD-API-Version: 20240415 ```  The header value is the version number of the API version you would like to request. The number for each version corresponds to the date the version was released in `yyyymmdd` format. In the example above the version `20240415` corresponds to April 15, 2024.  ### Setting the API version per access token  When you create an access token, you must specify a specific version of the API to use. This ensures that integrations using this token cannot be broken by version changes.  Tokens created before versioning was released have their version set to `20160426`, which is the version of the API that existed before the current versioning scheme, so that they continue working the same way they did before versioning.  If you would like to upgrade your integration to use a new API version, you can explicitly set the header described above.  > ### Best practice: Set the header for every client or integration > > We recommend that you set the API version header explicitly in any client or integration you build. > > Only rely on the access token API version during manual testing.  ### API version changelog  |<div style=\"width:75px\">Version</div> | Changes | End of life (EOL) |- --|- --|- --| | `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current | | `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 | | `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 | | `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 | | `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |  To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/). 
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@launchdarkly.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace Org.LaunchDarklyTools.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRelayProxyConfigurationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Relay Proxy config by ID
        /// </summary>
        /// <remarks>
        /// Delete a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteRelayAutoConfig(string id, int operationIndex = 0);

        /// <summary>
        /// Delete Relay Proxy config by ID
        /// </summary>
        /// <remarks>
        /// Delete a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteRelayAutoConfigWithHttpInfo(string id, int operationIndex = 0);
        /// <summary>
        /// Get Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Get a single Relay Proxy auto config by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        RelayAutoConfigRep GetRelayProxyConfig(string id, int operationIndex = 0);

        /// <summary>
        /// Get Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Get a single Relay Proxy auto config by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        ApiResponse<RelayAutoConfigRep> GetRelayProxyConfigWithHttpInfo(string id, int operationIndex = 0);
        /// <summary>
        /// List Relay Proxy configs
        /// </summary>
        /// <remarks>
        /// Get a list of Relay Proxy configurations in the account.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigCollectionRep</returns>
        RelayAutoConfigCollectionRep GetRelayProxyConfigs(int operationIndex = 0);

        /// <summary>
        /// List Relay Proxy configs
        /// </summary>
        /// <remarks>
        /// Get a list of Relay Proxy configurations in the account.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigCollectionRep</returns>
        ApiResponse<RelayAutoConfigCollectionRep> GetRelayProxyConfigsWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Update a Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        RelayAutoConfigRep PatchRelayAutoConfig(string id, PatchWithComment patchWithComment, int operationIndex = 0);

        /// <summary>
        /// Update a Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        ApiResponse<RelayAutoConfigRep> PatchRelayAutoConfigWithHttpInfo(string id, PatchWithComment patchWithComment, int operationIndex = 0);
        /// <summary>
        /// Create a new Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Create a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        RelayAutoConfigRep PostRelayAutoConfig(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0);

        /// <summary>
        /// Create a new Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Create a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        ApiResponse<RelayAutoConfigRep> PostRelayAutoConfigWithHttpInfo(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0);
        /// <summary>
        /// Reset Relay Proxy configuration key
        /// </summary>
        /// <remarks>
        /// Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        RelayAutoConfigRep ResetRelayAutoConfig(string id, long? expiry = default(long?), int operationIndex = 0);

        /// <summary>
        /// Reset Relay Proxy configuration key
        /// </summary>
        /// <remarks>
        /// Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        ApiResponse<RelayAutoConfigRep> ResetRelayAutoConfigWithHttpInfo(string id, long? expiry = default(long?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRelayProxyConfigurationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Relay Proxy config by ID
        /// </summary>
        /// <remarks>
        /// Delete a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteRelayAutoConfigAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Delete Relay Proxy config by ID
        /// </summary>
        /// <remarks>
        /// Delete a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteRelayAutoConfigWithHttpInfoAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Get a single Relay Proxy auto config by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        System.Threading.Tasks.Task<RelayAutoConfigRep> GetRelayProxyConfigAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Get a single Relay Proxy auto config by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<RelayAutoConfigRep>> GetRelayProxyConfigWithHttpInfoAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// List Relay Proxy configs
        /// </summary>
        /// <remarks>
        /// Get a list of Relay Proxy configurations in the account.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigCollectionRep</returns>
        System.Threading.Tasks.Task<RelayAutoConfigCollectionRep> GetRelayProxyConfigsAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// List Relay Proxy configs
        /// </summary>
        /// <remarks>
        /// Get a list of Relay Proxy configurations in the account.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigCollectionRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<RelayAutoConfigCollectionRep>> GetRelayProxyConfigsWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Update a Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        System.Threading.Tasks.Task<RelayAutoConfigRep> PatchRelayAutoConfigAsync(string id, PatchWithComment patchWithComment, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Update a Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<RelayAutoConfigRep>> PatchRelayAutoConfigWithHttpInfoAsync(string id, PatchWithComment patchWithComment, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create a new Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Create a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        System.Threading.Tasks.Task<RelayAutoConfigRep> PostRelayAutoConfigAsync(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create a new Relay Proxy config
        /// </summary>
        /// <remarks>
        /// Create a Relay Proxy config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<RelayAutoConfigRep>> PostRelayAutoConfigWithHttpInfoAsync(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Reset Relay Proxy configuration key
        /// </summary>
        /// <remarks>
        /// Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        System.Threading.Tasks.Task<RelayAutoConfigRep> ResetRelayAutoConfigAsync(string id, long? expiry = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Reset Relay Proxy configuration key
        /// </summary>
        /// <remarks>
        /// Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<RelayAutoConfigRep>> ResetRelayAutoConfigWithHttpInfoAsync(string id, long? expiry = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRelayProxyConfigurationsApi : IRelayProxyConfigurationsApiSync, IRelayProxyConfigurationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class RelayProxyConfigurationsApi : IRelayProxyConfigurationsApi
    {
        private Org.LaunchDarklyTools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayProxyConfigurationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RelayProxyConfigurationsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayProxyConfigurationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RelayProxyConfigurationsApi(string basePath)
        {
            this.Configuration = Org.LaunchDarklyTools.Client.Configuration.MergeConfigurations(
                Org.LaunchDarklyTools.Client.GlobalConfiguration.Instance,
                new Org.LaunchDarklyTools.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Org.LaunchDarklyTools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.LaunchDarklyTools.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Org.LaunchDarklyTools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayProxyConfigurationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public RelayProxyConfigurationsApi(Org.LaunchDarklyTools.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Org.LaunchDarklyTools.Client.Configuration.MergeConfigurations(
                Org.LaunchDarklyTools.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Org.LaunchDarklyTools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.LaunchDarklyTools.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Org.LaunchDarklyTools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayProxyConfigurationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public RelayProxyConfigurationsApi(Org.LaunchDarklyTools.Client.ISynchronousClient client, Org.LaunchDarklyTools.Client.IAsynchronousClient asyncClient, Org.LaunchDarklyTools.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Org.LaunchDarklyTools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Org.LaunchDarklyTools.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Org.LaunchDarklyTools.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Org.LaunchDarklyTools.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Org.LaunchDarklyTools.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Delete Relay Proxy config by ID Delete a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteRelayAutoConfig(string id, int operationIndex = 0)
        {
            DeleteRelayAutoConfigWithHttpInfo(id);
        }

        /// <summary>
        /// Delete Relay Proxy config by ID Delete a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Object> DeleteRelayAutoConfigWithHttpInfo(string id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->DeleteRelayAutoConfig");
            }

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.DeleteRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Relay Proxy config by ID Delete a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteRelayAutoConfigAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await DeleteRelayAutoConfigWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Relay Proxy config by ID Delete a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Object>> DeleteRelayAutoConfigWithHttpInfoAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->DeleteRelayAutoConfig");
            }


            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.DeleteRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Relay Proxy config Get a single Relay Proxy auto config by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        public RelayAutoConfigRep GetRelayProxyConfig(string id, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = GetRelayProxyConfigWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Relay Proxy config Get a single Relay Proxy auto config by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> GetRelayProxyConfigWithHttpInfo(string id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->GetRelayProxyConfig");
            }

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.GetRelayProxyConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRelayProxyConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Relay Proxy config Get a single Relay Proxy auto config by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        public async System.Threading.Tasks.Task<RelayAutoConfigRep> GetRelayProxyConfigAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = await GetRelayProxyConfigWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Relay Proxy config Get a single Relay Proxy auto config by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep>> GetRelayProxyConfigWithHttpInfoAsync(string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->GetRelayProxyConfig");
            }


            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.GetRelayProxyConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRelayProxyConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Relay Proxy configs Get a list of Relay Proxy configurations in the account.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigCollectionRep</returns>
        public RelayAutoConfigCollectionRep GetRelayProxyConfigs(int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigCollectionRep> localVarResponse = GetRelayProxyConfigsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Relay Proxy configs Get a list of Relay Proxy configurations in the account.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigCollectionRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigCollectionRep> GetRelayProxyConfigsWithHttpInfo(int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.GetRelayProxyConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<RelayAutoConfigCollectionRep>("/api/v2/account/relay-auto-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRelayProxyConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Relay Proxy configs Get a list of Relay Proxy configurations in the account.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigCollectionRep</returns>
        public async System.Threading.Tasks.Task<RelayAutoConfigCollectionRep> GetRelayProxyConfigsAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigCollectionRep> localVarResponse = await GetRelayProxyConfigsWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Relay Proxy configs Get a list of Relay Proxy configurations in the account.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigCollectionRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigCollectionRep>> GetRelayProxyConfigsWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.GetRelayProxyConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<RelayAutoConfigCollectionRep>("/api/v2/account/relay-auto-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetRelayProxyConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a Relay Proxy config Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        public RelayAutoConfigRep PatchRelayAutoConfig(string id, PatchWithComment patchWithComment, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = PatchRelayAutoConfigWithHttpInfo(id, patchWithComment);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a Relay Proxy config Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> PatchRelayAutoConfigWithHttpInfo(string id, PatchWithComment patchWithComment, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->PatchRelayAutoConfig");
            }

            // verify the required parameter 'patchWithComment' is set
            if (patchWithComment == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'patchWithComment' when calling RelayProxyConfigurationsApi->PatchRelayAutoConfig");
            }

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = patchWithComment;

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.PatchRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a Relay Proxy config Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        public async System.Threading.Tasks.Task<RelayAutoConfigRep> PatchRelayAutoConfigAsync(string id, PatchWithComment patchWithComment, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = await PatchRelayAutoConfigWithHttpInfoAsync(id, patchWithComment, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a Relay Proxy config Update a Relay Proxy configuration. Updating a configuration uses a [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes. To learn more, read [Updates](/#section/Overview/Updates).
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The relay auto config id</param>
        /// <param name="patchWithComment"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep>> PatchRelayAutoConfigWithHttpInfoAsync(string id, PatchWithComment patchWithComment, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->PatchRelayAutoConfig");
            }

            // verify the required parameter 'patchWithComment' is set
            if (patchWithComment == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'patchWithComment' when calling RelayProxyConfigurationsApi->PatchRelayAutoConfig");
            }


            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = patchWithComment;

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.PatchRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new Relay Proxy config Create a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        public RelayAutoConfigRep PostRelayAutoConfig(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = PostRelayAutoConfigWithHttpInfo(relayAutoConfigPost);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new Relay Proxy config Create a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> PostRelayAutoConfigWithHttpInfo(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0)
        {
            // verify the required parameter 'relayAutoConfigPost' is set
            if (relayAutoConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'relayAutoConfigPost' when calling RelayProxyConfigurationsApi->PostRelayAutoConfig");
            }

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = relayAutoConfigPost;

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.PostRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new Relay Proxy config Create a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        public async System.Threading.Tasks.Task<RelayAutoConfigRep> PostRelayAutoConfigAsync(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = await PostRelayAutoConfigWithHttpInfoAsync(relayAutoConfigPost, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new Relay Proxy config Create a Relay Proxy config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="relayAutoConfigPost"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep>> PostRelayAutoConfigWithHttpInfoAsync(RelayAutoConfigPost relayAutoConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'relayAutoConfigPost' is set
            if (relayAutoConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'relayAutoConfigPost' when calling RelayProxyConfigurationsApi->PostRelayAutoConfig");
            }


            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = relayAutoConfigPost;

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.PostRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reset Relay Proxy configuration key Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>RelayAutoConfigRep</returns>
        public RelayAutoConfigRep ResetRelayAutoConfig(string id, long? expiry = default(long?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = ResetRelayAutoConfigWithHttpInfo(id, expiry);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Reset Relay Proxy configuration key Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of RelayAutoConfigRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> ResetRelayAutoConfigWithHttpInfo(string id, long? expiry = default(long?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->ResetRelayAutoConfig");
            }

            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            var localVarMultipartFormData = localVarContentType == "multipart/form-data";
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (expiry != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "expiry", expiry));
            }

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.ResetRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}/reset", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ResetRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reset Relay Proxy configuration key Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RelayAutoConfigRep</returns>
        public async System.Threading.Tasks.Task<RelayAutoConfigRep> ResetRelayAutoConfigAsync(string id, long? expiry = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep> localVarResponse = await ResetRelayAutoConfigWithHttpInfoAsync(id, expiry, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Reset Relay Proxy configuration key Reset a Relay Proxy configuration&#39;s secret key with an optional expiry time for the old key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The Relay Proxy configuration ID</param>
        /// <param name="expiry">An expiration time for the old Relay Proxy configuration key, expressed as a Unix epoch time in milliseconds. By default, the Relay Proxy configuration will expire immediately. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RelayAutoConfigRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<RelayAutoConfigRep>> ResetRelayAutoConfigWithHttpInfoAsync(string id, long? expiry = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling RelayProxyConfigurationsApi->ResetRelayAutoConfig");
            }


            Org.LaunchDarklyTools.Client.RequestOptions localVarRequestOptions = new Org.LaunchDarklyTools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.LaunchDarklyTools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (expiry != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "expiry", expiry));
            }

            localVarRequestOptions.Operation = "RelayProxyConfigurationsApi.ResetRelayAutoConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<RelayAutoConfigRep>("/api/v2/account/relay-auto-configs/{id}/reset", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ResetRelayAutoConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
