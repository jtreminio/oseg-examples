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
    public interface IAIConfigsBetaApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete AI config
        /// </summary>
        /// <remarks>
        /// Delete an existing AI config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteAIConfig(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0);

        /// <summary>
        /// Delete AI config
        /// </summary>
        /// <remarks>
        /// Delete an existing AI config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0);
        /// <summary>
        /// Delete AI config variation
        /// </summary>
        /// <remarks>
        /// Delete a specific variation of an AI config by config key and variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0);

        /// <summary>
        /// Delete AI config variation
        /// </summary>
        /// <remarks>
        /// Delete a specific variation of an AI config by config key and variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0);
        /// <summary>
        /// Delete an AI model config
        /// </summary>
        /// <remarks>
        /// Delete an AI model config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteModelConfig(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0);

        /// <summary>
        /// Delete an AI model config
        /// </summary>
        /// <remarks>
        /// Delete an AI model config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0);
        /// <summary>
        /// Get AI config
        /// </summary>
        /// <remarks>
        /// Retrieve a specific AI config by its key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        AIConfig GetAIConfig(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0);

        /// <summary>
        /// Get AI config
        /// </summary>
        /// <remarks>
        /// Retrieve a specific AI config by its key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        ApiResponse<AIConfig> GetAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0);
        /// <summary>
        /// Get AI config metrics
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Metrics</returns>
        Metrics GetAIConfigMetrics(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0);

        /// <summary>
        /// Get AI config metrics
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Metrics</returns>
        ApiResponse<Metrics> GetAIConfigMetricsWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0);
        /// <summary>
        /// Get AI config metrics by variation
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;MetricByVariation&gt;</returns>
        List<MetricByVariation> GetAIConfigMetricsByVariation(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0);

        /// <summary>
        /// Get AI config metrics by variation
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;MetricByVariation&gt;</returns>
        ApiResponse<List<MetricByVariation>> GetAIConfigMetricsByVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0);
        /// <summary>
        /// Get AI config variation
        /// </summary>
        /// <remarks>
        /// Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariationsResponse</returns>
        AIConfigVariationsResponse GetAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0);

        /// <summary>
        /// Get AI config variation
        /// </summary>
        /// <remarks>
        /// Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariationsResponse</returns>
        ApiResponse<AIConfigVariationsResponse> GetAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0);
        /// <summary>
        /// List AI configs
        /// </summary>
        /// <remarks>
        /// Get a list of all AI configs in the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigs</returns>
        AIConfigs GetAIConfigs(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0);

        /// <summary>
        /// List AI configs
        /// </summary>
        /// <remarks>
        /// Get a list of all AI configs in the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigs</returns>
        ApiResponse<AIConfigs> GetAIConfigsWithHttpInfo(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0);
        /// <summary>
        /// Get AI model config
        /// </summary>
        /// <remarks>
        /// Get an AI model config by key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ModelConfig</returns>
        ModelConfig GetModelConfig(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0);

        /// <summary>
        /// Get AI model config
        /// </summary>
        /// <remarks>
        /// Get an AI model config by key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ModelConfig</returns>
        ApiResponse<ModelConfig> GetModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0);
        /// <summary>
        /// List AI model configs
        /// </summary>
        /// <remarks>
        /// Get all AI model configs for a project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;ModelConfig&gt;</returns>
        List<ModelConfig> ListModelConfigs(string lDAPIVersion, string projectKey, int operationIndex = 0);

        /// <summary>
        /// List AI model configs
        /// </summary>
        /// <remarks>
        /// Get all AI model configs for a project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;ModelConfig&gt;</returns>
        ApiResponse<List<ModelConfig>> ListModelConfigsWithHttpInfo(string lDAPIVersion, string projectKey, int operationIndex = 0);
        /// <summary>
        /// Update AI config
        /// </summary>
        /// <remarks>
        /// Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        AIConfig PatchAIConfig(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0);

        /// <summary>
        /// Update AI config
        /// </summary>
        /// <remarks>
        /// Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        ApiResponse<AIConfig> PatchAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0);
        /// <summary>
        /// Update AI config variation
        /// </summary>
        /// <remarks>
        /// Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariation</returns>
        AIConfigVariation PatchAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0);

        /// <summary>
        /// Update AI config variation
        /// </summary>
        /// <remarks>
        /// Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariation</returns>
        ApiResponse<AIConfigVariation> PatchAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0);
        /// <summary>
        /// Create new AI config
        /// </summary>
        /// <remarks>
        /// Create a new AI config within the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        AIConfig PostAIConfig(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0);

        /// <summary>
        /// Create new AI config
        /// </summary>
        /// <remarks>
        /// Create a new AI config within the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        ApiResponse<AIConfig> PostAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0);
        /// <summary>
        /// Create AI config variation
        /// </summary>
        /// <remarks>
        /// Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariation</returns>
        AIConfigVariation PostAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0);

        /// <summary>
        /// Create AI config variation
        /// </summary>
        /// <remarks>
        /// Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariation</returns>
        ApiResponse<AIConfigVariation> PostAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0);
        /// <summary>
        /// Create an AI model config
        /// </summary>
        /// <remarks>
        /// Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ModelConfig</returns>
        ModelConfig PostModelConfig(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0);

        /// <summary>
        /// Create an AI model config
        /// </summary>
        /// <remarks>
        /// Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ModelConfig</returns>
        ApiResponse<ModelConfig> PostModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAIConfigsBetaApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete AI config
        /// </summary>
        /// <remarks>
        /// Delete an existing AI config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Delete AI config
        /// </summary>
        /// <remarks>
        /// Delete an existing AI config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Delete AI config variation
        /// </summary>
        /// <remarks>
        /// Delete a specific variation of an AI config by config key and variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Delete AI config variation
        /// </summary>
        /// <remarks>
        /// Delete a specific variation of an AI config by config key and variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Delete an AI model config
        /// </summary>
        /// <remarks>
        /// Delete an AI model config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteModelConfigAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Delete an AI model config
        /// </summary>
        /// <remarks>
        /// Delete an AI model config.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get AI config
        /// </summary>
        /// <remarks>
        /// Retrieve a specific AI config by its key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        System.Threading.Tasks.Task<AIConfig> GetAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get AI config
        /// </summary>
        /// <remarks>
        /// Retrieve a specific AI config by its key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfig>> GetAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get AI config metrics
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Metrics</returns>
        System.Threading.Tasks.Task<Metrics> GetAIConfigMetricsAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get AI config metrics
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Metrics)</returns>
        System.Threading.Tasks.Task<ApiResponse<Metrics>> GetAIConfigMetricsWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get AI config metrics by variation
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;MetricByVariation&gt;</returns>
        System.Threading.Tasks.Task<List<MetricByVariation>> GetAIConfigMetricsByVariationAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get AI config metrics by variation
        /// </summary>
        /// <remarks>
        /// Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;MetricByVariation&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<MetricByVariation>>> GetAIConfigMetricsByVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get AI config variation
        /// </summary>
        /// <remarks>
        /// Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariationsResponse</returns>
        System.Threading.Tasks.Task<AIConfigVariationsResponse> GetAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get AI config variation
        /// </summary>
        /// <remarks>
        /// Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariationsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfigVariationsResponse>> GetAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// List AI configs
        /// </summary>
        /// <remarks>
        /// Get a list of all AI configs in the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigs</returns>
        System.Threading.Tasks.Task<AIConfigs> GetAIConfigsAsync(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// List AI configs
        /// </summary>
        /// <remarks>
        /// Get a list of all AI configs in the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigs)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfigs>> GetAIConfigsWithHttpInfoAsync(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get AI model config
        /// </summary>
        /// <remarks>
        /// Get an AI model config by key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ModelConfig</returns>
        System.Threading.Tasks.Task<ModelConfig> GetModelConfigAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get AI model config
        /// </summary>
        /// <remarks>
        /// Get an AI model config by key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ModelConfig)</returns>
        System.Threading.Tasks.Task<ApiResponse<ModelConfig>> GetModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// List AI model configs
        /// </summary>
        /// <remarks>
        /// Get all AI model configs for a project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ModelConfig&gt;</returns>
        System.Threading.Tasks.Task<List<ModelConfig>> ListModelConfigsAsync(string lDAPIVersion, string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// List AI model configs
        /// </summary>
        /// <remarks>
        /// Get all AI model configs for a project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ModelConfig&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<ModelConfig>>> ListModelConfigsWithHttpInfoAsync(string lDAPIVersion, string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Update AI config
        /// </summary>
        /// <remarks>
        /// Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        System.Threading.Tasks.Task<AIConfig> PatchAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Update AI config
        /// </summary>
        /// <remarks>
        /// Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfig>> PatchAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Update AI config variation
        /// </summary>
        /// <remarks>
        /// Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariation</returns>
        System.Threading.Tasks.Task<AIConfigVariation> PatchAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Update AI config variation
        /// </summary>
        /// <remarks>
        /// Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariation)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfigVariation>> PatchAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create new AI config
        /// </summary>
        /// <remarks>
        /// Create a new AI config within the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        System.Threading.Tasks.Task<AIConfig> PostAIConfigAsync(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create new AI config
        /// </summary>
        /// <remarks>
        /// Create a new AI config within the given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfig>> PostAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create AI config variation
        /// </summary>
        /// <remarks>
        /// Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariation</returns>
        System.Threading.Tasks.Task<AIConfigVariation> PostAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create AI config variation
        /// </summary>
        /// <remarks>
        /// Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariation)</returns>
        System.Threading.Tasks.Task<ApiResponse<AIConfigVariation>> PostAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create an AI model config
        /// </summary>
        /// <remarks>
        /// Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ModelConfig</returns>
        System.Threading.Tasks.Task<ModelConfig> PostModelConfigAsync(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create an AI model config
        /// </summary>
        /// <remarks>
        /// Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ModelConfig)</returns>
        System.Threading.Tasks.Task<ApiResponse<ModelConfig>> PostModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAIConfigsBetaApi : IAIConfigsBetaApiSync, IAIConfigsBetaApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AIConfigsBetaApi : IAIConfigsBetaApi
    {
        private Org.LaunchDarklyTools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AIConfigsBetaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AIConfigsBetaApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AIConfigsBetaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AIConfigsBetaApi(string basePath)
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
        /// Initializes a new instance of the <see cref="AIConfigsBetaApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AIConfigsBetaApi(Org.LaunchDarklyTools.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="AIConfigsBetaApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public AIConfigsBetaApi(Org.LaunchDarklyTools.Client.ISynchronousClient client, Org.LaunchDarklyTools.Client.IAsynchronousClient asyncClient, Org.LaunchDarklyTools.Client.IReadableConfiguration configuration)
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
        /// Delete AI config Delete an existing AI config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteAIConfig(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0)
        {
            DeleteAIConfigWithHttpInfo(lDAPIVersion, projectKey, configKey);
        }

        /// <summary>
        /// Delete AI config Delete an existing AI config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Object> DeleteAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->DeleteAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete AI config Delete an existing AI config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await DeleteAIConfigWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete AI config Delete an existing AI config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Object>> DeleteAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->DeleteAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete AI config variation Delete a specific variation of an AI config by config key and variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0)
        {
            DeleteAIConfigVariationWithHttpInfo(lDAPIVersion, projectKey, configKey, variationKey);
        }

        /// <summary>
        /// Delete AI config variation Delete a specific variation of an AI config by config key and variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Object> DeleteAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete AI config variation Delete a specific variation of an AI config by config key and variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await DeleteAIConfigVariationWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, variationKey, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete AI config variation Delete a specific variation of an AI config by config key and variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Object>> DeleteAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->DeleteAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an AI model config Delete an AI model config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteModelConfig(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0)
        {
            DeleteModelConfigWithHttpInfo(lDAPIVersion, projectKey, modelConfigKey);
        }

        /// <summary>
        /// Delete an AI model config Delete an AI model config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Object> DeleteModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteModelConfig");
            }

            // verify the required parameter 'modelConfigKey' is set
            if (modelConfigKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigKey' when calling AIConfigsBetaApi->DeleteModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("modelConfigKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(modelConfigKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an AI model config Delete an AI model config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteModelConfigAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await DeleteModelConfigWithHttpInfoAsync(lDAPIVersion, projectKey, modelConfigKey, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an AI model config Delete an AI model config.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Object>> DeleteModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->DeleteModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->DeleteModelConfig");
            }

            // verify the required parameter 'modelConfigKey' is set
            if (modelConfigKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigKey' when calling AIConfigsBetaApi->DeleteModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("modelConfigKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(modelConfigKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.DeleteModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config Retrieve a specific AI config by its key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        public AIConfig GetAIConfig(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = GetAIConfigWithHttpInfo(lDAPIVersion, projectKey, configKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config Retrieve a specific AI config by its key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> GetAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<AIConfig>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config Retrieve a specific AI config by its key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        public async System.Threading.Tasks.Task<AIConfig> GetAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = await GetAIConfigWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config Retrieve a specific AI config by its key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfig>> GetAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<AIConfig>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config metrics Retrieve usage metrics for an AI config by config key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Metrics</returns>
        public Metrics GetAIConfigMetrics(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Metrics> localVarResponse = GetAIConfigMetricsWithHttpInfo(lDAPIVersion, projectKey, configKey, from, to, env);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config metrics Retrieve usage metrics for an AI config by config key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Metrics</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Metrics> GetAIConfigMetricsWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'env' is set
            if (env == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'env' when calling AIConfigsBetaApi->GetAIConfigMetrics");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "from", from));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "to", to));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "env", env));
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigMetrics";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Metrics>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigMetrics", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config metrics Retrieve usage metrics for an AI config by config key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Metrics</returns>
        public async System.Threading.Tasks.Task<Metrics> GetAIConfigMetricsAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Metrics> localVarResponse = await GetAIConfigMetricsWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, from, to, env, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config metrics Retrieve usage metrics for an AI config by config key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Metrics)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Metrics>> GetAIConfigMetricsWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigMetrics");
            }

            // verify the required parameter 'env' is set
            if (env == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'env' when calling AIConfigsBetaApi->GetAIConfigMetrics");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "from", from));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "to", to));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "env", env));
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigMetrics";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Metrics>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigMetrics", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config metrics by variation Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;MetricByVariation&gt;</returns>
        public List<MetricByVariation> GetAIConfigMetricsByVariation(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<List<MetricByVariation>> localVarResponse = GetAIConfigMetricsByVariationWithHttpInfo(lDAPIVersion, projectKey, configKey, from, to, env);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config metrics by variation Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;MetricByVariation&gt;</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<List<MetricByVariation>> GetAIConfigMetricsByVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'env' is set
            if (env == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'env' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "from", from));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "to", to));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "env", env));
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigMetricsByVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<MetricByVariation>>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics-by-variation", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigMetricsByVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config metrics by variation Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;MetricByVariation&gt;</returns>
        public async System.Threading.Tasks.Task<List<MetricByVariation>> GetAIConfigMetricsByVariationAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<List<MetricByVariation>> localVarResponse = await GetAIConfigMetricsByVariationWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, from, to, env, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config metrics by variation Retrieve usage metrics for an AI config by config key, with results split by variation.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="from">The starting time, as milliseconds since epoch (inclusive).</param>
        /// <param name="to">The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;.</param>
        /// <param name="env">An environment key. Only metrics from this environment will be included.</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;MetricByVariation&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<List<MetricByVariation>>> GetAIConfigMetricsByVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, int from, int to, string env, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
            }

            // verify the required parameter 'env' is set
            if (env == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'env' when calling AIConfigsBetaApi->GetAIConfigMetricsByVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "from", from));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "to", to));
            localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "env", env));
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigMetricsByVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<MetricByVariation>>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics-by-variation", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigMetricsByVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config variation Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariationsResponse</returns>
        public AIConfigVariationsResponse GetAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariationsResponse> localVarResponse = GetAIConfigVariationWithHttpInfo(lDAPIVersion, projectKey, configKey, variationKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config variation Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariationsResponse</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariationsResponse> GetAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<AIConfigVariationsResponse>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI config variation Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariationsResponse</returns>
        public async System.Threading.Tasks.Task<AIConfigVariationsResponse> GetAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariationsResponse> localVarResponse = await GetAIConfigVariationWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, variationKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI config variation Get an AI config variation by key. The response includes all variation versions for the given variation key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariationsResponse)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariationsResponse>> GetAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->GetAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<AIConfigVariationsResponse>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List AI configs Get a list of all AI configs in the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigs</returns>
        public AIConfigs GetAIConfigs(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigs> localVarResponse = GetAIConfigsWithHttpInfo(lDAPIVersion, projectKey, sort, limit, offset, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List AI configs Get a list of all AI configs in the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigs</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfigs> GetAIConfigsWithHttpInfo(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigs");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigs");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<AIConfigs>("/api/v2/projects/{projectKey}/ai-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List AI configs Get a list of all AI configs in the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigs</returns>
        public async System.Threading.Tasks.Task<AIConfigs> GetAIConfigsAsync(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigs> localVarResponse = await GetAIConfigsWithHttpInfoAsync(lDAPIVersion, projectKey, sort, limit, offset, filter, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List AI configs Get a list of all AI configs in the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="sort">A sort to apply to the list of AI configs. (optional)</param>
        /// <param name="limit">The number of AI configs to return. (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="filter">A filter to apply to the list of AI configs. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigs)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfigs>> GetAIConfigsWithHttpInfoAsync(string lDAPIVersion, string projectKey, string? sort = default(string?), int? limit = default(int?), int? offset = default(int?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetAIConfigs");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetAIConfigs");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetAIConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<AIConfigs>("/api/v2/projects/{projectKey}/ai-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAIConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI model config Get an AI model config by key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ModelConfig</returns>
        public ModelConfig GetModelConfig(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> localVarResponse = GetModelConfigWithHttpInfo(lDAPIVersion, projectKey, modelConfigKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI model config Get an AI model config by key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ModelConfig</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> GetModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetModelConfig");
            }

            // verify the required parameter 'modelConfigKey' is set
            if (modelConfigKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigKey' when calling AIConfigsBetaApi->GetModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("modelConfigKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(modelConfigKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ModelConfig>("/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get AI model config Get an AI model config by key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ModelConfig</returns>
        public async System.Threading.Tasks.Task<ModelConfig> GetModelConfigAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> localVarResponse = await GetModelConfigWithHttpInfoAsync(lDAPIVersion, projectKey, modelConfigKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get AI model config Get an AI model config by key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ModelConfig)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig>> GetModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string modelConfigKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->GetModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->GetModelConfig");
            }

            // verify the required parameter 'modelConfigKey' is set
            if (modelConfigKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigKey' when calling AIConfigsBetaApi->GetModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("modelConfigKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(modelConfigKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.GetModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ModelConfig>("/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List AI model configs Get all AI model configs for a project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;ModelConfig&gt;</returns>
        public List<ModelConfig> ListModelConfigs(string lDAPIVersion, string projectKey, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<List<ModelConfig>> localVarResponse = ListModelConfigsWithHttpInfo(lDAPIVersion, projectKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List AI model configs Get all AI model configs for a project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;ModelConfig&gt;</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<List<ModelConfig>> ListModelConfigsWithHttpInfo(string lDAPIVersion, string projectKey, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->ListModelConfigs");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->ListModelConfigs");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.ListModelConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<ModelConfig>>("/api/v2/projects/{projectKey}/ai-configs/model-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListModelConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List AI model configs Get all AI model configs for a project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;ModelConfig&gt;</returns>
        public async System.Threading.Tasks.Task<List<ModelConfig>> ListModelConfigsAsync(string lDAPIVersion, string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<List<ModelConfig>> localVarResponse = await ListModelConfigsWithHttpInfoAsync(lDAPIVersion, projectKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List AI model configs Get all AI model configs for a project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;ModelConfig&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<List<ModelConfig>>> ListModelConfigsWithHttpInfoAsync(string lDAPIVersion, string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->ListModelConfigs");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->ListModelConfigs");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter

            localVarRequestOptions.Operation = "AIConfigsBetaApi.ListModelConfigs";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<ModelConfig>>("/api/v2/projects/{projectKey}/ai-configs/model-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListModelConfigs", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update AI config Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        public AIConfig PatchAIConfig(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = PatchAIConfigWithHttpInfo(lDAPIVersion, projectKey, configKey, aIConfigPatch);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update AI config Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> PatchAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PatchAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PatchAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PatchAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigPatch;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PatchAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<AIConfig>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update AI config Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        public async System.Threading.Tasks.Task<AIConfig> PatchAIConfigAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = await PatchAIConfigWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, aIConfigPatch, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update AI config Edit an existing AI config.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example:   &#x60;&#x60;&#x60;     {       \&quot;description\&quot;: \&quot;Example updated description\&quot;,       \&quot;tags\&quot;: [\&quot;new-tag\&quot;]     }   &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigPatch">AI config object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfig>> PatchAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigPatch? aIConfigPatch = default(AIConfigPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PatchAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PatchAIConfig");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PatchAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigPatch;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PatchAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<AIConfig>("/api/v2/projects/{projectKey}/ai-configs/{configKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update AI config variation Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariation</returns>
        public AIConfigVariation PatchAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> localVarResponse = PatchAIConfigVariationWithHttpInfo(lDAPIVersion, projectKey, configKey, variationKey, aIConfigVariationPatch);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update AI config variation Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariation</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> PatchAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigVariationPatch;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PatchAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Patch<AIConfigVariation>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update AI config variation Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariation</returns>
        public async System.Threading.Tasks.Task<AIConfigVariation> PatchAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> localVarResponse = await PatchAIConfigVariationWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, variationKey, aIConfigVariationPatch, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update AI config variation Edit an existing variation of an AI config. This creates a new version of the variation.  The request body must be a JSON object of the fields to update. The values you include replace the existing values for the fields.  Here&#39;s an example: &#x60;&#x60;&#x60;   {     \&quot;messages\&quot;: [       {         \&quot;role\&quot;: \&quot;system\&quot;,         \&quot;content\&quot;: \&quot;The new message\&quot;       }     ]   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="variationKey"></param>
        /// <param name="aIConfigVariationPatch">AI config variation object to update (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariation)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation>> PatchAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, string variationKey, AIConfigVariationPatch? aIConfigVariationPatch = default(AIConfigVariationPatch?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
            }

            // verify the required parameter 'variationKey' is set
            if (variationKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'variationKey' when calling AIConfigsBetaApi->PatchAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("variationKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(variationKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigVariationPatch;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PatchAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PatchAsync<AIConfigVariation>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create new AI config Create a new AI config within the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfig</returns>
        public AIConfig PostAIConfig(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = PostAIConfigWithHttpInfo(lDAPIVersion, projectKey, aIConfigPost);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create new AI config Create a new AI config within the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfig</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> PostAIConfigWithHttpInfo(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostAIConfig");
            }

            // verify the required parameter 'aIConfigPost' is set
            if (aIConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'aIConfigPost' when calling AIConfigsBetaApi->PostAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<AIConfig>("/api/v2/projects/{projectKey}/ai-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create new AI config Create a new AI config within the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfig</returns>
        public async System.Threading.Tasks.Task<AIConfig> PostAIConfigAsync(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfig> localVarResponse = await PostAIConfigWithHttpInfoAsync(lDAPIVersion, projectKey, aIConfigPost, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create new AI config Create a new AI config within the given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="aIConfigPost">AI config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfig)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfig>> PostAIConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, AIConfigPost aIConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostAIConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostAIConfig");
            }

            // verify the required parameter 'aIConfigPost' is set
            if (aIConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'aIConfigPost' when calling AIConfigsBetaApi->PostAIConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostAIConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<AIConfig>("/api/v2/projects/{projectKey}/ai-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostAIConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create AI config variation Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AIConfigVariation</returns>
        public AIConfigVariation PostAIConfigVariation(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> localVarResponse = PostAIConfigVariationWithHttpInfo(lDAPIVersion, projectKey, configKey, aIConfigVariationPost);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create AI config variation Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AIConfigVariation</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> PostAIConfigVariationWithHttpInfo(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'aIConfigVariationPost' is set
            if (aIConfigVariationPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'aIConfigVariationPost' when calling AIConfigsBetaApi->PostAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigVariationPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<AIConfigVariation>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create AI config variation Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AIConfigVariation</returns>
        public async System.Threading.Tasks.Task<AIConfigVariation> PostAIConfigVariationAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation> localVarResponse = await PostAIConfigVariationWithHttpInfoAsync(lDAPIVersion, projectKey, configKey, aIConfigVariationPost, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create AI config variation Create a new variation for a given AI config.  The &lt;code&gt;model&lt;/code&gt; in the request body requires a &lt;code&gt;modelName&lt;/code&gt; and &lt;code&gt;parameters&lt;/code&gt;, for example:  &#x60;&#x60;&#x60;   \&quot;model\&quot;: {     \&quot;modelName\&quot;: \&quot;claude-3-opus-20240229\&quot;,     \&quot;parameters\&quot;: {       \&quot;max_tokens\&quot;: 1024     }   } &#x60;&#x60;&#x60; 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="configKey"></param>
        /// <param name="aIConfigVariationPost">AI config variation object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AIConfigVariation)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<AIConfigVariation>> PostAIConfigVariationWithHttpInfoAsync(string lDAPIVersion, string projectKey, string configKey, AIConfigVariationPost aIConfigVariationPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'configKey' is set
            if (configKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'configKey' when calling AIConfigsBetaApi->PostAIConfigVariation");
            }

            // verify the required parameter 'aIConfigVariationPost' is set
            if (aIConfigVariationPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'aIConfigVariationPost' when calling AIConfigsBetaApi->PostAIConfigVariation");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("configKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(configKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = aIConfigVariationPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostAIConfigVariation";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<AIConfigVariation>("/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostAIConfigVariation", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an AI model config Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ModelConfig</returns>
        public ModelConfig PostModelConfig(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> localVarResponse = PostModelConfigWithHttpInfo(lDAPIVersion, projectKey, modelConfigPost);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an AI model config Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ModelConfig</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> PostModelConfigWithHttpInfo(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0)
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostModelConfig");
            }

            // verify the required parameter 'modelConfigPost' is set
            if (modelConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigPost' when calling AIConfigsBetaApi->PostModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = modelConfigPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<ModelConfig>("/api/v2/projects/{projectKey}/ai-configs/model-configs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an AI model config Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ModelConfig</returns>
        public async System.Threading.Tasks.Task<ModelConfig> PostModelConfigAsync(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig> localVarResponse = await PostModelConfigWithHttpInfoAsync(lDAPIVersion, projectKey, modelConfigPost, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an AI model config Create an AI model config. You can use this in any variation for any AI config in your project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="lDAPIVersion">Version of the endpoint.</param>
        /// <param name="projectKey"></param>
        /// <param name="modelConfigPost">AI model config object to create</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ModelConfig)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ModelConfig>> PostModelConfigWithHttpInfoAsync(string lDAPIVersion, string projectKey, ModelConfigPost modelConfigPost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'lDAPIVersion' is set
            if (lDAPIVersion == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'lDAPIVersion' when calling AIConfigsBetaApi->PostModelConfig");
            }

            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling AIConfigsBetaApi->PostModelConfig");
            }

            // verify the required parameter 'modelConfigPost' is set
            if (modelConfigPost == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'modelConfigPost' when calling AIConfigsBetaApi->PostModelConfig");
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

            localVarRequestOptions.PathParameters.Add("projectKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(projectKey)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("LD-API-Version", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(lDAPIVersion)); // header parameter
            localVarRequestOptions.Data = modelConfigPost;

            localVarRequestOptions.Operation = "AIConfigsBetaApi.PostModelConfig";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ModelConfig>("/api/v2/projects/{projectKey}/ai-configs/model-configs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostModelConfig", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
