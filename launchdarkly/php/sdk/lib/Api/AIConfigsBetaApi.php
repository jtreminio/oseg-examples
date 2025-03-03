<?php
/**
 * AIConfigsBetaApi
 * PHP version 7.4
 *
 * @category Class
 * @package  LaunchDarkly\Client
 * @author   OpenAPI Generator team
 * @link     https://openapi-generator.tech
 */

/**
 * LaunchDarkly REST API
 *
 * # Overview  ## Authentication  LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.  All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.  LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.  | Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          | | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | -------------------------------------------------- | | [Personal or service access tokens](https://docs.launchdarkly.com/home/account/api) | Can be customized on a per-token basis                                                                | Building scripts, custom integrations, data export. | | SDK keys                                                                                        | Can only access read-only resources specific to server-side SDKs. Restricted to a single environment. | Server-side SDKs                     | | Mobile keys                                                                                     | Can only access read-only resources specific to mobile SDKs, and only for flags marked available to mobile keys. Restricted to a single environment.           | Mobile SDKs                                        | | Client-side ID                                                                                  | Can only access read-only resources specific to JavaScript-based client-side SDKs, and only for flags marked available to client-side. Restricted to a single environment.           | Client-side JavaScript                             |  > #### Keep your access tokens and SDK keys private > > Access tokens should _never_ be exposed in untrusted contexts. Never put an access token in client-side JavaScript, or embed it in a mobile application. LaunchDarkly has special mobile keys that you can embed in mobile apps. If you accidentally expose an access token or SDK key, you can reset it from your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page. > > The client-side ID is safe to embed in untrusted contexts. It's designed for use in client-side JavaScript.  ### Authentication using request header  The preferred way to authenticate with the API is by adding an `Authorization` header containing your access token to your requests. The value of the `Authorization` header must be your access token.  Manage personal access tokens from the [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.  ### Authentication using session cookie  For testing purposes, you can make API calls directly from your web browser. If you are logged in to the LaunchDarkly application, the API will use your existing session to authenticate calls.  If you have a [role](https://docs.launchdarkly.com/home/account/built-in-roles) other than Admin, or have a [custom role](https://docs.launchdarkly.com/home/account/custom-roles) defined, you may not have permission to perform some API calls. You will receive a `401` response code in that case.  > ### Modifying the Origin header causes an error > > LaunchDarkly validates that the Origin header for any API request authenticated by a session cookie matches the expected Origin header. The expected Origin header is `https://app.launchdarkly.com`. > > If the Origin header does not match what's expected, LaunchDarkly returns an error. This error can prevent the LaunchDarkly app from working correctly. > > Any browser extension that intentionally changes the Origin header can cause this problem. For example, the `Allow-Control-Allow-Origin: *` Chrome extension changes the Origin header to `http://evil.com` and causes the app to fail. > > To prevent this error, do not modify your Origin header. > > LaunchDarkly does not require origin matching when authenticating with an access token, so this issue does not affect normal API usage.  ## Representations  All resources expect and return JSON response bodies. Error responses also send a JSON body. To learn more about the error format of the API, read [Errors](/#section/Overview/Errors).  In practice this means that you always get a response with a `Content-Type` header set to `application/json`.  In addition, request bodies for `PATCH`, `POST`, and `PUT` requests must be encoded as JSON with a `Content-Type` header set to `application/json`.  ### Summary and detailed representations  When you fetch a list of resources, the response includes only the most important attributes of each resource. This is a _summary representation_ of the resource. When you fetch an individual resource, such as a single feature flag, you receive a _detailed representation_ of the resource.  The best way to find a detailed representation is to follow links. Every summary representation includes a link to its detailed representation.  ### Expanding responses  Sometimes the detailed representation of a resource does not include all of the attributes of the resource by default. If this is the case, the request method will clearly document this and describe which attributes you can include in an expanded response.  To include the additional attributes, append the `expand` request parameter to your request and add a comma-separated list of the attributes to include. For example, when you append `?expand=members,maintainers` to the [Get team](/tag/Teams#operation/getTeam) endpoint, the expanded response includes both of these attributes.  ### Links and addressability  The best way to navigate the API is by following links. These are attributes in representations that link to other resources. The API always uses the same format for links:  - Links to other resources within the API are encapsulated in a `_links` object - If the resource has a corresponding link to HTML content on the site, it is stored in a special `_site` link  Each link has two attributes:  - An `href`, which contains the URL - A `type`, which describes the content type  For example, a feature resource might return the following:  ```json {   \"_links\": {     \"parent\": {       \"href\": \"/api/features\",       \"type\": \"application/json\"     },     \"self\": {       \"href\": \"/api/features/sort.order\",       \"type\": \"application/json\"     }   },   \"_site\": {     \"href\": \"/features/sort.order\",     \"type\": \"text/html\"   } } ```  From this, you can navigate to the parent collection of features by following the `parent` link, or navigate to the site page for the feature by following the `_site` link.  Collections are always represented as a JSON object with an `items` attribute containing an array of representations. Like all other representations, collections have `_links` defined at the top level.  Paginated collections include `first`, `last`, `next`, and `prev` links containing a URL with the respective set of elements in the collection.  ## Updates  Resources that accept partial updates use the `PATCH` verb. Most resources support the [JSON patch](/reference#updates-using-json-patch) format. Some resources also support the [JSON merge patch](/reference#updates-using-json-merge-patch) format, and some resources support the [semantic patch](/reference#updates-using-semantic-patch) format, which is a way to specify the modifications to perform as a set of executable instructions. Each resource supports optional [comments](/reference#updates-with-comments) that you can submit with updates. Comments appear in outgoing webhooks, the audit log, and other integrations.  When a resource supports both JSON patch and semantic patch, we document both in the request method. However, the specific request body fields and descriptions included in our documentation only match one type of patch or the other.  ### Updates using JSON patch  [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) is a way to specify the modifications to perform on a resource. JSON patch uses paths and a limited set of operations to describe how to transform the current state of the resource into a new state. JSON patch documents are always arrays, where each element contains an operation, a path to the field to update, and the new value.  For example, in this feature flag representation:  ```json {     \"name\": \"New recommendations engine\",     \"key\": \"engine.enable\",     \"description\": \"This is the description\",     ... } ``` You can change the feature flag's description with the following patch document:  ```json [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"This is the new description\" }] ```  You can specify multiple modifications to perform in a single request. You can also test that certain preconditions are met before applying the patch:  ```json [   { \"op\": \"test\", \"path\": \"/version\", \"value\": 10 },   { \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" } ] ```  The above patch request tests whether the feature flag's `version` is `10`, and if so, changes the feature flag's description.  Attributes that are not editable, such as a resource's `_links`, have names that start with an underscore.  ### Updates using JSON merge patch  [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) is another format for specifying the modifications to perform on a resource. JSON merge patch is less expressive than JSON patch. However, in many cases it is simpler to construct a merge patch document. For example, you can change a feature flag's description with the following merge patch document:  ```json {   \"description\": \"New flag description\" } ```  ### Updates using semantic patch  Some resources support the semantic patch format. A semantic patch is a way to specify the modifications to perform on a resource as a set of executable instructions.  Semantic patch allows you to be explicit about intent using precise, custom instructions. In many cases, you can define semantic patch instructions independently of the current state of the resource. This can be useful when defining a change that may be applied at a future date.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header.  Here's how:  ``` Content-Type: application/json; domain-model=launchdarkly.semanticpatch ```  If you call a semantic patch resource without this header, you will receive a `400` response because your semantic patch will be interpreted as a JSON patch.  The body of a semantic patch request takes the following properties:  * `comment` (string): (Optional) A description of the update. * `environmentKey` (string): (Required for some resources only) The environment key. * `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the instruction requires parameters, you must include those parameters as additional fields in the object. The documentation for each resource that supports semantic patch includes the available instructions and any additional parameters.  For example:  ```json {   \"comment\": \"optional comment\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  Semantic patches are not applied partially; either all of the instructions are applied or none of them are. If **any** instruction is invalid, the endpoint returns an error and will not change the resource. If all instructions are valid, the request succeeds and the resources are updated if necessary, or left unchanged if they are already in the state you request.  ### Updates with comments  You can submit optional comments with `PATCH` changes.  To submit a comment along with a JSON patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"patch\": [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }] } ```  To submit a comment along with a JSON merge patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"merge\": { \"description\": \"New flag description\" } } ```  To submit a comment along with a semantic patch, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  ## Errors  The API always returns errors in a common format. Here's an example:  ```json {   \"code\": \"invalid_request\",   \"message\": \"A feature with that key already exists\",   \"id\": \"30ce6058-87da-11e4-b116-123b93f75cba\" } ```  The `code` indicates the general class of error. The `message` is a human-readable explanation of what went wrong. The `id` is a unique identifier. Use it when you're working with LaunchDarkly Support to debug a problem with a specific API call.  ### HTTP status error response codes  | Code | Definition        | Description                                                                                       | Possible Solution                                                | | ---- | ----------------- | ------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- | | 400  | Invalid request       | The request cannot be understood.                                    | Ensure JSON syntax in request body is correct.                   | | 401  | Invalid access token      | Requestor is unauthorized or does not have permission for this API call.                                                | Ensure your API access token is valid and has the appropriate permissions.                                     | | 403  | Forbidden         | Requestor does not have access to this resource.                                                | Ensure that the account member or access token has proper permissions set. | | 404  | Invalid resource identifier | The requested resource is not valid. | Ensure that the resource is correctly identified by ID or key. | | 405  | Method not allowed | The request method is not allowed on this resource. | Ensure that the HTTP verb is correct. | | 409  | Conflict          | The API request can not be completed because it conflicts with a concurrent API request. | Retry your request.                                              | | 422  | Unprocessable entity | The API request can not be completed because the update description can not be understood. | Ensure that the request body is correct for the type of patch you are using, either JSON patch or semantic patch. | 429  | Too many requests | Read [Rate limiting](/#section/Overview/Rate-limiting).                                               | Wait and try again later.                                        |  ## CORS  The LaunchDarkly API supports Cross Origin Resource Sharing (CORS) for AJAX requests from any origin. If an `Origin` header is given in a request, it will be echoed as an explicitly allowed origin. Otherwise the request returns a wildcard, `Access-Control-Allow-Origin: *`. For more information on CORS, read the [CORS W3C Recommendation](http://www.w3.org/TR/cors). Example CORS headers might look like:  ```http Access-Control-Allow-Headers: Accept, Content-Type, Content-Length, Accept-Encoding, Authorization Access-Control-Allow-Methods: OPTIONS, GET, DELETE, PATCH Access-Control-Allow-Origin: * Access-Control-Max-Age: 300 ```  You can make authenticated CORS calls just as you would make same-origin calls, using either [token or session-based authentication](/#section/Overview/Authentication). If you are using session authentication, you should set the `withCredentials` property for your `xhr` request to `true`. You should never expose your access tokens to untrusted entities.  ## Rate limiting  We use several rate limiting strategies to ensure the availability of our APIs. Rate-limited calls to our APIs return a `429` status code. Calls to our APIs include headers indicating the current rate limit status. The specific headers returned depend on the API route being called. The limits differ based on the route, authentication mechanism, and other factors. Routes that are not rate limited may not contain any of the headers described below.  > ### Rate limiting and SDKs > > LaunchDarkly SDKs are never rate limited and do not use the API endpoints defined here. LaunchDarkly uses a different set of approaches, including streaming/server-sent events and a global CDN, to ensure availability to the routes used by LaunchDarkly SDKs.  ### Global rate limits  Authenticated requests are subject to a global limit. This is the maximum number of calls that your account can make to the API per ten seconds. All service and personal access tokens on the account share this limit, so exceeding the limit with one access token will impact other tokens. Calls that are subject to global rate limits may return the headers below:  | Header name                    | Description                                                                      | | ------------------------------ | -------------------------------------------------------------------------------- | | `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |  We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.  ### Route-level rate limits  Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:  | Header name                   | Description                                                                                           | | ----------------------------- | ----------------------------------------------------------------------------------------------------- | | `X-Ratelimit-Route-Remaining` | The maximum number of requests to the current route the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`           | The time at which the current rate limit window resets in epoch milliseconds.                         |  A _route_ represents a specific URL pattern and verb. For example, the [Delete environment](/tag/Environments#operation/deleteEnvironment) endpoint is considered a single route, and each call to delete an environment counts against your route-level rate limit for that route.  We do not publicly document the specific number of calls that an account can make to each endpoint per ten seconds. These limits may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limits.  ### IP-based rate limiting  We also employ IP-based rate limiting on some API routes. If you hit an IP-based rate limit, your API response will include a `Retry-After` header indicating how long to wait before re-trying the call. Clients must wait at least `Retry-After` seconds before making additional calls to our API, and should employ jitter and backoff strategies to avoid triggering rate limits again.  ## OpenAPI (Swagger) and client libraries  We have a [complete OpenAPI (Swagger) specification](https://app.launchdarkly.com/api/v2/openapi.json) for our API.  We auto-generate multiple client libraries based on our OpenAPI specification. To learn more, visit the [collection of client libraries on GitHub](https://github.com/search?q=topic%3Alaunchdarkly-api+org%3Alaunchdarkly&type=Repositories). You can also use this specification to generate client libraries to interact with our REST API in your language of choice.  Our OpenAPI specification is supported by several API-based tools such as Postman and Insomnia. In many cases, you can directly import our specification to explore our APIs.  ## Method overriding  Some firewalls and HTTP clients restrict the use of verbs other than `GET` and `POST`. In those environments, our API endpoints that use `DELETE`, `PATCH`, and `PUT` verbs are inaccessible.  To avoid this issue, our API supports the `X-HTTP-Method-Override` header, allowing clients to \"tunnel\" `DELETE`, `PATCH`, and `PUT` requests using a `POST` request.  For example, to call a `PATCH` endpoint using a `POST` request, you can include `X-HTTP-Method-Override:PATCH` as a header.  ## Beta resources  We sometimes release new API resources in **beta** status before we release them with general availability.  Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  We try to promote resources into general availability as quickly as possible. This happens after sufficient testing and when we're satisfied that we no longer need to make backwards-incompatible changes.  We mark beta resources with a \"Beta\" callout in our documentation, pictured below:  > ### This feature is in beta > > To use this feature, pass in a header including the `LD-API-Version` key with value set to `beta`. Use this header with each call. To learn more, read [Beta resources](/#section/Overview/Beta-resources). > > Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  ### Using beta resources  To use a beta resource, you must include a header in the request. If you call a beta resource without this header, you receive a `403` response.  Use this header:  ``` LD-API-Version: beta ```  ## Federal environments  The version of LaunchDarkly that is available on domains controlled by the United States government is different from the version of LaunchDarkly available to the general public. If you are an employee or contractor for a United States federal agency and use LaunchDarkly in your work, you likely use the federal instance of LaunchDarkly.  If you are working in the federal instance of LaunchDarkly, the base URI for each request is `https://app.launchdarkly.us`. In the \"Try it\" sandbox for each request, click the request path to view the complete resource path for the federal environment.  To learn more, read [LaunchDarkly in federal environments](https://docs.launchdarkly.com/home/infrastructure/federal).  ## Versioning  We try hard to keep our REST API backwards compatible, but we occasionally have to make backwards-incompatible changes in the process of shipping new features. These breaking changes can cause unexpected behavior if you don't prepare for them accordingly.  Updates to our REST API include support for the latest features in LaunchDarkly. We also release a new version of our REST API every time we make a breaking change. We provide simultaneous support for multiple API versions so you can migrate from your current API version to a new version at your own pace.  ### Setting the API version per request  You can set the API version on a specific request by sending an `LD-API-Version` header, as shown in the example below:  ``` LD-API-Version: 20240415 ```  The header value is the version number of the API version you would like to request. The number for each version corresponds to the date the version was released in `yyyymmdd` format. In the example above the version `20240415` corresponds to April 15, 2024.  ### Setting the API version per access token  When you create an access token, you must specify a specific version of the API to use. This ensures that integrations using this token cannot be broken by version changes.  Tokens created before versioning was released have their version set to `20160426`, which is the version of the API that existed before the current versioning scheme, so that they continue working the same way they did before versioning.  If you would like to upgrade your integration to use a new API version, you can explicitly set the header described above.  > ### Best practice: Set the header for every client or integration > > We recommend that you set the API version header explicitly in any client or integration you build. > > Only rely on the access token API version during manual testing.  ### API version changelog  |<div style=\"width:75px\">Version</div> | Changes | End of life (EOL) |---|---|---| | `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current | | `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 | | `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 | | `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 | | `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |  To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/).
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@launchdarkly.com
 * Generated by: https://openapi-generator.tech
 * Generator version: 7.11.0
 */

/**
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

namespace LaunchDarkly\Client\Api;

use GuzzleHttp\Client;
use GuzzleHttp\ClientInterface;
use GuzzleHttp\Exception\ConnectException;
use GuzzleHttp\Exception\RequestException;
use GuzzleHttp\Psr7\MultipartStream;
use GuzzleHttp\Psr7\Request;
use GuzzleHttp\RequestOptions;
use LaunchDarkly\Client\ApiException;
use LaunchDarkly\Client\Configuration;
use LaunchDarkly\Client\HeaderSelector;
use LaunchDarkly\Client\ObjectSerializer;

/**
 * AIConfigsBetaApi Class Doc Comment
 *
 * @category Class
 * @package  LaunchDarkly\Client
 * @author   OpenAPI Generator team
 * @link     https://openapi-generator.tech
 */
class AIConfigsBetaApi
{
    /**
     * @var ClientInterface
     */
    protected $client;

    /**
     * @var Configuration
     */
    protected $config;

    /**
     * @var HeaderSelector
     */
    protected $headerSelector;

    /**
     * @var int Host index
     */
    protected $hostIndex;

    /** @var string[] $contentTypes **/
    public const contentTypes = [
        'deleteAIConfig' => [
            'application/json',
        ],
        'deleteAIConfigVariation' => [
            'application/json',
        ],
        'deleteModelConfig' => [
            'application/json',
        ],
        'getAIConfig' => [
            'application/json',
        ],
        'getAIConfigMetrics' => [
            'application/json',
        ],
        'getAIConfigMetricsByVariation' => [
            'application/json',
        ],
        'getAIConfigVariation' => [
            'application/json',
        ],
        'getAIConfigs' => [
            'application/json',
        ],
        'getModelConfig' => [
            'application/json',
        ],
        'listModelConfigs' => [
            'application/json',
        ],
        'patchAIConfig' => [
            'application/json',
        ],
        'patchAIConfigVariation' => [
            'application/json',
        ],
        'postAIConfig' => [
            'application/json',
        ],
        'postAIConfigVariation' => [
            'application/json',
        ],
        'postModelConfig' => [
            'application/json',
        ],
    ];

    /**
     * @param ClientInterface $client
     * @param Configuration   $config
     * @param HeaderSelector  $selector
     * @param int             $hostIndex (Optional) host index to select the list of hosts if defined in the OpenAPI spec
     */
    public function __construct(
        ?ClientInterface $client = null,
        ?Configuration $config = null,
        ?HeaderSelector $selector = null,
        int $hostIndex = 0
    ) {
        $this->client = $client ?: new Client();
        $this->config = $config ?: Configuration::getDefaultConfiguration();
        $this->headerSelector = $selector ?: new HeaderSelector();
        $this->hostIndex = $hostIndex;
    }

    /**
     * Set the host index
     *
     * @param int $hostIndex Host index (required)
     */
    public function setHostIndex($hostIndex): void
    {
        $this->hostIndex = $hostIndex;
    }

    /**
     * Get the host index
     *
     * @return int Host index
     */
    public function getHostIndex()
    {
        return $this->hostIndex;
    }

    /**
     * @return Configuration
     */
    public function getConfig()
    {
        return $this->config;
    }

    /**
     * Operation deleteAIConfig
     *
     * Delete AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return void
     */
    public function deleteAIConfig($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['deleteAIConfig'][0])
    {
        $this->deleteAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, $contentType);
    }

    /**
     * Operation deleteAIConfigWithHttpInfo
     *
     * Delete AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of null, HTTP status code, HTTP response headers (array of strings)
     */
    public function deleteAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['deleteAIConfig'][0])
    {
        $request = $this->deleteAIConfigRequest($ld_api_version, $project_key, $config_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            return [null, $statusCode, $response->getHeaders()];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation deleteAIConfigAsync
     *
     * Delete AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteAIConfigAsync($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['deleteAIConfig'][0])
    {
        return $this->deleteAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation deleteAIConfigAsyncWithHttpInfo
     *
     * Delete AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['deleteAIConfig'][0])
    {
        $returnType = '';
        $request = $this->deleteAIConfigRequest($ld_api_version, $project_key, $config_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    return [null, $response->getStatusCode(), $response->getHeaders()];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'deleteAIConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function deleteAIConfigRequest($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['deleteAIConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling deleteAIConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling deleteAIConfig'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling deleteAIConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'DELETE',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation deleteAIConfigVariation
     *
     * Delete AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  string $variation_key variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return void
     */
    public function deleteAIConfigVariation($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['deleteAIConfigVariation'][0])
    {
        $this->deleteAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $contentType);
    }

    /**
     * Operation deleteAIConfigVariationWithHttpInfo
     *
     * Delete AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of null, HTTP status code, HTTP response headers (array of strings)
     */
    public function deleteAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['deleteAIConfigVariation'][0])
    {
        $request = $this->deleteAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            return [null, $statusCode, $response->getHeaders()];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation deleteAIConfigVariationAsync
     *
     * Delete AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteAIConfigVariationAsync($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['deleteAIConfigVariation'][0])
    {
        return $this->deleteAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation deleteAIConfigVariationAsyncWithHttpInfo
     *
     * Delete AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['deleteAIConfigVariation'][0])
    {
        $returnType = '';
        $request = $this->deleteAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    return [null, $response->getStatusCode(), $response->getHeaders()];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'deleteAIConfigVariation'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function deleteAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['deleteAIConfigVariation'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling deleteAIConfigVariation'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling deleteAIConfigVariation'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling deleteAIConfigVariation'
            );
        }

        // verify the required parameter 'variation_key' is set
        if ($variation_key === null || (is_array($variation_key) && count($variation_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $variation_key when calling deleteAIConfigVariation'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }
        // path params
        if ($variation_key !== null) {
            $resourcePath = str_replace(
                '{' . 'variationKey' . '}',
                ObjectSerializer::toPathValue($variation_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'DELETE',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation deleteModelConfig
     *
     * Delete an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $model_config_key model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return void
     */
    public function deleteModelConfig($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['deleteModelConfig'][0])
    {
        $this->deleteModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_key, $contentType);
    }

    /**
     * Operation deleteModelConfigWithHttpInfo
     *
     * Delete an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of null, HTTP status code, HTTP response headers (array of strings)
     */
    public function deleteModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['deleteModelConfig'][0])
    {
        $request = $this->deleteModelConfigRequest($ld_api_version, $project_key, $model_config_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            return [null, $statusCode, $response->getHeaders()];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation deleteModelConfigAsync
     *
     * Delete an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteModelConfigAsync($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['deleteModelConfig'][0])
    {
        return $this->deleteModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation deleteModelConfigAsyncWithHttpInfo
     *
     * Delete an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function deleteModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['deleteModelConfig'][0])
    {
        $returnType = '';
        $request = $this->deleteModelConfigRequest($ld_api_version, $project_key, $model_config_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    return [null, $response->getStatusCode(), $response->getHeaders()];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'deleteModelConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['deleteModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function deleteModelConfigRequest($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['deleteModelConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling deleteModelConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling deleteModelConfig'
            );
        }

        // verify the required parameter 'model_config_key' is set
        if ($model_config_key === null || (is_array($model_config_key) && count($model_config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $model_config_key when calling deleteModelConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($model_config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'modelConfigKey' . '}',
                ObjectSerializer::toPathValue($model_config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'DELETE',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getAIConfig
     *
     * Get AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getAIConfig($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['getAIConfig'][0])
    {
        list($response) = $this->getAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, $contentType);
        return $response;
    }

    /**
     * Operation getAIConfigWithHttpInfo
     *
     * Get AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['getAIConfig'][0])
    {
        $request = $this->getAIConfigRequest($ld_api_version, $project_key, $config_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\AIConfig' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfig' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfig', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfig';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfig',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getAIConfigAsync
     *
     * Get AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigAsync($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['getAIConfig'][0])
    {
        return $this->getAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getAIConfigAsyncWithHttpInfo
     *
     * Get AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['getAIConfig'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfig';
        $request = $this->getAIConfigRequest($ld_api_version, $project_key, $config_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getAIConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getAIConfigRequest($ld_api_version, $project_key, $config_key, string $contentType = self::contentTypes['getAIConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getAIConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getAIConfig'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling getAIConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getAIConfigMetrics
     *
     * Get AI config metrics
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetrics'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\Metrics|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getAIConfigMetrics($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetrics'][0])
    {
        list($response) = $this->getAIConfigMetricsWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);
        return $response;
    }

    /**
     * Operation getAIConfigMetricsWithHttpInfo
     *
     * Get AI config metrics
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetrics'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\Metrics|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getAIConfigMetricsWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetrics'][0])
    {
        $request = $this->getAIConfigMetricsRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\Metrics' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Metrics' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Metrics', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\Metrics';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Metrics',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getAIConfigMetricsAsync
     *
     * Get AI config metrics
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetrics'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigMetricsAsync($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetrics'][0])
    {
        return $this->getAIConfigMetricsAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getAIConfigMetricsAsyncWithHttpInfo
     *
     * Get AI config metrics
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetrics'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigMetricsAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetrics'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\Metrics';
        $request = $this->getAIConfigMetricsRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getAIConfigMetrics'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetrics'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getAIConfigMetricsRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetrics'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getAIConfigMetrics'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getAIConfigMetrics'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling getAIConfigMetrics'
            );
        }

        // verify the required parameter 'from' is set
        if ($from === null || (is_array($from) && count($from) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $from when calling getAIConfigMetrics'
            );
        }

        // verify the required parameter 'to' is set
        if ($to === null || (is_array($to) && count($to) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $to when calling getAIConfigMetrics'
            );
        }

        // verify the required parameter 'env' is set
        if ($env === null || (is_array($env) && count($env) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $env when calling getAIConfigMetrics'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;

        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $from,
            'from', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $to,
            'to', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $env,
            'env', // param base name
            'string', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);

        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getAIConfigMetricsByVariation
     *
     * Get AI config metrics by variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetricsByVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\MetricByVariation[]|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getAIConfigMetricsByVariation($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetricsByVariation'][0])
    {
        list($response) = $this->getAIConfigMetricsByVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);
        return $response;
    }

    /**
     * Operation getAIConfigMetricsByVariationWithHttpInfo
     *
     * Get AI config metrics by variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetricsByVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\MetricByVariation[]|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getAIConfigMetricsByVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetricsByVariation'][0])
    {
        $request = $this->getAIConfigMetricsByVariationRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\MetricByVariation[]' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\MetricByVariation[]' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\MetricByVariation[]', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\MetricByVariation[]';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\MetricByVariation[]',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getAIConfigMetricsByVariationAsync
     *
     * Get AI config metrics by variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetricsByVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigMetricsByVariationAsync($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetricsByVariation'][0])
    {
        return $this->getAIConfigMetricsByVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getAIConfigMetricsByVariationAsyncWithHttpInfo
     *
     * Get AI config metrics by variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetricsByVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigMetricsByVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetricsByVariation'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\MetricByVariation[]';
        $request = $this->getAIConfigMetricsByVariationRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getAIConfigMetricsByVariation'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  int $from The starting time, as milliseconds since epoch (inclusive). (required)
     * @param  int $to The ending time, as milliseconds since epoch (exclusive). May not be more than 100 days after &#x60;from&#x60;. (required)
     * @param  string $env An environment key. Only metrics from this environment will be included. (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigMetricsByVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getAIConfigMetricsByVariationRequest($ld_api_version, $project_key, $config_key, $from, $to, $env, string $contentType = self::contentTypes['getAIConfigMetricsByVariation'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getAIConfigMetricsByVariation'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getAIConfigMetricsByVariation'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling getAIConfigMetricsByVariation'
            );
        }

        // verify the required parameter 'from' is set
        if ($from === null || (is_array($from) && count($from) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $from when calling getAIConfigMetricsByVariation'
            );
        }

        // verify the required parameter 'to' is set
        if ($to === null || (is_array($to) && count($to) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $to when calling getAIConfigMetricsByVariation'
            );
        }

        // verify the required parameter 'env' is set
        if ($env === null || (is_array($env) && count($env) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $env when calling getAIConfigMetricsByVariation'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics-by-variation';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;

        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $from,
            'from', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $to,
            'to', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $env,
            'env', // param base name
            'string', // openApiType
            'form', // style
            true, // explode
            true // required
        ) ?? []);

        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getAIConfigVariation
     *
     * Get AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  string $variation_key variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfigVariationsResponse|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getAIConfigVariation($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['getAIConfigVariation'][0])
    {
        list($response) = $this->getAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $contentType);
        return $response;
    }

    /**
     * Operation getAIConfigVariationWithHttpInfo
     *
     * Get AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfigVariationsResponse|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['getAIConfigVariation'][0])
    {
        $request = $this->getAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\AIConfigVariationsResponse' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfigVariationsResponse' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfigVariationsResponse', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfigVariationsResponse';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfigVariationsResponse',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getAIConfigVariationAsync
     *
     * Get AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigVariationAsync($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['getAIConfigVariation'][0])
    {
        return $this->getAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getAIConfigVariationAsyncWithHttpInfo
     *
     * Get AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['getAIConfigVariation'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfigVariationsResponse';
        $request = $this->getAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getAIConfigVariation'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, string $contentType = self::contentTypes['getAIConfigVariation'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getAIConfigVariation'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getAIConfigVariation'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling getAIConfigVariation'
            );
        }

        // verify the required parameter 'variation_key' is set
        if ($variation_key === null || (is_array($variation_key) && count($variation_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $variation_key when calling getAIConfigVariation'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }
        // path params
        if ($variation_key !== null) {
            $resourcePath = str_replace(
                '{' . 'variationKey' . '}',
                ObjectSerializer::toPathValue($variation_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getAIConfigs
     *
     * List AI configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string|null $sort A sort to apply to the list of AI configs. (optional)
     * @param  int|null $limit The number of AI configs to return. (optional)
     * @param  int|null $offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)
     * @param  string|null $filter A filter to apply to the list of AI configs. (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigs'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfigs|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getAIConfigs($ld_api_version, $project_key, $sort = null, $limit = null, $offset = null, $filter = null, string $contentType = self::contentTypes['getAIConfigs'][0])
    {
        list($response) = $this->getAIConfigsWithHttpInfo($ld_api_version, $project_key, $sort, $limit, $offset, $filter, $contentType);
        return $response;
    }

    /**
     * Operation getAIConfigsWithHttpInfo
     *
     * List AI configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string|null $sort A sort to apply to the list of AI configs. (optional)
     * @param  int|null $limit The number of AI configs to return. (optional)
     * @param  int|null $offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)
     * @param  string|null $filter A filter to apply to the list of AI configs. (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigs'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfigs|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getAIConfigsWithHttpInfo($ld_api_version, $project_key, $sort = null, $limit = null, $offset = null, $filter = null, string $contentType = self::contentTypes['getAIConfigs'][0])
    {
        $request = $this->getAIConfigsRequest($ld_api_version, $project_key, $sort, $limit, $offset, $filter, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\AIConfigs' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfigs' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfigs', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfigs';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfigs',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getAIConfigsAsync
     *
     * List AI configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string|null $sort A sort to apply to the list of AI configs. (optional)
     * @param  int|null $limit The number of AI configs to return. (optional)
     * @param  int|null $offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)
     * @param  string|null $filter A filter to apply to the list of AI configs. (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigsAsync($ld_api_version, $project_key, $sort = null, $limit = null, $offset = null, $filter = null, string $contentType = self::contentTypes['getAIConfigs'][0])
    {
        return $this->getAIConfigsAsyncWithHttpInfo($ld_api_version, $project_key, $sort, $limit, $offset, $filter, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getAIConfigsAsyncWithHttpInfo
     *
     * List AI configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string|null $sort A sort to apply to the list of AI configs. (optional)
     * @param  int|null $limit The number of AI configs to return. (optional)
     * @param  int|null $offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)
     * @param  string|null $filter A filter to apply to the list of AI configs. (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getAIConfigsAsyncWithHttpInfo($ld_api_version, $project_key, $sort = null, $limit = null, $offset = null, $filter = null, string $contentType = self::contentTypes['getAIConfigs'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfigs';
        $request = $this->getAIConfigsRequest($ld_api_version, $project_key, $sort, $limit, $offset, $filter, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getAIConfigs'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string|null $sort A sort to apply to the list of AI configs. (optional)
     * @param  int|null $limit The number of AI configs to return. (optional)
     * @param  int|null $offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;. (optional)
     * @param  string|null $filter A filter to apply to the list of AI configs. (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getAIConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getAIConfigsRequest($ld_api_version, $project_key, $sort = null, $limit = null, $offset = null, $filter = null, string $contentType = self::contentTypes['getAIConfigs'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getAIConfigs'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getAIConfigs'
            );
        }






        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;

        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $sort,
            'sort', // param base name
            'string', // openApiType
            'form', // style
            true, // explode
            false // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $limit,
            'limit', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            false // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $offset,
            'offset', // param base name
            'integer', // openApiType
            'form', // style
            true, // explode
            false // required
        ) ?? []);
        // query params
        $queryParams = array_merge($queryParams, ObjectSerializer::toQueryValue(
            $filter,
            'filter', // param base name
            'string', // openApiType
            'form', // style
            true, // explode
            false // required
        ) ?? []);

        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation getModelConfig
     *
     * Get AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $model_config_key model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\ModelConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function getModelConfig($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['getModelConfig'][0])
    {
        list($response) = $this->getModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_key, $contentType);
        return $response;
    }

    /**
     * Operation getModelConfigWithHttpInfo
     *
     * Get AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\ModelConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function getModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['getModelConfig'][0])
    {
        $request = $this->getModelConfigRequest($ld_api_version, $project_key, $model_config_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\ModelConfig' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\ModelConfig' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\ModelConfig', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\ModelConfig';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\ModelConfig',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation getModelConfigAsync
     *
     * Get AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getModelConfigAsync($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['getModelConfig'][0])
    {
        return $this->getModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation getModelConfigAsyncWithHttpInfo
     *
     * Get AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function getModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['getModelConfig'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\ModelConfig';
        $request = $this->getModelConfigRequest($ld_api_version, $project_key, $model_config_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'getModelConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $model_config_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['getModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function getModelConfigRequest($ld_api_version, $project_key, $model_config_key, string $contentType = self::contentTypes['getModelConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling getModelConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling getModelConfig'
            );
        }

        // verify the required parameter 'model_config_key' is set
        if ($model_config_key === null || (is_array($model_config_key) && count($model_config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $model_config_key when calling getModelConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($model_config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'modelConfigKey' . '}',
                ObjectSerializer::toPathValue($model_config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation listModelConfigs
     *
     * List AI model configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['listModelConfigs'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\ModelConfig[]|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function listModelConfigs($ld_api_version, $project_key, string $contentType = self::contentTypes['listModelConfigs'][0])
    {
        list($response) = $this->listModelConfigsWithHttpInfo($ld_api_version, $project_key, $contentType);
        return $response;
    }

    /**
     * Operation listModelConfigsWithHttpInfo
     *
     * List AI model configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['listModelConfigs'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\ModelConfig[]|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function listModelConfigsWithHttpInfo($ld_api_version, $project_key, string $contentType = self::contentTypes['listModelConfigs'][0])
    {
        $request = $this->listModelConfigsRequest($ld_api_version, $project_key, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\ModelConfig[]' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\ModelConfig[]' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\ModelConfig[]', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\ModelConfig[]';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\ModelConfig[]',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation listModelConfigsAsync
     *
     * List AI model configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['listModelConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function listModelConfigsAsync($ld_api_version, $project_key, string $contentType = self::contentTypes['listModelConfigs'][0])
    {
        return $this->listModelConfigsAsyncWithHttpInfo($ld_api_version, $project_key, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation listModelConfigsAsyncWithHttpInfo
     *
     * List AI model configs
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['listModelConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function listModelConfigsAsyncWithHttpInfo($ld_api_version, $project_key, string $contentType = self::contentTypes['listModelConfigs'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\ModelConfig[]';
        $request = $this->listModelConfigsRequest($ld_api_version, $project_key, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'listModelConfigs'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['listModelConfigs'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function listModelConfigsRequest($ld_api_version, $project_key, string $contentType = self::contentTypes['listModelConfigs'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling listModelConfigs'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling listModelConfigs'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/model-configs';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'GET',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation patchAIConfig
     *
     * Update AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPatch|null $ai_config_patch AI config object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function patchAIConfig($ld_api_version, $project_key, $config_key, $ai_config_patch = null, string $contentType = self::contentTypes['patchAIConfig'][0])
    {
        list($response) = $this->patchAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_patch, $contentType);
        return $response;
    }

    /**
     * Operation patchAIConfigWithHttpInfo
     *
     * Update AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPatch|null $ai_config_patch AI config object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function patchAIConfigWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_patch = null, string $contentType = self::contentTypes['patchAIConfig'][0])
    {
        $request = $this->patchAIConfigRequest($ld_api_version, $project_key, $config_key, $ai_config_patch, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\AIConfig' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfig' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfig', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfig';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfig',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation patchAIConfigAsync
     *
     * Update AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPatch|null $ai_config_patch AI config object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function patchAIConfigAsync($ld_api_version, $project_key, $config_key, $ai_config_patch = null, string $contentType = self::contentTypes['patchAIConfig'][0])
    {
        return $this->patchAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_patch, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation patchAIConfigAsyncWithHttpInfo
     *
     * Update AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPatch|null $ai_config_patch AI config object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function patchAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_patch = null, string $contentType = self::contentTypes['patchAIConfig'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfig';
        $request = $this->patchAIConfigRequest($ld_api_version, $project_key, $config_key, $ai_config_patch, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'patchAIConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPatch|null $ai_config_patch AI config object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function patchAIConfigRequest($ld_api_version, $project_key, $config_key, $ai_config_patch = null, string $contentType = self::contentTypes['patchAIConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling patchAIConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling patchAIConfig'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling patchAIConfig'
            );
        }



        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (isset($ai_config_patch)) {
            if (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the body
                $httpBody = \GuzzleHttp\Utils::jsonEncode(ObjectSerializer::sanitizeForSerialization($ai_config_patch));
            } else {
                $httpBody = $ai_config_patch;
            }
        } elseif (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'PATCH',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation patchAIConfigVariation
     *
     * Update AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  string $variation_key variation_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPatch|null $ai_config_variation_patch AI config variation object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfigVariation|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function patchAIConfigVariation($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch = null, string $contentType = self::contentTypes['patchAIConfigVariation'][0])
    {
        list($response) = $this->patchAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch, $contentType);
        return $response;
    }

    /**
     * Operation patchAIConfigVariationWithHttpInfo
     *
     * Update AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPatch|null $ai_config_variation_patch AI config variation object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfigVariation|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function patchAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch = null, string $contentType = self::contentTypes['patchAIConfigVariation'][0])
    {
        $request = $this->patchAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\AIConfigVariation' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfigVariation' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfigVariation', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfigVariation';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfigVariation',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation patchAIConfigVariationAsync
     *
     * Update AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPatch|null $ai_config_variation_patch AI config variation object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function patchAIConfigVariationAsync($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch = null, string $contentType = self::contentTypes['patchAIConfigVariation'][0])
    {
        return $this->patchAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation patchAIConfigVariationAsyncWithHttpInfo
     *
     * Update AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPatch|null $ai_config_variation_patch AI config variation object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function patchAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch = null, string $contentType = self::contentTypes['patchAIConfigVariation'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfigVariation';
        $request = $this->patchAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'patchAIConfigVariation'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  string $variation_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPatch|null $ai_config_variation_patch AI config variation object to update (optional)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['patchAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function patchAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $variation_key, $ai_config_variation_patch = null, string $contentType = self::contentTypes['patchAIConfigVariation'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling patchAIConfigVariation'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling patchAIConfigVariation'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling patchAIConfigVariation'
            );
        }

        // verify the required parameter 'variation_key' is set
        if ($variation_key === null || (is_array($variation_key) && count($variation_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $variation_key when calling patchAIConfigVariation'
            );
        }



        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey}';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }
        // path params
        if ($variation_key !== null) {
            $resourcePath = str_replace(
                '{' . 'variationKey' . '}',
                ObjectSerializer::toPathValue($variation_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (isset($ai_config_variation_patch)) {
            if (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the body
                $httpBody = \GuzzleHttp\Utils::jsonEncode(ObjectSerializer::sanitizeForSerialization($ai_config_variation_patch));
            } else {
                $httpBody = $ai_config_variation_patch;
            }
        } elseif (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'PATCH',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation postAIConfig
     *
     * Create new AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPost $ai_config_post AI config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function postAIConfig($ld_api_version, $project_key, $ai_config_post, string $contentType = self::contentTypes['postAIConfig'][0])
    {
        list($response) = $this->postAIConfigWithHttpInfo($ld_api_version, $project_key, $ai_config_post, $contentType);
        return $response;
    }

    /**
     * Operation postAIConfigWithHttpInfo
     *
     * Create new AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPost $ai_config_post AI config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function postAIConfigWithHttpInfo($ld_api_version, $project_key, $ai_config_post, string $contentType = self::contentTypes['postAIConfig'][0])
    {
        $request = $this->postAIConfigRequest($ld_api_version, $project_key, $ai_config_post, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 201:
                    if ('\LaunchDarkly\Client\Model\AIConfig' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfig' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfig', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfig';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 201:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfig',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation postAIConfigAsync
     *
     * Create new AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPost $ai_config_post AI config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postAIConfigAsync($ld_api_version, $project_key, $ai_config_post, string $contentType = self::contentTypes['postAIConfig'][0])
    {
        return $this->postAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $ai_config_post, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation postAIConfigAsyncWithHttpInfo
     *
     * Create new AI config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPost $ai_config_post AI config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postAIConfigAsyncWithHttpInfo($ld_api_version, $project_key, $ai_config_post, string $contentType = self::contentTypes['postAIConfig'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfig';
        $request = $this->postAIConfigRequest($ld_api_version, $project_key, $ai_config_post, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'postAIConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigPost $ai_config_post AI config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function postAIConfigRequest($ld_api_version, $project_key, $ai_config_post, string $contentType = self::contentTypes['postAIConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling postAIConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling postAIConfig'
            );
        }

        // verify the required parameter 'ai_config_post' is set
        if ($ai_config_post === null || (is_array($ai_config_post) && count($ai_config_post) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ai_config_post when calling postAIConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (isset($ai_config_post)) {
            if (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the body
                $httpBody = \GuzzleHttp\Utils::jsonEncode(ObjectSerializer::sanitizeForSerialization($ai_config_post));
            } else {
                $httpBody = $ai_config_post;
            }
        } elseif (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'POST',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation postAIConfigVariation
     *
     * Create AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  string $config_key config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPost $ai_config_variation_post AI config variation object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\AIConfigVariation|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function postAIConfigVariation($ld_api_version, $project_key, $config_key, $ai_config_variation_post, string $contentType = self::contentTypes['postAIConfigVariation'][0])
    {
        list($response) = $this->postAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_variation_post, $contentType);
        return $response;
    }

    /**
     * Operation postAIConfigVariationWithHttpInfo
     *
     * Create AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPost $ai_config_variation_post AI config variation object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\AIConfigVariation|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function postAIConfigVariationWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_variation_post, string $contentType = self::contentTypes['postAIConfigVariation'][0])
    {
        $request = $this->postAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $ai_config_variation_post, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 201:
                    if ('\LaunchDarkly\Client\Model\AIConfigVariation' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\AIConfigVariation' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\AIConfigVariation', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\AIConfigVariation';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 201:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\AIConfigVariation',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation postAIConfigVariationAsync
     *
     * Create AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPost $ai_config_variation_post AI config variation object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postAIConfigVariationAsync($ld_api_version, $project_key, $config_key, $ai_config_variation_post, string $contentType = self::contentTypes['postAIConfigVariation'][0])
    {
        return $this->postAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_variation_post, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation postAIConfigVariationAsyncWithHttpInfo
     *
     * Create AI config variation
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPost $ai_config_variation_post AI config variation object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postAIConfigVariationAsyncWithHttpInfo($ld_api_version, $project_key, $config_key, $ai_config_variation_post, string $contentType = self::contentTypes['postAIConfigVariation'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\AIConfigVariation';
        $request = $this->postAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $ai_config_variation_post, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'postAIConfigVariation'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  string $config_key (required)
     * @param  \LaunchDarkly\Client\Model\AIConfigVariationPost $ai_config_variation_post AI config variation object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postAIConfigVariation'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function postAIConfigVariationRequest($ld_api_version, $project_key, $config_key, $ai_config_variation_post, string $contentType = self::contentTypes['postAIConfigVariation'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling postAIConfigVariation'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling postAIConfigVariation'
            );
        }

        // verify the required parameter 'config_key' is set
        if ($config_key === null || (is_array($config_key) && count($config_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $config_key when calling postAIConfigVariation'
            );
        }

        // verify the required parameter 'ai_config_variation_post' is set
        if ($ai_config_variation_post === null || (is_array($ai_config_variation_post) && count($ai_config_variation_post) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ai_config_variation_post when calling postAIConfigVariation'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/{configKey}/variations';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }
        // path params
        if ($config_key !== null) {
            $resourcePath = str_replace(
                '{' . 'configKey' . '}',
                ObjectSerializer::toPathValue($config_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (isset($ai_config_variation_post)) {
            if (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the body
                $httpBody = \GuzzleHttp\Utils::jsonEncode(ObjectSerializer::sanitizeForSerialization($ai_config_variation_post));
            } else {
                $httpBody = $ai_config_variation_post;
            }
        } elseif (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'POST',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Operation postModelConfig
     *
     * Create an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key project_key (required)
     * @param  \LaunchDarkly\Client\Model\ModelConfigPost $model_config_post AI model config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return \LaunchDarkly\Client\Model\ModelConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error
     */
    public function postModelConfig($ld_api_version, $project_key, $model_config_post, string $contentType = self::contentTypes['postModelConfig'][0])
    {
        list($response) = $this->postModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_post, $contentType);
        return $response;
    }

    /**
     * Operation postModelConfigWithHttpInfo
     *
     * Create an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\ModelConfigPost $model_config_post AI model config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postModelConfig'] to see the possible values for this operation
     *
     * @throws \LaunchDarkly\Client\ApiException on non-2xx response or if the response body is not in the expected format
     * @throws \InvalidArgumentException
     * @return array of \LaunchDarkly\Client\Model\ModelConfig|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error|\LaunchDarkly\Client\Model\Error, HTTP status code, HTTP response headers (array of strings)
     */
    public function postModelConfigWithHttpInfo($ld_api_version, $project_key, $model_config_post, string $contentType = self::contentTypes['postModelConfig'][0])
    {
        $request = $this->postModelConfigRequest($ld_api_version, $project_key, $model_config_post, $contentType);

        try {
            $options = $this->createHttpClientOption();
            try {
                $response = $this->client->send($request, $options);
            } catch (RequestException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    $e->getResponse() ? $e->getResponse()->getHeaders() : null,
                    $e->getResponse() ? (string) $e->getResponse()->getBody() : null
                );
            } catch (ConnectException $e) {
                throw new ApiException(
                    "[{$e->getCode()}] {$e->getMessage()}",
                    (int) $e->getCode(),
                    null,
                    null
                );
            }

            $statusCode = $response->getStatusCode();


            switch($statusCode) {
                case 200:
                    if ('\LaunchDarkly\Client\Model\ModelConfig' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\ModelConfig' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\ModelConfig', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 400:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 403:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 404:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                case 500:
                    if ('\LaunchDarkly\Client\Model\Error' === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ('\LaunchDarkly\Client\Model\Error' !== 'string') {
                            try {
                                $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                            } catch (\JsonException $exception) {
                                throw new ApiException(
                                    sprintf(
                                        'Error JSON decoding server response (%s)',
                                        $request->getUri()
                                    ),
                                    $statusCode,
                                    $response->getHeaders(),
                                    $content
                                );
                            }
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, '\LaunchDarkly\Client\Model\Error', []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
            }

            if ($statusCode < 200 || $statusCode > 299) {
                throw new ApiException(
                    sprintf(
                        '[%d] Error connecting to the API (%s)',
                        $statusCode,
                        (string) $request->getUri()
                    ),
                    $statusCode,
                    $response->getHeaders(),
                    (string) $response->getBody()
                );
            }

            $returnType = '\LaunchDarkly\Client\Model\ModelConfig';
            if ($returnType === '\SplFileObject') {
                $content = $response->getBody(); //stream goes to serializer
            } else {
                $content = (string) $response->getBody();
                if ($returnType !== 'string') {
                    try {
                        $content = json_decode($content, false, 512, JSON_THROW_ON_ERROR);
                    } catch (\JsonException $exception) {
                        throw new ApiException(
                            sprintf(
                                'Error JSON decoding server response (%s)',
                                $request->getUri()
                            ),
                            $statusCode,
                            $response->getHeaders(),
                            $content
                        );
                    }
                }
            }

            return [
                ObjectSerializer::deserialize($content, $returnType, []),
                $response->getStatusCode(),
                $response->getHeaders()
            ];

        } catch (ApiException $e) {
            switch ($e->getCode()) {
                case 200:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\ModelConfig',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 400:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 403:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 404:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
                case 500:
                    $data = ObjectSerializer::deserialize(
                        $e->getResponseBody(),
                        '\LaunchDarkly\Client\Model\Error',
                        $e->getResponseHeaders()
                    );
                    $e->setResponseObject($data);
                    break;
            }
            throw $e;
        }
    }

    /**
     * Operation postModelConfigAsync
     *
     * Create an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\ModelConfigPost $model_config_post AI model config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postModelConfigAsync($ld_api_version, $project_key, $model_config_post, string $contentType = self::contentTypes['postModelConfig'][0])
    {
        return $this->postModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_post, $contentType)
            ->then(
                function ($response) {
                    return $response[0];
                }
            );
    }

    /**
     * Operation postModelConfigAsyncWithHttpInfo
     *
     * Create an AI model config
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\ModelConfigPost $model_config_post AI model config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Promise\PromiseInterface
     */
    public function postModelConfigAsyncWithHttpInfo($ld_api_version, $project_key, $model_config_post, string $contentType = self::contentTypes['postModelConfig'][0])
    {
        $returnType = '\LaunchDarkly\Client\Model\ModelConfig';
        $request = $this->postModelConfigRequest($ld_api_version, $project_key, $model_config_post, $contentType);

        return $this->client
            ->sendAsync($request, $this->createHttpClientOption())
            ->then(
                function ($response) use ($returnType) {
                    if ($returnType === '\SplFileObject') {
                        $content = $response->getBody(); //stream goes to serializer
                    } else {
                        $content = (string) $response->getBody();
                        if ($returnType !== 'string') {
                            $content = json_decode($content);
                        }
                    }

                    return [
                        ObjectSerializer::deserialize($content, $returnType, []),
                        $response->getStatusCode(),
                        $response->getHeaders()
                    ];
                },
                function ($exception) {
                    $response = $exception->getResponse();
                    $statusCode = $response->getStatusCode();
                    throw new ApiException(
                        sprintf(
                            '[%d] Error connecting to the API (%s)',
                            $statusCode,
                            $exception->getRequest()->getUri()
                        ),
                        $statusCode,
                        $response->getHeaders(),
                        (string) $response->getBody()
                    );
                }
            );
    }

    /**
     * Create request for operation 'postModelConfig'
     *
     * @param  string $ld_api_version Version of the endpoint. (required)
     * @param  string $project_key (required)
     * @param  \LaunchDarkly\Client\Model\ModelConfigPost $model_config_post AI model config object to create (required)
     * @param  string $contentType The value for the Content-Type header. Check self::contentTypes['postModelConfig'] to see the possible values for this operation
     *
     * @throws \InvalidArgumentException
     * @return \GuzzleHttp\Psr7\Request
     */
    public function postModelConfigRequest($ld_api_version, $project_key, $model_config_post, string $contentType = self::contentTypes['postModelConfig'][0])
    {

        // verify the required parameter 'ld_api_version' is set
        if ($ld_api_version === null || (is_array($ld_api_version) && count($ld_api_version) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $ld_api_version when calling postModelConfig'
            );
        }

        // verify the required parameter 'project_key' is set
        if ($project_key === null || (is_array($project_key) && count($project_key) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $project_key when calling postModelConfig'
            );
        }

        // verify the required parameter 'model_config_post' is set
        if ($model_config_post === null || (is_array($model_config_post) && count($model_config_post) === 0)) {
            throw new \InvalidArgumentException(
                'Missing the required parameter $model_config_post when calling postModelConfig'
            );
        }


        $resourcePath = '/api/v2/projects/{projectKey}/ai-configs/model-configs';
        $formParams = [];
        $queryParams = [];
        $headerParams = [];
        $httpBody = '';
        $multipart = false;


        // header params
        if ($ld_api_version !== null) {
            $headerParams['LD-API-Version'] = ObjectSerializer::toHeaderValue($ld_api_version);
        }

        // path params
        if ($project_key !== null) {
            $resourcePath = str_replace(
                '{' . 'projectKey' . '}',
                ObjectSerializer::toPathValue($project_key),
                $resourcePath
            );
        }


        $headers = $this->headerSelector->selectHeaders(
            ['application/json', ],
            $contentType,
            $multipart
        );

        // for model (json/xml)
        if (isset($model_config_post)) {
            if (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the body
                $httpBody = \GuzzleHttp\Utils::jsonEncode(ObjectSerializer::sanitizeForSerialization($model_config_post));
            } else {
                $httpBody = $model_config_post;
            }
        } elseif (count($formParams) > 0) {
            if ($multipart) {
                $multipartContents = [];
                foreach ($formParams as $formParamName => $formParamValue) {
                    $formParamValueItems = is_array($formParamValue) ? $formParamValue : [$formParamValue];
                    foreach ($formParamValueItems as $formParamValueItem) {
                        $multipartContents[] = [
                            'name' => $formParamName,
                            'contents' => $formParamValueItem
                        ];
                    }
                }
                // for HTTP post (form)
                $httpBody = new MultipartStream($multipartContents);

            } elseif (stripos($headers['Content-Type'], 'application/json') !== false) {
                # if Content-Type contains "application/json", json_encode the form parameters
                $httpBody = \GuzzleHttp\Utils::jsonEncode($formParams);
            } else {
                // for HTTP post (form)
                $httpBody = ObjectSerializer::buildQuery($formParams);
            }
        }

        // this endpoint requires API key authentication
        $apiKey = $this->config->getApiKeyWithPrefix('Authorization');
        if ($apiKey !== null) {
            $headers['Authorization'] = $apiKey;
        }

        $defaultHeaders = [];
        if ($this->config->getUserAgent()) {
            $defaultHeaders['User-Agent'] = $this->config->getUserAgent();
        }

        $headers = array_merge(
            $defaultHeaders,
            $headerParams,
            $headers
        );

        $operationHost = $this->config->getHost();
        $query = ObjectSerializer::buildQuery($queryParams);
        return new Request(
            'POST',
            $operationHost . $resourcePath . ($query ? "?{$query}" : ''),
            $headers,
            $httpBody
        );
    }

    /**
     * Create http client option
     *
     * @throws \RuntimeException on file opening failure
     * @return array of http client options
     */
    protected function createHttpClientOption()
    {
        $options = [];
        if ($this->config->getDebug()) {
            $options[RequestOptions::DEBUG] = fopen($this->config->getDebugFile(), 'a');
            if (!$options[RequestOptions::DEBUG]) {
                throw new \RuntimeException('Failed to open the debug file: ' . $this->config->getDebugFile());
            }
        }

        return $options;
    }
}
