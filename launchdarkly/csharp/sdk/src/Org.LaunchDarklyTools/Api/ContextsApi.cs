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
    public interface IContextsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete context instances
        /// </summary>
        /// <remarks>
        /// Delete context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteContextInstances(string projectKey, string environmentKey, string id, int operationIndex = 0);

        /// <summary>
        /// Delete context instances
        /// </summary>
        /// <remarks>
        /// Delete context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteContextInstancesWithHttpInfo(string projectKey, string environmentKey, string id, int operationIndex = 0);
        /// <summary>
        /// Evaluate flags for context instance
        /// </summary>
        /// <remarks>
        /// Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstanceEvaluations</returns>
        ContextInstanceEvaluations EvaluateContextInstance(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0);

        /// <summary>
        /// Evaluate flags for context instance
        /// </summary>
        /// <remarks>
        /// Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstanceEvaluations</returns>
        ApiResponse<ContextInstanceEvaluations> EvaluateContextInstanceWithHttpInfo(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0);
        /// <summary>
        /// Get context attribute names
        /// </summary>
        /// <remarks>
        /// Get context attribute names.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextAttributeNamesCollection</returns>
        ContextAttributeNamesCollection GetContextAttributeNames(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0);

        /// <summary>
        /// Get context attribute names
        /// </summary>
        /// <remarks>
        /// Get context attribute names.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextAttributeNamesCollection</returns>
        ApiResponse<ContextAttributeNamesCollection> GetContextAttributeNamesWithHttpInfo(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0);
        /// <summary>
        /// Get context attribute values
        /// </summary>
        /// <remarks>
        /// Get context attribute values.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextAttributeValuesCollection</returns>
        ContextAttributeValuesCollection GetContextAttributeValues(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0);

        /// <summary>
        /// Get context attribute values
        /// </summary>
        /// <remarks>
        /// Get context attribute values.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextAttributeValuesCollection</returns>
        ApiResponse<ContextAttributeValuesCollection> GetContextAttributeValuesWithHttpInfo(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0);
        /// <summary>
        /// Get context instances
        /// </summary>
        /// <remarks>
        /// Get context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstances</returns>
        ContextInstances GetContextInstances(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Get context instances
        /// </summary>
        /// <remarks>
        /// Get context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstances</returns>
        ApiResponse<ContextInstances> GetContextInstancesWithHttpInfo(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Get context kinds
        /// </summary>
        /// <remarks>
        /// Get all context kinds for a given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextKindsCollectionRep</returns>
        ContextKindsCollectionRep GetContextKindsByProjectKey(string projectKey, int operationIndex = 0);

        /// <summary>
        /// Get context kinds
        /// </summary>
        /// <remarks>
        /// Get all context kinds for a given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextKindsCollectionRep</returns>
        ApiResponse<ContextKindsCollectionRep> GetContextKindsByProjectKeyWithHttpInfo(string projectKey, int operationIndex = 0);
        /// <summary>
        /// Get contexts
        /// </summary>
        /// <remarks>
        /// Get contexts based on kind and key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Contexts</returns>
        Contexts GetContexts(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Get contexts
        /// </summary>
        /// <remarks>
        /// Get contexts based on kind and key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Contexts</returns>
        ApiResponse<Contexts> GetContextsWithHttpInfo(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Create or update context kind
        /// </summary>
        /// <remarks>
        /// Create or update a context kind by key. Only the included fields will be updated.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UpsertResponseRep</returns>
        UpsertResponseRep PutContextKind(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0);

        /// <summary>
        /// Create or update context kind
        /// </summary>
        /// <remarks>
        /// Create or update a context kind by key. Only the included fields will be updated.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UpsertResponseRep</returns>
        ApiResponse<UpsertResponseRep> PutContextKindWithHttpInfo(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0);
        /// <summary>
        /// Search for context instances
        /// </summary>
        /// <remarks>
        ///  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstances</returns>
        ContextInstances SearchContextInstances(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Search for context instances
        /// </summary>
        /// <remarks>
        ///  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstances</returns>
        ApiResponse<ContextInstances> SearchContextInstancesWithHttpInfo(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Search for contexts
        /// </summary>
        /// <remarks>
        ///  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Contexts</returns>
        Contexts SearchContexts(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Search for contexts
        /// </summary>
        /// <remarks>
        ///  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Contexts</returns>
        ApiResponse<Contexts> SearchContextsWithHttpInfo(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IContextsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete context instances
        /// </summary>
        /// <remarks>
        /// Delete context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteContextInstancesAsync(string projectKey, string environmentKey, string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Delete context instances
        /// </summary>
        /// <remarks>
        /// Delete context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Evaluate flags for context instance
        /// </summary>
        /// <remarks>
        /// Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstanceEvaluations</returns>
        System.Threading.Tasks.Task<ContextInstanceEvaluations> EvaluateContextInstanceAsync(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Evaluate flags for context instance
        /// </summary>
        /// <remarks>
        /// Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstanceEvaluations)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextInstanceEvaluations>> EvaluateContextInstanceWithHttpInfoAsync(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get context attribute names
        /// </summary>
        /// <remarks>
        /// Get context attribute names.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextAttributeNamesCollection</returns>
        System.Threading.Tasks.Task<ContextAttributeNamesCollection> GetContextAttributeNamesAsync(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get context attribute names
        /// </summary>
        /// <remarks>
        /// Get context attribute names.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextAttributeNamesCollection)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextAttributeNamesCollection>> GetContextAttributeNamesWithHttpInfoAsync(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get context attribute values
        /// </summary>
        /// <remarks>
        /// Get context attribute values.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextAttributeValuesCollection</returns>
        System.Threading.Tasks.Task<ContextAttributeValuesCollection> GetContextAttributeValuesAsync(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get context attribute values
        /// </summary>
        /// <remarks>
        /// Get context attribute values.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextAttributeValuesCollection)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextAttributeValuesCollection>> GetContextAttributeValuesWithHttpInfoAsync(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get context instances
        /// </summary>
        /// <remarks>
        /// Get context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstances</returns>
        System.Threading.Tasks.Task<ContextInstances> GetContextInstancesAsync(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get context instances
        /// </summary>
        /// <remarks>
        /// Get context instances by ID.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstances)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextInstances>> GetContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get context kinds
        /// </summary>
        /// <remarks>
        /// Get all context kinds for a given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextKindsCollectionRep</returns>
        System.Threading.Tasks.Task<ContextKindsCollectionRep> GetContextKindsByProjectKeyAsync(string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get context kinds
        /// </summary>
        /// <remarks>
        /// Get all context kinds for a given project.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextKindsCollectionRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextKindsCollectionRep>> GetContextKindsByProjectKeyWithHttpInfoAsync(string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Get contexts
        /// </summary>
        /// <remarks>
        /// Get contexts based on kind and key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Contexts</returns>
        System.Threading.Tasks.Task<Contexts> GetContextsAsync(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Get contexts
        /// </summary>
        /// <remarks>
        /// Get contexts based on kind and key.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Contexts)</returns>
        System.Threading.Tasks.Task<ApiResponse<Contexts>> GetContextsWithHttpInfoAsync(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create or update context kind
        /// </summary>
        /// <remarks>
        /// Create or update a context kind by key. Only the included fields will be updated.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpsertResponseRep</returns>
        System.Threading.Tasks.Task<UpsertResponseRep> PutContextKindAsync(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create or update context kind
        /// </summary>
        /// <remarks>
        /// Create or update a context kind by key. Only the included fields will be updated.
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpsertResponseRep)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpsertResponseRep>> PutContextKindWithHttpInfoAsync(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Search for context instances
        /// </summary>
        /// <remarks>
        ///  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstances</returns>
        System.Threading.Tasks.Task<ContextInstances> SearchContextInstancesAsync(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Search for context instances
        /// </summary>
        /// <remarks>
        ///  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstances)</returns>
        System.Threading.Tasks.Task<ApiResponse<ContextInstances>> SearchContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Search for contexts
        /// </summary>
        /// <remarks>
        ///  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Contexts</returns>
        System.Threading.Tasks.Task<Contexts> SearchContextsAsync(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Search for contexts
        /// </summary>
        /// <remarks>
        ///  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </remarks>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Contexts)</returns>
        System.Threading.Tasks.Task<ApiResponse<Contexts>> SearchContextsWithHttpInfoAsync(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IContextsApi : IContextsApiSync, IContextsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ContextsApi : IContextsApi
    {
        private Org.LaunchDarklyTools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContextsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContextsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ContextsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ContextsApi(Org.LaunchDarklyTools.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ContextsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ContextsApi(Org.LaunchDarklyTools.Client.ISynchronousClient client, Org.LaunchDarklyTools.Client.IAsynchronousClient asyncClient, Org.LaunchDarklyTools.Client.IReadableConfiguration configuration)
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
        /// Delete context instances Delete context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteContextInstances(string projectKey, string environmentKey, string id, int operationIndex = 0)
        {
            DeleteContextInstancesWithHttpInfo(projectKey, environmentKey, id);
        }

        /// <summary>
        /// Delete context instances Delete context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Object> DeleteContextInstancesWithHttpInfo(string projectKey, string environmentKey, string id, int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->DeleteContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->DeleteContextInstances");
            }

            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling ContextsApi->DeleteContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "ContextsApi.DeleteContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete context instances Delete context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteContextInstancesAsync(string projectKey, string environmentKey, string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await DeleteContextInstancesWithHttpInfoAsync(projectKey, environmentKey, id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete context instances Delete context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Object>> DeleteContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, string id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->DeleteContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->DeleteContextInstances");
            }

            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling ContextsApi->DeleteContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "ContextsApi.DeleteContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Evaluate flags for context instance Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstanceEvaluations</returns>
        public ContextInstanceEvaluations EvaluateContextInstance(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstanceEvaluations> localVarResponse = EvaluateContextInstanceWithHttpInfo(projectKey, environmentKey, requestBody, limit, offset, sort, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Evaluate flags for context instance Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstanceEvaluations</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextInstanceEvaluations> EvaluateContextInstanceWithHttpInfo(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->EvaluateContextInstance");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->EvaluateContextInstance");
            }

            // verify the required parameter 'requestBody' is set
            if (requestBody == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'requestBody' when calling ContextsApi->EvaluateContextInstance");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = requestBody;

            localVarRequestOptions.Operation = "ContextsApi.EvaluateContextInstance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<ContextInstanceEvaluations>("/api/v2/projects/{projectKey}/environments/{environmentKey}/flags/evaluate", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("EvaluateContextInstance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Evaluate flags for context instance Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstanceEvaluations</returns>
        public async System.Threading.Tasks.Task<ContextInstanceEvaluations> EvaluateContextInstanceAsync(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstanceEvaluations> localVarResponse = await EvaluateContextInstanceWithHttpInfoAsync(projectKey, environmentKey, requestBody, limit, offset, sort, filter, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Evaluate flags for context instance Evaluate flags for a context instance, for example, to determine the expected flag variation. **Do not use this API instead of an SDK.** The LaunchDarkly SDKs are specialized for the tasks of evaluating feature flags in your application at scale and generating analytics events based on those evaluations. This API is not designed for that use case. Any evaluations you perform with this API will not be reflected in features such as flag statuses and flag insights. Context instances evaluated by this API will not appear in the Contexts list. To learn more, read [Comparing LaunchDarkly&#39;s SDKs and REST API](https://docs.launchdarkly.com/guide/api/comparing-sdk-rest-api).  ### Filtering   LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;query&#x60; filters for a string that matches against the flags&#39; keys and names. It is not case sensitive. For example: &#x60;filter&#x3D;query equals dark-mode&#x60;. - &#x60;tags&#x60; filters the list to flags that have all of the tags in the list. For example: &#x60;filter&#x3D;tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60;.  You can also apply multiple filters at once. For example, setting &#x60;filter&#x3D;query equals dark-mode, tags contains [\&quot;beta\&quot;,\&quot;q1\&quot;]&#x60; matches flags which match the key or name &#x60;dark-mode&#x60; and are tagged &#x60;beta&#x60; and &#x60;q1&#x60;. 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="requestBody"></param>
        /// <param name="limit">The number of feature flags to return. Defaults to -1, which returns all flags (optional)</param>
        /// <param name="offset">Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)</param>
        /// <param name="sort">A comma-separated list of fields to sort by. Fields prefixed by a dash ( - ) sort in descending order (optional)</param>
        /// <param name="filter">A comma-separated list of filters. Each filter is of the form &#x60;field operator value&#x60;. Supported fields are explained above. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstanceEvaluations)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextInstanceEvaluations>> EvaluateContextInstanceWithHttpInfoAsync(string projectKey, string environmentKey, Dictionary<string, Object> requestBody, long? limit = default(long?), long? offset = default(long?), string? sort = default(string?), string? filter = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->EvaluateContextInstance");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->EvaluateContextInstance");
            }

            // verify the required parameter 'requestBody' is set
            if (requestBody == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'requestBody' when calling ContextsApi->EvaluateContextInstance");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            localVarRequestOptions.Data = requestBody;

            localVarRequestOptions.Operation = "ContextsApi.EvaluateContextInstance";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ContextInstanceEvaluations>("/api/v2/projects/{projectKey}/environments/{environmentKey}/flags/evaluate", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("EvaluateContextInstance", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context attribute names Get context attribute names.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextAttributeNamesCollection</returns>
        public ContextAttributeNamesCollection GetContextAttributeNames(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeNamesCollection> localVarResponse = GetContextAttributeNamesWithHttpInfo(projectKey, environmentKey, filter, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context attribute names Get context attribute names.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextAttributeNamesCollection</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeNamesCollection> GetContextAttributeNamesWithHttpInfo(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextAttributeNames");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextAttributeNames");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextAttributeNames";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ContextAttributeNamesCollection>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextAttributeNames", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context attribute names Get context attribute names.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextAttributeNamesCollection</returns>
        public async System.Threading.Tasks.Task<ContextAttributeNamesCollection> GetContextAttributeNamesAsync(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeNamesCollection> localVarResponse = await GetContextAttributeNamesWithHttpInfoAsync(projectKey, environmentKey, filter, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context attribute names Get context attribute names.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;name&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 100) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextAttributeNamesCollection)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeNamesCollection>> GetContextAttributeNamesWithHttpInfoAsync(string projectKey, string environmentKey, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextAttributeNames");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextAttributeNames");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextAttributeNames";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ContextAttributeNamesCollection>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextAttributeNames", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context attribute values Get context attribute values.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextAttributeValuesCollection</returns>
        public ContextAttributeValuesCollection GetContextAttributeValues(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeValuesCollection> localVarResponse = GetContextAttributeValuesWithHttpInfo(projectKey, environmentKey, attributeName, filter, limit);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context attribute values Get context attribute values.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextAttributeValuesCollection</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeValuesCollection> GetContextAttributeValuesWithHttpInfo(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextAttributeValues");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextAttributeValues");
            }

            // verify the required parameter 'attributeName' is set
            if (attributeName == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'attributeName' when calling ContextsApi->GetContextAttributeValues");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("attributeName", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(attributeName)); // path parameter
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextAttributeValues";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ContextAttributeValuesCollection>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes/{attributeName}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextAttributeValues", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context attribute values Get context attribute values.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextAttributeValuesCollection</returns>
        public async System.Threading.Tasks.Task<ContextAttributeValuesCollection> GetContextAttributeValuesAsync(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeValuesCollection> localVarResponse = await GetContextAttributeValuesWithHttpInfoAsync(projectKey, environmentKey, attributeName, filter, limit, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context attribute values Get context attribute values.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="attributeName">The attribute name</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts &#x60;kind&#x60; filters, with the &#x60;equals&#x60; operator, and &#x60;value&#x60; filters, with the &#x60;startsWith&#x60; operator. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 100, default: 50) (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextAttributeValuesCollection)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextAttributeValuesCollection>> GetContextAttributeValuesWithHttpInfoAsync(string projectKey, string environmentKey, string attributeName, string? filter = default(string?), long? limit = default(long?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextAttributeValues");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextAttributeValues");
            }

            // verify the required parameter 'attributeName' is set
            if (attributeName == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'attributeName' when calling ContextsApi->GetContextAttributeValues");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("attributeName", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(attributeName)); // path parameter
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextAttributeValues";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ContextAttributeValuesCollection>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes/{attributeName}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextAttributeValues", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context instances Get context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstances</returns>
        public ContextInstances GetContextInstances(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> localVarResponse = GetContextInstancesWithHttpInfo(projectKey, environmentKey, id, limit, continuationToken, sort, filter, includeTotalCount);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context instances Get context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstances</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> GetContextInstancesWithHttpInfo(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextInstances");
            }

            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling ContextsApi->GetContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ContextInstances>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context instances Get context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstances</returns>
        public async System.Threading.Tasks.Task<ContextInstances> GetContextInstancesAsync(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> localVarResponse = await GetContextInstancesWithHttpInfoAsync(projectKey, environmentKey, id, limit, continuationToken, sort, filter, includeTotalCount, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context instances Get context instances by ID.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="id">The context instance ID</param>
        /// <param name="limit">Specifies the maximum number of context instances to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstances)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances>> GetContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, string id, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContextInstances");
            }

            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'id' when calling ContextsApi->GetContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("id", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(id)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ContextInstances>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context kinds Get all context kinds for a given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextKindsCollectionRep</returns>
        public ContextKindsCollectionRep GetContextKindsByProjectKey(string projectKey, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextKindsCollectionRep> localVarResponse = GetContextKindsByProjectKeyWithHttpInfo(projectKey);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context kinds Get all context kinds for a given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextKindsCollectionRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextKindsCollectionRep> GetContextKindsByProjectKeyWithHttpInfo(string projectKey, int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextKindsByProjectKey");
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

            localVarRequestOptions.Operation = "ContextsApi.GetContextKindsByProjectKey";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ContextKindsCollectionRep>("/api/v2/projects/{projectKey}/context-kinds", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextKindsByProjectKey", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get context kinds Get all context kinds for a given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextKindsCollectionRep</returns>
        public async System.Threading.Tasks.Task<ContextKindsCollectionRep> GetContextKindsByProjectKeyAsync(string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextKindsCollectionRep> localVarResponse = await GetContextKindsByProjectKeyWithHttpInfoAsync(projectKey, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get context kinds Get all context kinds for a given project.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextKindsCollectionRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextKindsCollectionRep>> GetContextKindsByProjectKeyWithHttpInfoAsync(string projectKey, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContextKindsByProjectKey");
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

            localVarRequestOptions.Operation = "ContextsApi.GetContextKindsByProjectKey";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ContextKindsCollectionRep>("/api/v2/projects/{projectKey}/context-kinds", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContextKindsByProjectKey", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get contexts Get contexts based on kind and key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Contexts</returns>
        public Contexts GetContexts(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Contexts> localVarResponse = GetContextsWithHttpInfo(projectKey, environmentKey, kind, key, limit, continuationToken, sort, filter, includeTotalCount);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get contexts Get contexts based on kind and key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Contexts</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Contexts> GetContextsWithHttpInfo(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'kind' is set
            if (kind == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'kind' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'key' when calling ContextsApi->GetContexts");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("kind", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(kind)); // path parameter
            localVarRequestOptions.PathParameters.Add("key", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(key)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContexts";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Contexts>("/api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{kind}/{key}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContexts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get contexts Get contexts based on kind and key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Contexts</returns>
        public async System.Threading.Tasks.Task<Contexts> GetContextsAsync(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Contexts> localVarResponse = await GetContextsWithHttpInfoAsync(projectKey, environmentKey, kind, key, limit, continuationToken, sort, filter, includeTotalCount, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get contexts Get contexts based on kind and key.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="kind">The context kind</param>
        /// <param name="key">The context key</param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Contexts)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Contexts>> GetContextsWithHttpInfoAsync(string projectKey, string environmentKey, string kind, string key, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'kind' is set
            if (kind == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'kind' when calling ContextsApi->GetContexts");
            }

            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'key' when calling ContextsApi->GetContexts");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            localVarRequestOptions.PathParameters.Add("kind", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(kind)); // path parameter
            localVarRequestOptions.PathParameters.Add("key", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(key)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }

            localVarRequestOptions.Operation = "ContextsApi.GetContexts";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Contexts>("/api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{kind}/{key}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetContexts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update context kind Create or update a context kind by key. Only the included fields will be updated.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UpsertResponseRep</returns>
        public UpsertResponseRep PutContextKind(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<UpsertResponseRep> localVarResponse = PutContextKindWithHttpInfo(projectKey, key, upsertContextKindPayload);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update context kind Create or update a context kind by key. Only the included fields will be updated.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of UpsertResponseRep</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<UpsertResponseRep> PutContextKindWithHttpInfo(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->PutContextKind");
            }

            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'key' when calling ContextsApi->PutContextKind");
            }

            // verify the required parameter 'upsertContextKindPayload' is set
            if (upsertContextKindPayload == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'upsertContextKindPayload' when calling ContextsApi->PutContextKind");
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
            localVarRequestOptions.PathParameters.Add("key", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(key)); // path parameter
            localVarRequestOptions.Data = upsertContextKindPayload;

            localVarRequestOptions.Operation = "ContextsApi.PutContextKind";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Put<UpsertResponseRep>("/api/v2/projects/{projectKey}/context-kinds/{key}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutContextKind", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update context kind Create or update a context kind by key. Only the included fields will be updated.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpsertResponseRep</returns>
        public async System.Threading.Tasks.Task<UpsertResponseRep> PutContextKindAsync(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<UpsertResponseRep> localVarResponse = await PutContextKindWithHttpInfoAsync(projectKey, key, upsertContextKindPayload, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update context kind Create or update a context kind by key. Only the included fields will be updated.
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="key">The context kind key</param>
        /// <param name="upsertContextKindPayload"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpsertResponseRep)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<UpsertResponseRep>> PutContextKindWithHttpInfoAsync(string projectKey, string key, UpsertContextKindPayload upsertContextKindPayload, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->PutContextKind");
            }

            // verify the required parameter 'key' is set
            if (key == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'key' when calling ContextsApi->PutContextKind");
            }

            // verify the required parameter 'upsertContextKindPayload' is set
            if (upsertContextKindPayload == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'upsertContextKindPayload' when calling ContextsApi->PutContextKind");
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
            localVarRequestOptions.PathParameters.Add("key", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(key)); // path parameter
            localVarRequestOptions.Data = upsertContextKindPayload;

            localVarRequestOptions.Operation = "ContextsApi.PutContextKind";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<UpsertResponseRep>("/api/v2/projects/{projectKey}/context-kinds/{key}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutContextKind", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search for context instances  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ContextInstances</returns>
        public ContextInstances SearchContextInstances(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> localVarResponse = SearchContextInstancesWithHttpInfo(projectKey, environmentKey, contextInstanceSearch, limit, continuationToken, sort, filter, includeTotalCount);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search for context instances  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ContextInstances</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> SearchContextInstancesWithHttpInfo(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->SearchContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->SearchContextInstances");
            }

            // verify the required parameter 'contextInstanceSearch' is set
            if (contextInstanceSearch == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'contextInstanceSearch' when calling ContextsApi->SearchContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }
            localVarRequestOptions.Data = contextInstanceSearch;

            localVarRequestOptions.Operation = "ContextsApi.SearchContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<ContextInstances>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/search", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search for context instances  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ContextInstances</returns>
        public async System.Threading.Tasks.Task<ContextInstances> SearchContextInstancesAsync(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances> localVarResponse = await SearchContextInstancesWithHttpInfoAsync(projectKey, environmentKey, contextInstanceSearch, limit, continuationToken, sort, filter, includeTotalCount, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search for context instances  Search for context instances.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about context instances, read [Context instances](https://docs.launchdarkly.com/home/observability/multi-contexts#context-instances). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextInstanceSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to context instances with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. This endpoint only accepts an &#x60;applicationId&#x60; filter. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching context instances. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ContextInstances)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<ContextInstances>> SearchContextInstancesWithHttpInfoAsync(string projectKey, string environmentKey, ContextInstanceSearch contextInstanceSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->SearchContextInstances");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->SearchContextInstances");
            }

            // verify the required parameter 'contextInstanceSearch' is set
            if (contextInstanceSearch == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'contextInstanceSearch' when calling ContextsApi->SearchContextInstances");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }
            localVarRequestOptions.Data = contextInstanceSearch;

            localVarRequestOptions.Operation = "ContextsApi.SearchContextInstances";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ContextInstances>("/api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchContextInstances", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search for contexts  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Contexts</returns>
        public Contexts SearchContexts(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Contexts> localVarResponse = SearchContextsWithHttpInfo(projectKey, environmentKey, contextSearch, limit, continuationToken, sort, filter, includeTotalCount);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search for contexts  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Contexts</returns>
        public Org.LaunchDarklyTools.Client.ApiResponse<Contexts> SearchContextsWithHttpInfo(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->SearchContexts");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->SearchContexts");
            }

            // verify the required parameter 'contextSearch' is set
            if (contextSearch == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'contextSearch' when calling ContextsApi->SearchContexts");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }
            localVarRequestOptions.Data = contextSearch;

            localVarRequestOptions.Operation = "ContextsApi.SearchContexts";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Contexts>("/api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/search", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchContexts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search for contexts  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Contexts</returns>
        public async System.Threading.Tasks.Task<Contexts> SearchContextsAsync(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Org.LaunchDarklyTools.Client.ApiResponse<Contexts> localVarResponse = await SearchContextsWithHttpInfoAsync(projectKey, environmentKey, contextSearch, limit, continuationToken, sort, filter, includeTotalCount, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search for contexts  Search for contexts.  You can use either the query parameters or the request body parameters. If both are provided, there is an error.  To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). To learn more about contexts, read [Contexts and context kinds](https://docs.launchdarkly.com/home/observability/contexts#contexts-and-context-kinds). 
        /// </summary>
        /// <exception cref="Org.LaunchDarklyTools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectKey">The project key</param>
        /// <param name="environmentKey">The environment key</param>
        /// <param name="contextSearch"></param>
        /// <param name="limit">Specifies the maximum number of items in the collection to return (max: 50, default: 20) (optional)</param>
        /// <param name="continuationToken">Limits results to contexts with sort values after the value specified. You can use this for pagination, however, we recommend using the &#x60;next&#x60; link we provide instead. (optional)</param>
        /// <param name="sort">Specifies a field by which to sort. LaunchDarkly supports sorting by timestamp in ascending order by specifying &#x60;ts&#x60; for this value, or descending order by specifying &#x60;-ts&#x60;. (optional)</param>
        /// <param name="filter">A comma-separated list of context filters. To learn more about the filter syntax, read [Filtering contexts and context instances](/tag/Contexts#filtering-contexts-and-context-instances). (optional)</param>
        /// <param name="includeTotalCount">Specifies whether to include or omit the total count of matching contexts. Defaults to true. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Contexts)</returns>
        public async System.Threading.Tasks.Task<Org.LaunchDarklyTools.Client.ApiResponse<Contexts>> SearchContextsWithHttpInfoAsync(string projectKey, string environmentKey, ContextSearch contextSearch, long? limit = default(long?), string? continuationToken = default(string?), string? sort = default(string?), string? filter = default(string?), bool? includeTotalCount = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'projectKey' is set
            if (projectKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'projectKey' when calling ContextsApi->SearchContexts");
            }

            // verify the required parameter 'environmentKey' is set
            if (environmentKey == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'environmentKey' when calling ContextsApi->SearchContexts");
            }

            // verify the required parameter 'contextSearch' is set
            if (contextSearch == null)
            {
                throw new Org.LaunchDarklyTools.Client.ApiException(400, "Missing required parameter 'contextSearch' when calling ContextsApi->SearchContexts");
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
            localVarRequestOptions.PathParameters.Add("environmentKey", Org.LaunchDarklyTools.Client.ClientUtils.ParameterToString(environmentKey)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (continuationToken != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "continuationToken", continuationToken));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (includeTotalCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.LaunchDarklyTools.Client.ClientUtils.ParameterToMultiMap("", "includeTotalCount", includeTotalCount));
            }
            localVarRequestOptions.Data = contextSearch;

            localVarRequestOptions.Operation = "ContextsApi.SearchContexts";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", this.Configuration.GetApiKeyWithPrefix("Authorization"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Contexts>("/api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/search", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchContexts", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
