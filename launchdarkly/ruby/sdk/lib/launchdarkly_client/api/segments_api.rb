=begin
#LaunchDarkly REST API

## Overview  ## Authentication  LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.  All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.  LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.  | Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          | | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | -------------------------------------------------- | | [Personal or service access tokens](https://docs.launchdarkly.com/home/account/api) | Can be customized on a per-token basis                                                                | Building scripts, custom integrations, data export. | | SDK keys                                                                                        | Can only access read-only resources specific to server-side SDKs. Restricted to a single environment. | Server-side SDKs                     | | Mobile keys                                                                                     | Can only access read-only resources specific to mobile SDKs, and only for flags marked available to mobile keys. Restricted to a single environment.           | Mobile SDKs                                        | | Client-side ID                                                                                  | Can only access read-only resources specific to JavaScript-based client-side SDKs, and only for flags marked available to client-side. Restricted to a single environment.           | Client-side JavaScript                             |  > #### Keep your access tokens and SDK keys private > > Access tokens should _never_ be exposed in untrusted contexts. Never put an access token in client-side JavaScript, or embed it in a mobile application. LaunchDarkly has special mobile keys that you can embed in mobile apps. If you accidentally expose an access token or SDK key, you can reset it from your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page. > > The client-side ID is safe to embed in untrusted contexts. It's designed for use in client-side JavaScript.  ### Authentication using request header  The preferred way to authenticate with the API is by adding an `Authorization` header containing your access token to your requests. The value of the `Authorization` header must be your access token.  Manage personal access tokens from the [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.  ### Authentication using session cookie  For testing purposes, you can make API calls directly from your web browser. If you are logged in to the LaunchDarkly application, the API will use your existing session to authenticate calls.  If you have a [role](https://docs.launchdarkly.com/home/account/built-in-roles) other than Admin, or have a [custom role](https://docs.launchdarkly.com/home/account/custom-roles) defined, you may not have permission to perform some API calls. You will receive a `401` response code in that case.  > ### Modifying the Origin header causes an error > > LaunchDarkly validates that the Origin header for any API request authenticated by a session cookie matches the expected Origin header. The expected Origin header is `https://app.launchdarkly.com`. > > If the Origin header does not match what's expected, LaunchDarkly returns an error. This error can prevent the LaunchDarkly app from working correctly. > > Any browser extension that intentionally changes the Origin header can cause this problem. For example, the `Allow-Control-Allow-Origin: *` Chrome extension changes the Origin header to `http://evil.com` and causes the app to fail. > > To prevent this error, do not modify your Origin header. > > LaunchDarkly does not require origin matching when authenticating with an access token, so this issue does not affect normal API usage.  ## Representations  All resources expect and return JSON response bodies. Error responses also send a JSON body. To learn more about the error format of the API, read [Errors](/#section/Overview/Errors).  In practice this means that you always get a response with a `Content-Type` header set to `application/json`.  In addition, request bodies for `PATCH`, `POST`, and `PUT` requests must be encoded as JSON with a `Content-Type` header set to `application/json`.  ### Summary and detailed representations  When you fetch a list of resources, the response includes only the most important attributes of each resource. This is a _summary representation_ of the resource. When you fetch an individual resource, such as a single feature flag, you receive a _detailed representation_ of the resource.  The best way to find a detailed representation is to follow links. Every summary representation includes a link to its detailed representation.  ### Expanding responses  Sometimes the detailed representation of a resource does not include all of the attributes of the resource by default. If this is the case, the request method will clearly document this and describe which attributes you can include in an expanded response.  To include the additional attributes, append the `expand` request parameter to your request and add a comma-separated list of the attributes to include. For example, when you append `?expand=members,maintainers` to the [Get team](/tag/Teams#operation/getTeam) endpoint, the expanded response includes both of these attributes.  ### Links and addressability  The best way to navigate the API is by following links. These are attributes in representations that link to other resources. The API always uses the same format for links:  - Links to other resources within the API are encapsulated in a `_links` object - If the resource has a corresponding link to HTML content on the site, it is stored in a special `_site` link  Each link has two attributes:  - An `href`, which contains the URL - A `type`, which describes the content type  For example, a feature resource might return the following:  ```json {   \"_links\": {     \"parent\": {       \"href\": \"/api/features\",       \"type\": \"application/json\"     },     \"self\": {       \"href\": \"/api/features/sort.order\",       \"type\": \"application/json\"     }   },   \"_site\": {     \"href\": \"/features/sort.order\",     \"type\": \"text/html\"   } } ```  From this, you can navigate to the parent collection of features by following the `parent` link, or navigate to the site page for the feature by following the `_site` link.  Collections are always represented as a JSON object with an `items` attribute containing an array of representations. Like all other representations, collections have `_links` defined at the top level.  Paginated collections include `first`, `last`, `next`, and `prev` links containing a URL with the respective set of elements in the collection.  ## Updates  Resources that accept partial updates use the `PATCH` verb. Most resources support the [JSON patch](/reference#updates-using-json-patch) format. Some resources also support the [JSON merge patch](/reference#updates-using-json-merge-patch) format, and some resources support the [semantic patch](/reference#updates-using-semantic-patch) format, which is a way to specify the modifications to perform as a set of executable instructions. Each resource supports optional [comments](/reference#updates-with-comments) that you can submit with updates. Comments appear in outgoing webhooks, the audit log, and other integrations.  When a resource supports both JSON patch and semantic patch, we document both in the request method. However, the specific request body fields and descriptions included in our documentation only match one type of patch or the other.  ### Updates using JSON patch  [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) is a way to specify the modifications to perform on a resource. JSON patch uses paths and a limited set of operations to describe how to transform the current state of the resource into a new state. JSON patch documents are always arrays, where each element contains an operation, a path to the field to update, and the new value.  For example, in this feature flag representation:  ```json {     \"name\": \"New recommendations engine\",     \"key\": \"engine.enable\",     \"description\": \"This is the description\",     ... } ``` You can change the feature flag's description with the following patch document:  ```json [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"This is the new description\" }] ```  You can specify multiple modifications to perform in a single request. You can also test that certain preconditions are met before applying the patch:  ```json [   { \"op\": \"test\", \"path\": \"/version\", \"value\": 10 },   { \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" } ] ```  The above patch request tests whether the feature flag's `version` is `10`, and if so, changes the feature flag's description.  Attributes that are not editable, such as a resource's `_links`, have names that start with an underscore.  ### Updates using JSON merge patch  [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) is another format for specifying the modifications to perform on a resource. JSON merge patch is less expressive than JSON patch. However, in many cases it is simpler to construct a merge patch document. For example, you can change a feature flag's description with the following merge patch document:  ```json {   \"description\": \"New flag description\" } ```  ### Updates using semantic patch  Some resources support the semantic patch format. A semantic patch is a way to specify the modifications to perform on a resource as a set of executable instructions.  Semantic patch allows you to be explicit about intent using precise, custom instructions. In many cases, you can define semantic patch instructions independently of the current state of the resource. This can be useful when defining a change that may be applied at a future date.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header.  Here's how:  ``` Content-Type: application/json; domain-model=launchdarkly.semanticpatch ```  If you call a semantic patch resource without this header, you will receive a `400` response because your semantic patch will be interpreted as a JSON patch.  The body of a semantic patch request takes the following properties:  * `comment` (string): (Optional) A description of the update. * `environmentKey` (string): (Required for some resources only) The environment key. * `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the instruction requires parameters, you must include those parameters as additional fields in the object. The documentation for each resource that supports semantic patch includes the available instructions and any additional parameters.  For example:  ```json {   \"comment\": \"optional comment\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  Semantic patches are not applied partially; either all of the instructions are applied or none of them are. If **any** instruction is invalid, the endpoint returns an error and will not change the resource. If all instructions are valid, the request succeeds and the resources are updated if necessary, or left unchanged if they are already in the state you request.  ### Updates with comments  You can submit optional comments with `PATCH` changes.  To submit a comment along with a JSON patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"patch\": [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }] } ```  To submit a comment along with a JSON merge patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"merge\": { \"description\": \"New flag description\" } } ```  To submit a comment along with a semantic patch, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  ## Errors  The API always returns errors in a common format. Here's an example:  ```json {   \"code\": \"invalid_request\",   \"message\": \"A feature with that key already exists\",   \"id\": \"30ce6058-87da-11e4-b116-123b93f75cba\" } ```  The `code` indicates the general class of error. The `message` is a human-readable explanation of what went wrong. The `id` is a unique identifier. Use it when you're working with LaunchDarkly Support to debug a problem with a specific API call.  ### HTTP status error response codes  | Code | Definition        | Description                                                                                       | Possible Solution                                                | | ---- | ----------------- | ------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- | | 400  | Invalid request       | The request cannot be understood.                                    | Ensure JSON syntax in request body is correct.                   | | 401  | Invalid access token      | Requestor is unauthorized or does not have permission for this API call.                                                | Ensure your API access token is valid and has the appropriate permissions.                                     | | 403  | Forbidden         | Requestor does not have access to this resource.                                                | Ensure that the account member or access token has proper permissions set. | | 404  | Invalid resource identifier | The requested resource is not valid. | Ensure that the resource is correctly identified by ID or key. | | 405  | Method not allowed | The request method is not allowed on this resource. | Ensure that the HTTP verb is correct. | | 409  | Conflict          | The API request can not be completed because it conflicts with a concurrent API request. | Retry your request.                                              | | 422  | Unprocessable entity | The API request can not be completed because the update description can not be understood. | Ensure that the request body is correct for the type of patch you are using, either JSON patch or semantic patch. | 429  | Too many requests | Read [Rate limiting](/#section/Overview/Rate-limiting).                                               | Wait and try again later.                                        |  ## CORS  The LaunchDarkly API supports Cross Origin Resource Sharing (CORS) for AJAX requests from any origin. If an `Origin` header is given in a request, it will be echoed as an explicitly allowed origin. Otherwise the request returns a wildcard, `Access-Control-Allow-Origin: *`. For more information on CORS, read the [CORS W3C Recommendation](http://www.w3.org/TR/cors). Example CORS headers might look like:  ```http Access-Control-Allow-Headers: Accept, Content-Type, Content-Length, Accept-Encoding, Authorization Access-Control-Allow-Methods: OPTIONS, GET, DELETE, PATCH Access-Control-Allow-Origin: * Access-Control-Max-Age: 300 ```  You can make authenticated CORS calls just as you would make same-origin calls, using either [token or session-based authentication](/#section/Overview/Authentication). If you are using session authentication, you should set the `withCredentials` property for your `xhr` request to `true`. You should never expose your access tokens to untrusted entities.  ## Rate limiting  We use several rate limiting strategies to ensure the availability of our APIs. Rate-limited calls to our APIs return a `429` status code. Calls to our APIs include headers indicating the current rate limit status. The specific headers returned depend on the API route being called. The limits differ based on the route, authentication mechanism, and other factors. Routes that are not rate limited may not contain any of the headers described below.  > ### Rate limiting and SDKs > > LaunchDarkly SDKs are never rate limited and do not use the API endpoints defined here. LaunchDarkly uses a different set of approaches, including streaming/server-sent events and a global CDN, to ensure availability to the routes used by LaunchDarkly SDKs.  ### Global rate limits  Authenticated requests are subject to a global limit. This is the maximum number of calls that your account can make to the API per ten seconds. All service and personal access tokens on the account share this limit, so exceeding the limit with one access token will impact other tokens. Calls that are subject to global rate limits may return the headers below:  | Header name                    | Description                                                                      | | ------------------------------ | -------------------------------------------------------------------------------- | | `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |  We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.  ### Route-level rate limits  Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:  | Header name                   | Description                                                                                           | | ----------------------------- | ----------------------------------------------------------------------------------------------------- | | `X-Ratelimit-Route-Remaining` | The maximum number of requests to the current route the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`           | The time at which the current rate limit window resets in epoch milliseconds.                         |  A _route_ represents a specific URL pattern and verb. For example, the [Delete environment](/tag/Environments#operation/deleteEnvironment) endpoint is considered a single route, and each call to delete an environment counts against your route-level rate limit for that route.  We do not publicly document the specific number of calls that an account can make to each endpoint per ten seconds. These limits may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limits.  ### IP-based rate limiting  We also employ IP-based rate limiting on some API routes. If you hit an IP-based rate limit, your API response will include a `Retry-After` header indicating how long to wait before re-trying the call. Clients must wait at least `Retry-After` seconds before making additional calls to our API, and should employ jitter and backoff strategies to avoid triggering rate limits again.  ## OpenAPI (Swagger) and client libraries  We have a [complete OpenAPI (Swagger) specification](https://app.launchdarkly.com/api/v2/openapi.json) for our API.  We auto-generate multiple client libraries based on our OpenAPI specification. To learn more, visit the [collection of client libraries on GitHub](https://github.com/search?q=topic%3Alaunchdarkly-api+org%3Alaunchdarkly&type=Repositories). You can also use this specification to generate client libraries to interact with our REST API in your language of choice.  Our OpenAPI specification is supported by several API-based tools such as Postman and Insomnia. In many cases, you can directly import our specification to explore our APIs.  ## Method overriding  Some firewalls and HTTP clients restrict the use of verbs other than `GET` and `POST`. In those environments, our API endpoints that use `DELETE`, `PATCH`, and `PUT` verbs are inaccessible.  To avoid this issue, our API supports the `X-HTTP-Method-Override` header, allowing clients to \"tunnel\" `DELETE`, `PATCH`, and `PUT` requests using a `POST` request.  For example, to call a `PATCH` endpoint using a `POST` request, you can include `X-HTTP-Method-Override:PATCH` as a header.  ## Beta resources  We sometimes release new API resources in **beta** status before we release them with general availability.  Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  We try to promote resources into general availability as quickly as possible. This happens after sufficient testing and when we're satisfied that we no longer need to make backwards-incompatible changes.  We mark beta resources with a \"Beta\" callout in our documentation, pictured below:  > ### This feature is in beta > > To use this feature, pass in a header including the `LD-API-Version` key with value set to `beta`. Use this header with each call. To learn more, read [Beta resources](/#section/Overview/Beta-resources). > > Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  ### Using beta resources  To use a beta resource, you must include a header in the request. If you call a beta resource without this header, you receive a `403` response.  Use this header:  ``` LD-API-Version: beta ```  ## Federal environments  The version of LaunchDarkly that is available on domains controlled by the United States government is different from the version of LaunchDarkly available to the general public. If you are an employee or contractor for a United States federal agency and use LaunchDarkly in your work, you likely use the federal instance of LaunchDarkly.  If you are working in the federal instance of LaunchDarkly, the base URI for each request is `https://app.launchdarkly.us`. In the \"Try it\" sandbox for each request, click the request path to view the complete resource path for the federal environment.  To learn more, read [LaunchDarkly in federal environments](https://docs.launchdarkly.com/home/infrastructure/federal).  ## Versioning  We try hard to keep our REST API backwards compatible, but we occasionally have to make backwards-incompatible changes in the process of shipping new features. These breaking changes can cause unexpected behavior if you don't prepare for them accordingly.  Updates to our REST API include support for the latest features in LaunchDarkly. We also release a new version of our REST API every time we make a breaking change. We provide simultaneous support for multiple API versions so you can migrate from your current API version to a new version at your own pace.  ### Setting the API version per request  You can set the API version on a specific request by sending an `LD-API-Version` header, as shown in the example below:  ``` LD-API-Version: 20240415 ```  The header value is the version number of the API version you would like to request. The number for each version corresponds to the date the version was released in `yyyymmdd` format. In the example above the version `20240415` corresponds to April 15, 2024.  ### Setting the API version per access token  When you create an access token, you must specify a specific version of the API to use. This ensures that integrations using this token cannot be broken by version changes.  Tokens created before versioning was released have their version set to `20160426`, which is the version of the API that existed before the current versioning scheme, so that they continue working the same way they did before versioning.  If you would like to upgrade your integration to use a new API version, you can explicitly set the header described above.  > ### Best practice: Set the header for every client or integration > > We recommend that you set the API version header explicitly in any client or integration you build. > > Only rely on the access token API version during manual testing.  ### API version changelog  |<div style=\"width:75px\">Version</div> | Changes | End of life (EOL) |---|---|---| | `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current | | `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 | | `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 | | `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 | | `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |  To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/). 

The version of the OpenAPI document: 2.0
Contact: support@launchdarkly.com
Generated by: https://openapi-generator.tech
Generator version: 7.11.0

=end

require 'cgi'

module LaunchDarklyClient
  class SegmentsApi
    attr_accessor :api_client

    def initialize(api_client = ApiClient.default)
      @api_client = api_client
    end
    # Create big segment export
    # Starts a new export process for a big segment. This is an export for a synced segment or a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [nil]
    def create_big_segment_export(project_key, environment_key, segment_key, opts = {})
      create_big_segment_export_with_http_info(project_key, environment_key, segment_key, opts)
      nil
    end

    # Create big segment export
    # Starts a new export process for a big segment. This is an export for a synced segment or a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [Array<(nil, Integer, Hash)>] nil, response status code and response headers
    def create_big_segment_export_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.create_big_segment_export ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.create_big_segment_export"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.create_big_segment_export"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.create_big_segment_export"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type]

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.create_big_segment_export",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#create_big_segment_export\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Create big segment import
    # Start a new import process for a big segment. This is an import for a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @option opts [File] :file CSV file containing keys
    # @option opts [String] :mode Import mode. Use either &#x60;merge&#x60; or &#x60;replace&#x60;
    # @option opts [Boolean] :wait_on_approvals Whether to wait for approvals before processing the import
    # @return [nil]
    def create_big_segment_import(project_key, environment_key, segment_key, opts = {})
      create_big_segment_import_with_http_info(project_key, environment_key, segment_key, opts)
      nil
    end

    # Create big segment import
    # Start a new import process for a big segment. This is an import for a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @option opts [File] :file CSV file containing keys
    # @option opts [String] :mode Import mode. Use either &#x60;merge&#x60; or &#x60;replace&#x60;
    # @option opts [Boolean] :wait_on_approvals Whether to wait for approvals before processing the import
    # @return [Array<(nil, Integer, Hash)>] nil, response status code and response headers
    def create_big_segment_import_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.create_big_segment_import ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.create_big_segment_import"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.create_big_segment_import"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.create_big_segment_import"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['multipart/form-data'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}
      form_params['file'] = opts[:'file'] if !opts[:'file'].nil?
      form_params['mode'] = opts[:'mode'] if !opts[:'mode'].nil?
      form_params['waitOnApprovals'] = opts[:'wait_on_approvals'] if !opts[:'wait_on_approvals'].nil?

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type]

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.create_big_segment_import",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#create_big_segment_import\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Delete segment
    # Delete a segment.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [nil]
    def delete_segment(project_key, environment_key, segment_key, opts = {})
      delete_segment_with_http_info(project_key, environment_key, segment_key, opts)
      nil
    end

    # Delete segment
    # Delete a segment.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [Array<(nil, Integer, Hash)>] nil, response status code and response headers
    def delete_segment_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.delete_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.delete_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.delete_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.delete_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type]

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.delete_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:DELETE, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#delete_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get big segment export
    # Returns information about a big segment export process. This is an export for a synced segment or a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param export_id [String] The export ID
    # @param [Hash] opts the optional parameters
    # @return [Export]
    def get_big_segment_export(project_key, environment_key, segment_key, export_id, opts = {})
      data, _status_code, _headers = get_big_segment_export_with_http_info(project_key, environment_key, segment_key, export_id, opts)
      data
    end

    # Get big segment export
    # Returns information about a big segment export process. This is an export for a synced segment or a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param export_id [String] The export ID
    # @param [Hash] opts the optional parameters
    # @return [Array<(Export, Integer, Hash)>] Export data, response status code and response headers
    def get_big_segment_export_with_http_info(project_key, environment_key, segment_key, export_id, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_big_segment_export ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_big_segment_export"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_big_segment_export"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_big_segment_export"
      end
      # verify the required parameter 'export_id' is set
      if @api_client.config.client_side_validation && export_id.nil?
        fail ArgumentError, "Missing the required parameter 'export_id' when calling SegmentsApi.get_big_segment_export"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports/{exportID}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s)).sub('{' + 'exportID' + '}', CGI.escape(export_id.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'Export'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_big_segment_export",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_big_segment_export\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get big segment import
    # Returns information about a big segment import process. This is the import of a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param import_id [String] The import ID
    # @param [Hash] opts the optional parameters
    # @return [Import]
    def get_big_segment_import(project_key, environment_key, segment_key, import_id, opts = {})
      data, _status_code, _headers = get_big_segment_import_with_http_info(project_key, environment_key, segment_key, import_id, opts)
      data
    end

    # Get big segment import
    # Returns information about a big segment import process. This is the import of a list-based segment that can include more than 15,000 entries.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param import_id [String] The import ID
    # @param [Hash] opts the optional parameters
    # @return [Array<(Import, Integer, Hash)>] Import data, response status code and response headers
    def get_big_segment_import_with_http_info(project_key, environment_key, segment_key, import_id, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_big_segment_import ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_big_segment_import"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_big_segment_import"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_big_segment_import"
      end
      # verify the required parameter 'import_id' is set
      if @api_client.config.client_side_validation && import_id.nil?
        fail ArgumentError, "Missing the required parameter 'import_id' when calling SegmentsApi.get_big_segment_import"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports/{importID}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s)).sub('{' + 'importID' + '}', CGI.escape(import_id.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'Import'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_big_segment_import",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_big_segment_import\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # List segment memberships for context instance
    # For a given context instance with attributes, get membership details for all segments. In the request body, pass in the context instance.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param request_body [Hash<String, Object>] 
    # @param [Hash] opts the optional parameters
    # @return [ContextInstanceSegmentMemberships]
    def get_context_instance_segments_membership_by_env(project_key, environment_key, request_body, opts = {})
      data, _status_code, _headers = get_context_instance_segments_membership_by_env_with_http_info(project_key, environment_key, request_body, opts)
      data
    end

    # List segment memberships for context instance
    # For a given context instance with attributes, get membership details for all segments. In the request body, pass in the context instance.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param request_body [Hash<String, Object>] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(ContextInstanceSegmentMemberships, Integer, Hash)>] ContextInstanceSegmentMemberships data, response status code and response headers
    def get_context_instance_segments_membership_by_env_with_http_info(project_key, environment_key, request_body, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_context_instance_segments_membership_by_env ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_context_instance_segments_membership_by_env"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_context_instance_segments_membership_by_env"
      end
      # verify the required parameter 'request_body' is set
      if @api_client.config.client_side_validation && request_body.nil?
        fail ArgumentError, "Missing the required parameter 'request_body' when calling SegmentsApi.get_context_instance_segments_membership_by_env"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/segments/evaluate'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(request_body)

      # return_type
      return_type = opts[:debug_return_type] || 'ContextInstanceSegmentMemberships'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_context_instance_segments_membership_by_env",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_context_instance_segments_membership_by_env\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get expiring targets for segment
    # Get a list of a segment's context targets that are scheduled for removal.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [ExpiringTargetGetResponse]
    def get_expiring_targets_for_segment(project_key, environment_key, segment_key, opts = {})
      data, _status_code, _headers = get_expiring_targets_for_segment_with_http_info(project_key, environment_key, segment_key, opts)
      data
    end

    # Get expiring targets for segment
    # Get a list of a segment&#39;s context targets that are scheduled for removal.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [Array<(ExpiringTargetGetResponse, Integer, Hash)>] ExpiringTargetGetResponse data, response status code and response headers
    def get_expiring_targets_for_segment_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_expiring_targets_for_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_expiring_targets_for_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_expiring_targets_for_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_expiring_targets_for_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'ExpiringTargetGetResponse'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_expiring_targets_for_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_expiring_targets_for_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get expiring user targets for segment
    # > ### Contexts are now available > > After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Get expiring targets for segment](/tag/Segments#operation/getExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Get a list of a segment's user targets that are scheduled for removal. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [ExpiringUserTargetGetResponse]
    def get_expiring_user_targets_for_segment(project_key, environment_key, segment_key, opts = {})
      data, _status_code, _headers = get_expiring_user_targets_for_segment_with_http_info(project_key, environment_key, segment_key, opts)
      data
    end

    # Get expiring user targets for segment
    # &gt; ### Contexts are now available &gt; &gt; After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Get expiring targets for segment](/tag/Segments#operation/getExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Get a list of a segment&#39;s user targets that are scheduled for removal. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [Array<(ExpiringUserTargetGetResponse, Integer, Hash)>] ExpiringUserTargetGetResponse data, response status code and response headers
    def get_expiring_user_targets_for_segment_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_expiring_user_targets_for_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_expiring_user_targets_for_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_expiring_user_targets_for_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_expiring_user_targets_for_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'ExpiringUserTargetGetResponse'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_expiring_user_targets_for_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_expiring_user_targets_for_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get segment
    # Get a single segment by key.<br/><br/>Segments can be rule-based, list-based, or synced. Big segments include larger list-based segments and synced segments. Some fields in the response only apply to big segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [UserSegment]
    def get_segment(project_key, environment_key, segment_key, opts = {})
      data, _status_code, _headers = get_segment_with_http_info(project_key, environment_key, segment_key, opts)
      data
    end

    # Get segment
    # Get a single segment by key.&lt;br/&gt;&lt;br/&gt;Segments can be rule-based, list-based, or synced. Big segments include larger list-based segments and synced segments. Some fields in the response only apply to big segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param [Hash] opts the optional parameters
    # @return [Array<(UserSegment, Integer, Hash)>] UserSegment data, response status code and response headers
    def get_segment_with_http_info(project_key, environment_key, segment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'UserSegment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get big segment membership for context
    # Get the membership status (included/excluded) for a given context in this big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param context_key [String] The context key
    # @param [Hash] opts the optional parameters
    # @return [BigSegmentTarget]
    def get_segment_membership_for_context(project_key, environment_key, segment_key, context_key, opts = {})
      data, _status_code, _headers = get_segment_membership_for_context_with_http_info(project_key, environment_key, segment_key, context_key, opts)
      data
    end

    # Get big segment membership for context
    # Get the membership status (included/excluded) for a given context in this big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param context_key [String] The context key
    # @param [Hash] opts the optional parameters
    # @return [Array<(BigSegmentTarget, Integer, Hash)>] BigSegmentTarget data, response status code and response headers
    def get_segment_membership_for_context_with_http_info(project_key, environment_key, segment_key, context_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_segment_membership_for_context ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_segment_membership_for_context"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_segment_membership_for_context"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_segment_membership_for_context"
      end
      # verify the required parameter 'context_key' is set
      if @api_client.config.client_side_validation && context_key.nil?
        fail ArgumentError, "Missing the required parameter 'context_key' when calling SegmentsApi.get_segment_membership_for_context"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts/{contextKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s)).sub('{' + 'contextKey' + '}', CGI.escape(context_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'BigSegmentTarget'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_segment_membership_for_context",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_segment_membership_for_context\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get big segment membership for user
    # > ### Contexts are now available > > After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Get expiring targets for segment](/tag/Segments#operation/getExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Get the membership status (included/excluded) for a given user in this big segment. This operation does not support standard segments. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param user_key [String] The user key
    # @param [Hash] opts the optional parameters
    # @return [BigSegmentTarget]
    def get_segment_membership_for_user(project_key, environment_key, segment_key, user_key, opts = {})
      data, _status_code, _headers = get_segment_membership_for_user_with_http_info(project_key, environment_key, segment_key, user_key, opts)
      data
    end

    # Get big segment membership for user
    # &gt; ### Contexts are now available &gt; &gt; After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Get expiring targets for segment](/tag/Segments#operation/getExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Get the membership status (included/excluded) for a given user in this big segment. This operation does not support standard segments. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param user_key [String] The user key
    # @param [Hash] opts the optional parameters
    # @return [Array<(BigSegmentTarget, Integer, Hash)>] BigSegmentTarget data, response status code and response headers
    def get_segment_membership_for_user_with_http_info(project_key, environment_key, segment_key, user_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_segment_membership_for_user ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_segment_membership_for_user"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_segment_membership_for_user"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.get_segment_membership_for_user"
      end
      # verify the required parameter 'user_key' is set
      if @api_client.config.client_side_validation && user_key.nil?
        fail ArgumentError, "Missing the required parameter 'user_key' when calling SegmentsApi.get_segment_membership_for_user"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users/{userKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s)).sub('{' + 'userKey' + '}', CGI.escape(user_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'BigSegmentTarget'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_segment_membership_for_user",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_segment_membership_for_user\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # List segments
    # Get a list of all segments in the given project.  Segments can be rule-based, list-based, or synced. Big segments include larger list-based segments and synced segments. Some fields in the response only apply to big segments.  ### Filtering segments  The `filter` parameter supports the following operators: `equals`, `anyOf`, and `exists`.  You can also combine filters in the following ways:  - Use a comma (`,`) as an AND operator - Use a vertical bar (`|`) as an OR operator - Use parentheses (`()`) to group filters  #### Supported fields and operators  You can only filter certain fields in segments when using the `filter` parameter. Additionally, you can only filter some fields with certain operators.  When you search for segments, the `filter` parameter supports the following fields and operators:  |<div style=\"width:120px\">Field</div> |Description |Supported operators | |---|---|---| | `excludedKeys` | The segment keys of segments to exclude from the results. | `anyOf` | | `external` | Whether the segment is a synced segment. | `exists` | | `includedKeys` | The segment keys of segments to include in the results. | `anyOf` | | `query` | A \"fuzzy\" search across segment key, name, and description. Supply a string or list of strings to the operator. | `equals` | | `tags` | The segment tags. | `anyOf` | | `unbounded` | Whether the segment is a standard segment (`false`) or a big segment (`true`). Standard segments include rule-based segments and smaller list-based segments. Big segments include larger list-based segments and synced segments. | `equals` |  Here are a few examples:  * The filter `?filter=tags anyOf [\"enterprise\", \"beta\"],query equals \"toggle\"` matches segments with \"toggle\" in their key, name, or description that also have \"enterprise\" or \"beta\" as a tag. * The filter `?filter=excludedKeys anyOf [\"segmentKey1\", \"segmentKey2\"]` excludes the segments with those keys from the results. * The filter `?filter=unbounded equals true` matches larger list-based segments and synced segments.  The documented values for `filter` query parameters are prior to URL encoding. For example, the `[` in `?filter=tags anyOf [\"enterprise\", \"beta\"]` must be encoded to `%5B`. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param [Hash] opts the optional parameters
    # @option opts [Integer] :limit The number of segments to return. Defaults to 20.
    # @option opts [Integer] :offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;.
    # @option opts [String] :sort Accepts sorting order and fields. Fields can be comma separated. Possible fields are &#39;creationDate&#39;, &#39;name&#39;, &#39;lastModified&#39;. Example: &#x60;sort&#x3D;name&#x60; sort by names ascending or &#x60;sort&#x3D;-name,creationDate&#x60; sort by names descending and creationDate ascending.
    # @option opts [String] :filter Accepts filter by &#x60;excludedKeys&#x60;, &#x60;external&#x60;, &#x60;includedKeys&#x60;, &#x60;query&#x60;, &#x60;tags&#x60;, &#x60;unbounded&#x60;. To learn more about the filter syntax, read the  &#39;Filtering segments&#39; section above.
    # @return [UserSegments]
    def get_segments(project_key, environment_key, opts = {})
      data, _status_code, _headers = get_segments_with_http_info(project_key, environment_key, opts)
      data
    end

    # List segments
    # Get a list of all segments in the given project.  Segments can be rule-based, list-based, or synced. Big segments include larger list-based segments and synced segments. Some fields in the response only apply to big segments.  ### Filtering segments  The &#x60;filter&#x60; parameter supports the following operators: &#x60;equals&#x60;, &#x60;anyOf&#x60;, and &#x60;exists&#x60;.  You can also combine filters in the following ways:  - Use a comma (&#x60;,&#x60;) as an AND operator - Use a vertical bar (&#x60;|&#x60;) as an OR operator - Use parentheses (&#x60;()&#x60;) to group filters  #### Supported fields and operators  You can only filter certain fields in segments when using the &#x60;filter&#x60; parameter. Additionally, you can only filter some fields with certain operators.  When you search for segments, the &#x60;filter&#x60; parameter supports the following fields and operators:  |&lt;div style&#x3D;\&quot;width:120px\&quot;&gt;Field&lt;/div&gt; |Description |Supported operators | |---|---|---| | &#x60;excludedKeys&#x60; | The segment keys of segments to exclude from the results. | &#x60;anyOf&#x60; | | &#x60;external&#x60; | Whether the segment is a synced segment. | &#x60;exists&#x60; | | &#x60;includedKeys&#x60; | The segment keys of segments to include in the results. | &#x60;anyOf&#x60; | | &#x60;query&#x60; | A \&quot;fuzzy\&quot; search across segment key, name, and description. Supply a string or list of strings to the operator. | &#x60;equals&#x60; | | &#x60;tags&#x60; | The segment tags. | &#x60;anyOf&#x60; | | &#x60;unbounded&#x60; | Whether the segment is a standard segment (&#x60;false&#x60;) or a big segment (&#x60;true&#x60;). Standard segments include rule-based segments and smaller list-based segments. Big segments include larger list-based segments and synced segments. | &#x60;equals&#x60; |  Here are a few examples:  * The filter &#x60;?filter&#x3D;tags anyOf [\&quot;enterprise\&quot;, \&quot;beta\&quot;],query equals \&quot;toggle\&quot;&#x60; matches segments with \&quot;toggle\&quot; in their key, name, or description that also have \&quot;enterprise\&quot; or \&quot;beta\&quot; as a tag. * The filter &#x60;?filter&#x3D;excludedKeys anyOf [\&quot;segmentKey1\&quot;, \&quot;segmentKey2\&quot;]&#x60; excludes the segments with those keys from the results. * The filter &#x60;?filter&#x3D;unbounded equals true&#x60; matches larger list-based segments and synced segments.  The documented values for &#x60;filter&#x60; query parameters are prior to URL encoding. For example, the &#x60;[&#x60; in &#x60;?filter&#x3D;tags anyOf [\&quot;enterprise\&quot;, \&quot;beta\&quot;]&#x60; must be encoded to &#x60;%5B&#x60;. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param [Hash] opts the optional parameters
    # @option opts [Integer] :limit The number of segments to return. Defaults to 20.
    # @option opts [Integer] :offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;.
    # @option opts [String] :sort Accepts sorting order and fields. Fields can be comma separated. Possible fields are &#39;creationDate&#39;, &#39;name&#39;, &#39;lastModified&#39;. Example: &#x60;sort&#x3D;name&#x60; sort by names ascending or &#x60;sort&#x3D;-name,creationDate&#x60; sort by names descending and creationDate ascending.
    # @option opts [String] :filter Accepts filter by &#x60;excludedKeys&#x60;, &#x60;external&#x60;, &#x60;includedKeys&#x60;, &#x60;query&#x60;, &#x60;tags&#x60;, &#x60;unbounded&#x60;. To learn more about the filter syntax, read the  &#39;Filtering segments&#39; section above.
    # @return [Array<(UserSegments, Integer, Hash)>] UserSegments data, response status code and response headers
    def get_segments_with_http_info(project_key, environment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.get_segments ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.get_segments"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.get_segments"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}
      query_params[:'limit'] = opts[:'limit'] if !opts[:'limit'].nil?
      query_params[:'offset'] = opts[:'offset'] if !opts[:'offset'].nil?
      query_params[:'sort'] = opts[:'sort'] if !opts[:'sort'].nil?
      query_params[:'filter'] = opts[:'filter'] if !opts[:'filter'].nil?

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'UserSegments'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.get_segments",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#get_segments\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Update expiring targets for segment
    #  Update expiring context targets for a segment. Updating a context target expiration uses the semantic patch format.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  If the request is well-formed but any of its instructions failed to process, this operation returns status code `200`. In this case, the response `errors` array will be non-empty.  ### Instructions  Semantic patch requests support the following `kind` instructions for updating expiring context targets.  <details> <summary>Click to expand instructions for <strong>updating expiring context targets</strong></summary>  #### addExpiringTarget  Schedules a date and time when LaunchDarkly will remove a context from segment targeting. The segment must already have the context as an individual target.  ##### Parameters  - `targetType`: The type of individual target for this context. Must be either `included` or `excluded`. - `contextKey`: The context key. - `contextKind`: The kind of context being targeted. - `value`: The date when the context should expire from the segment targeting, in Unix milliseconds.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addExpiringTarget\",     \"targetType\": \"included\",     \"contextKey\": \"user-key-123abc\",     \"contextKind\": \"user\",     \"value\": 1754092860000   }] } ```  #### updateExpiringTarget  Updates the date and time when LaunchDarkly will remove a context from segment targeting.  ##### Parameters  - `targetType`: The type of individual target for this context. Must be either `included` or `excluded`. - `contextKey`: The context key. - `contextKind`: The kind of context being targeted. - `value`: The new date when the context should expire from the segment targeting, in Unix milliseconds. - `version`: (Optional) The version of the expiring target to update. If included, update will fail if version doesn't match current version of the expiring target.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateExpiringTarget\",     \"targetType\": \"included\",     \"contextKey\": \"user-key-123abc\",     \"contextKind\": \"user\",     \"value\": 1754179260000   }] } ```  #### removeExpiringTarget  Removes the scheduled expiration for the context in the segment.  ##### Parameters  - `targetType`: The type of individual target for this context. Must be either `included` or `excluded`. - `contextKey`: The context key. - `contextKind`: The kind of context being targeted.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeExpiringTarget\",     \"targetType\": \"included\",     \"contextKey\": \"user-key-123abc\",     \"contextKind\": \"user\",   }] } ```  </details> 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_segment_expiring_target_input_rep [PatchSegmentExpiringTargetInputRep] 
    # @param [Hash] opts the optional parameters
    # @return [ExpiringTargetPatchResponse]
    def patch_expiring_targets_for_segment(project_key, environment_key, segment_key, patch_segment_expiring_target_input_rep, opts = {})
      data, _status_code, _headers = patch_expiring_targets_for_segment_with_http_info(project_key, environment_key, segment_key, patch_segment_expiring_target_input_rep, opts)
      data
    end

    # Update expiring targets for segment
    #  Update expiring context targets for a segment. Updating a context target expiration uses the semantic patch format.  To make a semantic patch request, you must append &#x60;domain-model&#x3D;launchdarkly.semanticpatch&#x60; to your &#x60;Content-Type&#x60; header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  If the request is well-formed but any of its instructions failed to process, this operation returns status code &#x60;200&#x60;. In this case, the response &#x60;errors&#x60; array will be non-empty.  ### Instructions  Semantic patch requests support the following &#x60;kind&#x60; instructions for updating expiring context targets.  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;updating expiring context targets&lt;/strong&gt;&lt;/summary&gt;  #### addExpiringTarget  Schedules a date and time when LaunchDarkly will remove a context from segment targeting. The segment must already have the context as an individual target.  ##### Parameters  - &#x60;targetType&#x60;: The type of individual target for this context. Must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;contextKey&#x60;: The context key. - &#x60;contextKind&#x60;: The kind of context being targeted. - &#x60;value&#x60;: The date when the context should expire from the segment targeting, in Unix milliseconds.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addExpiringTarget\&quot;,     \&quot;targetType\&quot;: \&quot;included\&quot;,     \&quot;contextKey\&quot;: \&quot;user-key-123abc\&quot;,     \&quot;contextKind\&quot;: \&quot;user\&quot;,     \&quot;value\&quot;: 1754092860000   }] } &#x60;&#x60;&#x60;  #### updateExpiringTarget  Updates the date and time when LaunchDarkly will remove a context from segment targeting.  ##### Parameters  - &#x60;targetType&#x60;: The type of individual target for this context. Must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;contextKey&#x60;: The context key. - &#x60;contextKind&#x60;: The kind of context being targeted. - &#x60;value&#x60;: The new date when the context should expire from the segment targeting, in Unix milliseconds. - &#x60;version&#x60;: (Optional) The version of the expiring target to update. If included, update will fail if version doesn&#39;t match current version of the expiring target.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateExpiringTarget\&quot;,     \&quot;targetType\&quot;: \&quot;included\&quot;,     \&quot;contextKey\&quot;: \&quot;user-key-123abc\&quot;,     \&quot;contextKind\&quot;: \&quot;user\&quot;,     \&quot;value\&quot;: 1754179260000   }] } &#x60;&#x60;&#x60;  #### removeExpiringTarget  Removes the scheduled expiration for the context in the segment.  ##### Parameters  - &#x60;targetType&#x60;: The type of individual target for this context. Must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;contextKey&#x60;: The context key. - &#x60;contextKind&#x60;: The kind of context being targeted.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeExpiringTarget\&quot;,     \&quot;targetType\&quot;: \&quot;included\&quot;,     \&quot;contextKey\&quot;: \&quot;user-key-123abc\&quot;,     \&quot;contextKind\&quot;: \&quot;user\&quot;,   }] } &#x60;&#x60;&#x60;  &lt;/details&gt; 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_segment_expiring_target_input_rep [PatchSegmentExpiringTargetInputRep] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(ExpiringTargetPatchResponse, Integer, Hash)>] ExpiringTargetPatchResponse data, response status code and response headers
    def patch_expiring_targets_for_segment_with_http_info(project_key, environment_key, segment_key, patch_segment_expiring_target_input_rep, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.patch_expiring_targets_for_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.patch_expiring_targets_for_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.patch_expiring_targets_for_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.patch_expiring_targets_for_segment"
      end
      # verify the required parameter 'patch_segment_expiring_target_input_rep' is set
      if @api_client.config.client_side_validation && patch_segment_expiring_target_input_rep.nil?
        fail ArgumentError, "Missing the required parameter 'patch_segment_expiring_target_input_rep' when calling SegmentsApi.patch_expiring_targets_for_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(patch_segment_expiring_target_input_rep)

      # return_type
      return_type = opts[:debug_return_type] || 'ExpiringTargetPatchResponse'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.patch_expiring_targets_for_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:PATCH, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#patch_expiring_targets_for_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Update expiring user targets for segment
    #  > ### Contexts are now available > > After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Update expiring targets for segment](/tag/Segments#operation/patchExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Update expiring user targets for a segment. Updating a user target expiration uses the semantic patch format.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  If the request is well-formed but any of its instructions failed to process, this operation returns status code `200`. In this case, the response `errors` array will be non-empty.  ### Instructions  Semantic patch requests support the following `kind` instructions for updating expiring user targets.  <details> <summary>Click to expand instructions for <strong>updating expiring user targets</strong></summary>  #### addExpireUserTargetDate  Schedules a date and time when LaunchDarkly will remove a user from segment targeting.  ##### Parameters  - `targetType`: A segment's target type, must be either `included` or `excluded`. - `userKey`: The user key. - `value`: The date when the user should expire from the segment targeting, in Unix milliseconds.  #### updateExpireUserTargetDate  Updates the date and time when LaunchDarkly will remove a user from segment targeting.  ##### Parameters  - `targetType`: A segment's target type, must be either `included` or `excluded`. - `userKey`: The user key. - `value`: The new date when the user should expire from the segment targeting, in Unix milliseconds. - `version`: The segment version.  #### removeExpireUserTargetDate  Removes the scheduled expiration for the user in the segment.  ##### Parameters  - `targetType`: A segment's target type, must be either `included` or `excluded`. - `userKey`: The user key.  </details> 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_segment_request [PatchSegmentRequest] 
    # @param [Hash] opts the optional parameters
    # @return [ExpiringUserTargetPatchResponse]
    def patch_expiring_user_targets_for_segment(project_key, environment_key, segment_key, patch_segment_request, opts = {})
      data, _status_code, _headers = patch_expiring_user_targets_for_segment_with_http_info(project_key, environment_key, segment_key, patch_segment_request, opts)
      data
    end

    # Update expiring user targets for segment
    #  &gt; ### Contexts are now available &gt; &gt; After you have upgraded your LaunchDarkly SDK to use contexts instead of users, you should use [Update expiring targets for segment](/tag/Segments#operation/patchExpiringTargetsForSegment) instead of this endpoint. To learn more, read [Contexts](https://docs.launchdarkly.com/home/observability/contexts).  Update expiring user targets for a segment. Updating a user target expiration uses the semantic patch format.  To make a semantic patch request, you must append &#x60;domain-model&#x3D;launchdarkly.semanticpatch&#x60; to your &#x60;Content-Type&#x60; header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  If the request is well-formed but any of its instructions failed to process, this operation returns status code &#x60;200&#x60;. In this case, the response &#x60;errors&#x60; array will be non-empty.  ### Instructions  Semantic patch requests support the following &#x60;kind&#x60; instructions for updating expiring user targets.  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;updating expiring user targets&lt;/strong&gt;&lt;/summary&gt;  #### addExpireUserTargetDate  Schedules a date and time when LaunchDarkly will remove a user from segment targeting.  ##### Parameters  - &#x60;targetType&#x60;: A segment&#39;s target type, must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;userKey&#x60;: The user key. - &#x60;value&#x60;: The date when the user should expire from the segment targeting, in Unix milliseconds.  #### updateExpireUserTargetDate  Updates the date and time when LaunchDarkly will remove a user from segment targeting.  ##### Parameters  - &#x60;targetType&#x60;: A segment&#39;s target type, must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;userKey&#x60;: The user key. - &#x60;value&#x60;: The new date when the user should expire from the segment targeting, in Unix milliseconds. - &#x60;version&#x60;: The segment version.  #### removeExpireUserTargetDate  Removes the scheduled expiration for the user in the segment.  ##### Parameters  - &#x60;targetType&#x60;: A segment&#39;s target type, must be either &#x60;included&#x60; or &#x60;excluded&#x60;. - &#x60;userKey&#x60;: The user key.  &lt;/details&gt; 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_segment_request [PatchSegmentRequest] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(ExpiringUserTargetPatchResponse, Integer, Hash)>] ExpiringUserTargetPatchResponse data, response status code and response headers
    def patch_expiring_user_targets_for_segment_with_http_info(project_key, environment_key, segment_key, patch_segment_request, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.patch_expiring_user_targets_for_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.patch_expiring_user_targets_for_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.patch_expiring_user_targets_for_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.patch_expiring_user_targets_for_segment"
      end
      # verify the required parameter 'patch_segment_request' is set
      if @api_client.config.client_side_validation && patch_segment_request.nil?
        fail ArgumentError, "Missing the required parameter 'patch_segment_request' when calling SegmentsApi.patch_expiring_user_targets_for_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(patch_segment_request)

      # return_type
      return_type = opts[:debug_return_type] || 'ExpiringUserTargetPatchResponse'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.patch_expiring_user_targets_for_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:PATCH, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#patch_expiring_user_targets_for_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Patch segment
    # Update a segment. The request body must be a valid semantic patch, JSON patch, or JSON merge patch. To learn more the different formats, read [Updates](/#section/Overview/Updates).  ### Using semantic patches on a segment  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  The body of a semantic patch request for updating segments requires an `environmentKey` in addition to `instructions` and an optional `comment`. The body of the request takes the following properties:  * `comment` (string): (Optional) A description of the update. * `environmentKey` (string): (Required) The key of the LaunchDarkly environment. * `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the action requires parameters, you must include those parameters as additional fields in the object.  ### Instructions  Semantic patch requests support the following `kind` instructions for updating segments.  <details> <summary>Click to expand instructions for <strong>updating segment details and settings</strong></summary>  #### addTags  Adds tags to the segment.  ##### Parameters  - `values`: A list of tags to add.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addTags\",     \"values\": [\"tag1\", \"tag2\"]   }] } ```  #### removeTags  Removes tags from the segment.  ##### Parameters  - `values`: A list of tags to remove.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeTags\",     \"values\": [\"tag1\", \"tag2\"]   }] } ```  #### updateName  Updates the name of the segment.  ##### Parameters  - `value`: Name of the segment.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateName\",     \"value\": \"Updated segment name\"   }] } ```  </details>  <details> <summary>Click to expand instructions for <strong>updating segment individual targets</strong></summary>  #### addExcludedTargets  Adds context keys to the individual context targets excluded from the segment for the specified `contextKind`. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - `contextKind`: The context kind the targets should be added to. - `values`: List of keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addExcludedTargets\",     \"contextKind\": \"org\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### addExcludedUsers  Adds user keys to the individual user targets excluded from the segment. Returns an error if this causes the same user key to be both included and excluded. If you are working with contexts, use `addExcludedTargets` instead of this instruction.  ##### Parameters  - `values`: List of user keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addExcludedUsers\",     \"values\": [ \"user-key-123abc\", \"user-key-456def\" ]   }] } ```  #### addIncludedTargets  Adds context keys to the individual context targets included in the segment for the specified `contextKind`. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - `contextKind`: The context kind the targets should be added to. - `values`: List of keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addIncludedTargets\",     \"contextKind\": \"org\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### addIncludedUsers  Adds user keys to the individual user targets included in the segment. Returns an error if this causes the same user key to be both included and excluded. If you are working with contexts, use `addIncludedTargets` instead of this instruction.  ##### Parameters  - `values`: List of user keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addIncludedUsers\",     \"values\": [ \"user-key-123abc\", \"user-key-456def\" ]   }] } ```  #### removeExcludedTargets  Removes context keys from the individual context targets excluded from the segment for the specified `contextKind`.  ##### Parameters  - `contextKind`: The context kind the targets should be removed from. - `values`: List of keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeExcludedTargets\",     \"contextKind\": \"org\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### removeExcludedUsers  Removes user keys from the individual user targets excluded from the segment. If you are working with contexts, use `removeExcludedTargets` instead of this instruction.  ##### Parameters  - `values`: List of user keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeExcludedUsers\",     \"values\": [ \"user-key-123abc\", \"user-key-456def\" ]   }] } ```  #### removeIncludedTargets  Removes context keys from the individual context targets included in the segment for the specified `contextKind`.  ##### Parameters  - `contextKind`: The context kind the targets should be removed from. - `values`: List of keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeIncludedTargets\",     \"contextKind\": \"org\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### removeIncludedUsers  Removes user keys from the individual user targets included in the segment. If you are working with contexts, use `removeIncludedTargets` instead of this instruction.  ##### Parameters  - `values`: List of user keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeIncludedUsers\",     \"values\": [ \"user-key-123abc\", \"user-key-456def\" ]   }] } ```  </details>  <details> <summary>Click to expand instructions for <strong>updating segment targeting rules</strong></summary>  #### addClauses  Adds the given clauses to the rule indicated by `ruleId`.  ##### Parameters  - `clauses`: Array of clause objects, with `contextKind` (string), `attribute` (string), `op` (string), `negate` (boolean), and `values` (array of strings, numbers, or dates) properties. The `contextKind`, if not provided, defaults to `user`. The `contextKind`, `attribute`, and `values` are case sensitive. The `op` must be lower-case. - `ruleId`: ID of a rule in the segment.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addClauses\",     \"clauses\": [       {         \"attribute\": \"email\",         \"negate\": false,         \"op\": \"contains\",         \"values\": [\"value1\"]       }     ],     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",   }] } ```  #### addRule  Adds a new targeting rule to the segment. The rule may contain `clauses`.  ##### Parameters  - `clauses`: Array of clause objects, with `contextKind` (string), `attribute` (string), `op` (string), `negate` (boolean), and `values` (array of strings, numbers, or dates) properties. The `contextKind`, if not provided, defaults to `user`. The `contextKind`, `attribute`, and `values` are case sensitive. The `op` must be lower-case. - `description`: A description of the rule.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addRule\",     \"clauses\": [       {         \"attribute\": \"email\",         \"op\": \"contains\",         \"negate\": false,         \"values\": [\"@launchdarkly.com\"]       }     ],     \"description\": \"Targeting rule for LaunchDarkly employees\",   }] } ```  #### addValuesToClause  Adds `values` to the values of the clause that `ruleId` and `clauseId` indicate. Does not update the context kind, attribute, or operator.  ##### Parameters  - `ruleId`: ID of a rule in the segment. - `clauseId`: ID of a clause in that rule. - `values`: Array of strings, case sensitive.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addValuesToClause\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",     \"clauseId\": \"10a58772-3121-400f-846b-b8a04e8944ed\",     \"values\": [\"beta_testers\"]   }] } ```  #### removeClauses  Removes the clauses specified by `clauseIds` from the rule indicated by `ruleId`.  ##### Parameters  - `ruleId`: ID of a rule in the segment. - `clauseIds`: Array of IDs of clauses in the rule.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeClauses\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",     \"clauseIds\": [\"10a58772-3121-400f-846b-b8a04e8944ed\", \"36a461dc-235e-4b08-97b9-73ce9365873e\"]   }] } ```  #### removeRule  Removes the targeting rule specified by `ruleId`. Does nothing if the rule does not exist.  ##### Parameters  - `ruleId`: ID of a rule in the segment.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeRule\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\"   }] } ```  #### removeValuesFromClause  Removes `values` from the values of the clause indicated by `ruleId` and `clauseId`. Does not update the context kind, attribute, or operator.  ##### Parameters  - `ruleId`: ID of a rule in the segment. - `clauseId`: ID of a clause in that rule. - `values`: Array of strings, case sensitive.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeValuesFromClause\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",     \"clauseId\": \"10a58772-3121-400f-846b-b8a04e8944ed\",     \"values\": [\"beta_testers\"]   }] } ```  #### reorderRules  Rearranges the rules to match the order given in `ruleIds`. Returns an error if `ruleIds` does not match the current set of rules in the segment.  ##### Parameters  - `ruleIds`: Array of IDs of all targeting rules in the segment.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"reorderRules\",     \"ruleIds\": [\"a902ef4a-2faf-4eaf-88e1-ecc356708a29\", \"63c238d1-835d-435e-8f21-c8d5e40b2a3d\"]   }] } ```  #### updateClause  Replaces the clause indicated by `ruleId` and `clauseId` with `clause`.  ##### Parameters  - `ruleId`: ID of a rule in the segment. - `clauseId`: ID of a clause in that rule. - `clause`: New `clause` object, with `contextKind` (string), `attribute` (string), `op` (string), `negate` (boolean), and `values` (array of strings, numbers, or dates) properties. The `contextKind`, if not provided, defaults to `user`. The `contextKind`, `attribute`, and `values` are case sensitive. The `op` must be lower-case.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateClause\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",     \"clauseId\": \"10c7462a-2062-45ba-a8bb-dfb3de0f8af5\",     \"clause\": {       \"contextKind\": \"user\",       \"attribute\": \"country\",       \"op\": \"in\",       \"negate\": false,       \"values\": [\"Mexico\", \"Canada\"]     }   }] } ```  #### updateRuleDescription  Updates the description of the segment targeting rule.  ##### Parameters  - `description`: The new human-readable description for this rule. - `ruleId`: The ID of the rule. You can retrieve this by making a GET request for the segment.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateRuleDescription\",     \"description\": \"New rule description\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\"   }] } ```  #### updateRuleRolloutAndContextKind  For a rule that includes a percentage of targets, updates the percentage and the context kind of the targets to include.  ##### Parameters  - `ruleId`: The ID of a targeting rule in the segment that includes a percentage of targets. - `weight`: The weight, in thousandths of a percent (0-100000). - `contextKind`: The context kind.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"reorderRules\",     \"ruleId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\",     \"weight\": \"20000\",     \"contextKind\": \"device\"   }] } ```  </details>  <details> <summary>Click to expand instructions for <strong>working with Big Segments</strong></summary>  A \"big segment\" is a segment that is either a synced segment, or a list-based segment with more than 15,000 entries that includes only one targeted context kind. LaunchDarkly uses different implementations for different types of segments so that all of your segments have good performance.  The following semantic patch instructions apply only to these [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments).  #### addBigSegmentExcludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Adds context keys to the context targets excluded from the segment. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - `values`: List of context keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addBigSegmentExcludedTargets\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### addBigSegmentIncludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Adds context keys to the context targets included in the segment. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - `values`: List of context keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"addBigSegmentIncludedTargets\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### processBigSegmentImport  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Processes a segment import.  ##### Parameters  - `importId`: The ID of the import. The import ID is returned in the `Location` header as part of the [Create big segment import](https://apidocs.launchdarkly.com/tag/Segments-(beta)#operation/createBigSegmentImport) request.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"processBigSegmentImport\",     \"importId\": \"a902ef4a-2faf-4eaf-88e1-ecc356708a29\"   }] } ```   #### removeBigSegmentExcludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Removes context keys from the context targets excluded from the segment.  ##### Parameters  - `values`: List of context keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeBigSegmentExcludedTargets\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  #### removeBigSegmentIncludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Removes context keys from the context targets included in the segment.  ##### Parameters  - `values`: List of context keys.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"removeBigSegmentIncludedTargets\",     \"values\": [ \"org-key-123abc\", \"org-key-456def\" ]   }] } ```  </details>  ### Using JSON patches on a segment  If you do not include the header described above, you can use a [JSON patch](/reference#updates-using-json-patch) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes.  For example, to update the description for a segment with a JSON patch, use the following request body:  ```json {   \"patch\": [     {       \"op\": \"replace\",       \"path\": \"/description\",       \"value\": \"new description\"     }   ] } ```  To update fields in the segment that are arrays, set the `path` to the name of the field and then append `/<array index>`. Use `/0` to add the new entry to the beginning of the array. Use `/-` to add the new entry to the end of the array.  For example, to add a rule to a segment, use the following request body:  ```json {   \"patch\":[     {       \"op\": \"add\",       \"path\": \"/rules/0\",       \"value\": {         \"clauses\": [{ \"contextKind\": \"user\", \"attribute\": \"email\", \"op\": \"endsWith\", \"values\": [\".edu\"], \"negate\": false }]       }     }   ] } ```  To add or remove targets from segments, we recommend using semantic patch. Semantic patch for segments includes specific instructions for adding and removing both included and excluded targets. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_with_comment [PatchWithComment] 
    # @param [Hash] opts the optional parameters
    # @return [UserSegment]
    def patch_segment(project_key, environment_key, segment_key, patch_with_comment, opts = {})
      data, _status_code, _headers = patch_segment_with_http_info(project_key, environment_key, segment_key, patch_with_comment, opts)
      data
    end

    # Patch segment
    # Update a segment. The request body must be a valid semantic patch, JSON patch, or JSON merge patch. To learn more the different formats, read [Updates](/#section/Overview/Updates).  ### Using semantic patches on a segment  To make a semantic patch request, you must append &#x60;domain-model&#x3D;launchdarkly.semanticpatch&#x60; to your &#x60;Content-Type&#x60; header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  The body of a semantic patch request for updating segments requires an &#x60;environmentKey&#x60; in addition to &#x60;instructions&#x60; and an optional &#x60;comment&#x60;. The body of the request takes the following properties:  * &#x60;comment&#x60; (string): (Optional) A description of the update. * &#x60;environmentKey&#x60; (string): (Required) The key of the LaunchDarkly environment. * &#x60;instructions&#x60; (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a &#x60;kind&#x60; property that indicates the instruction. If the action requires parameters, you must include those parameters as additional fields in the object.  ### Instructions  Semantic patch requests support the following &#x60;kind&#x60; instructions for updating segments.  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;updating segment details and settings&lt;/strong&gt;&lt;/summary&gt;  #### addTags  Adds tags to the segment.  ##### Parameters  - &#x60;values&#x60;: A list of tags to add.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addTags\&quot;,     \&quot;values\&quot;: [\&quot;tag1\&quot;, \&quot;tag2\&quot;]   }] } &#x60;&#x60;&#x60;  #### removeTags  Removes tags from the segment.  ##### Parameters  - &#x60;values&#x60;: A list of tags to remove.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeTags\&quot;,     \&quot;values\&quot;: [\&quot;tag1\&quot;, \&quot;tag2\&quot;]   }] } &#x60;&#x60;&#x60;  #### updateName  Updates the name of the segment.  ##### Parameters  - &#x60;value&#x60;: Name of the segment.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateName\&quot;,     \&quot;value\&quot;: \&quot;Updated segment name\&quot;   }] } &#x60;&#x60;&#x60;  &lt;/details&gt;  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;updating segment individual targets&lt;/strong&gt;&lt;/summary&gt;  #### addExcludedTargets  Adds context keys to the individual context targets excluded from the segment for the specified &#x60;contextKind&#x60;. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - &#x60;contextKind&#x60;: The context kind the targets should be added to. - &#x60;values&#x60;: List of keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addExcludedTargets\&quot;,     \&quot;contextKind\&quot;: \&quot;org\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### addExcludedUsers  Adds user keys to the individual user targets excluded from the segment. Returns an error if this causes the same user key to be both included and excluded. If you are working with contexts, use &#x60;addExcludedTargets&#x60; instead of this instruction.  ##### Parameters  - &#x60;values&#x60;: List of user keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addExcludedUsers\&quot;,     \&quot;values\&quot;: [ \&quot;user-key-123abc\&quot;, \&quot;user-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### addIncludedTargets  Adds context keys to the individual context targets included in the segment for the specified &#x60;contextKind&#x60;. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - &#x60;contextKind&#x60;: The context kind the targets should be added to. - &#x60;values&#x60;: List of keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addIncludedTargets\&quot;,     \&quot;contextKind\&quot;: \&quot;org\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### addIncludedUsers  Adds user keys to the individual user targets included in the segment. Returns an error if this causes the same user key to be both included and excluded. If you are working with contexts, use &#x60;addIncludedTargets&#x60; instead of this instruction.  ##### Parameters  - &#x60;values&#x60;: List of user keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addIncludedUsers\&quot;,     \&quot;values\&quot;: [ \&quot;user-key-123abc\&quot;, \&quot;user-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### removeExcludedTargets  Removes context keys from the individual context targets excluded from the segment for the specified &#x60;contextKind&#x60;.  ##### Parameters  - &#x60;contextKind&#x60;: The context kind the targets should be removed from. - &#x60;values&#x60;: List of keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeExcludedTargets\&quot;,     \&quot;contextKind\&quot;: \&quot;org\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### removeExcludedUsers  Removes user keys from the individual user targets excluded from the segment. If you are working with contexts, use &#x60;removeExcludedTargets&#x60; instead of this instruction.  ##### Parameters  - &#x60;values&#x60;: List of user keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeExcludedUsers\&quot;,     \&quot;values\&quot;: [ \&quot;user-key-123abc\&quot;, \&quot;user-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### removeIncludedTargets  Removes context keys from the individual context targets included in the segment for the specified &#x60;contextKind&#x60;.  ##### Parameters  - &#x60;contextKind&#x60;: The context kind the targets should be removed from. - &#x60;values&#x60;: List of keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeIncludedTargets\&quot;,     \&quot;contextKind\&quot;: \&quot;org\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### removeIncludedUsers  Removes user keys from the individual user targets included in the segment. If you are working with contexts, use &#x60;removeIncludedTargets&#x60; instead of this instruction.  ##### Parameters  - &#x60;values&#x60;: List of user keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeIncludedUsers\&quot;,     \&quot;values\&quot;: [ \&quot;user-key-123abc\&quot;, \&quot;user-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  &lt;/details&gt;  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;updating segment targeting rules&lt;/strong&gt;&lt;/summary&gt;  #### addClauses  Adds the given clauses to the rule indicated by &#x60;ruleId&#x60;.  ##### Parameters  - &#x60;clauses&#x60;: Array of clause objects, with &#x60;contextKind&#x60; (string), &#x60;attribute&#x60; (string), &#x60;op&#x60; (string), &#x60;negate&#x60; (boolean), and &#x60;values&#x60; (array of strings, numbers, or dates) properties. The &#x60;contextKind&#x60;, if not provided, defaults to &#x60;user&#x60;. The &#x60;contextKind&#x60;, &#x60;attribute&#x60;, and &#x60;values&#x60; are case sensitive. The &#x60;op&#x60; must be lower-case. - &#x60;ruleId&#x60;: ID of a rule in the segment.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addClauses\&quot;,     \&quot;clauses\&quot;: [       {         \&quot;attribute\&quot;: \&quot;email\&quot;,         \&quot;negate\&quot;: false,         \&quot;op\&quot;: \&quot;contains\&quot;,         \&quot;values\&quot;: [\&quot;value1\&quot;]       }     ],     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,   }] } &#x60;&#x60;&#x60;  #### addRule  Adds a new targeting rule to the segment. The rule may contain &#x60;clauses&#x60;.  ##### Parameters  - &#x60;clauses&#x60;: Array of clause objects, with &#x60;contextKind&#x60; (string), &#x60;attribute&#x60; (string), &#x60;op&#x60; (string), &#x60;negate&#x60; (boolean), and &#x60;values&#x60; (array of strings, numbers, or dates) properties. The &#x60;contextKind&#x60;, if not provided, defaults to &#x60;user&#x60;. The &#x60;contextKind&#x60;, &#x60;attribute&#x60;, and &#x60;values&#x60; are case sensitive. The &#x60;op&#x60; must be lower-case. - &#x60;description&#x60;: A description of the rule.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addRule\&quot;,     \&quot;clauses\&quot;: [       {         \&quot;attribute\&quot;: \&quot;email\&quot;,         \&quot;op\&quot;: \&quot;contains\&quot;,         \&quot;negate\&quot;: false,         \&quot;values\&quot;: [\&quot;@launchdarkly.com\&quot;]       }     ],     \&quot;description\&quot;: \&quot;Targeting rule for LaunchDarkly employees\&quot;,   }] } &#x60;&#x60;&#x60;  #### addValuesToClause  Adds &#x60;values&#x60; to the values of the clause that &#x60;ruleId&#x60; and &#x60;clauseId&#x60; indicate. Does not update the context kind, attribute, or operator.  ##### Parameters  - &#x60;ruleId&#x60;: ID of a rule in the segment. - &#x60;clauseId&#x60;: ID of a clause in that rule. - &#x60;values&#x60;: Array of strings, case sensitive.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addValuesToClause\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,     \&quot;clauseId\&quot;: \&quot;10a58772-3121-400f-846b-b8a04e8944ed\&quot;,     \&quot;values\&quot;: [\&quot;beta_testers\&quot;]   }] } &#x60;&#x60;&#x60;  #### removeClauses  Removes the clauses specified by &#x60;clauseIds&#x60; from the rule indicated by &#x60;ruleId&#x60;.  ##### Parameters  - &#x60;ruleId&#x60;: ID of a rule in the segment. - &#x60;clauseIds&#x60;: Array of IDs of clauses in the rule.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeClauses\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,     \&quot;clauseIds\&quot;: [\&quot;10a58772-3121-400f-846b-b8a04e8944ed\&quot;, \&quot;36a461dc-235e-4b08-97b9-73ce9365873e\&quot;]   }] } &#x60;&#x60;&#x60;  #### removeRule  Removes the targeting rule specified by &#x60;ruleId&#x60;. Does nothing if the rule does not exist.  ##### Parameters  - &#x60;ruleId&#x60;: ID of a rule in the segment.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeRule\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;   }] } &#x60;&#x60;&#x60;  #### removeValuesFromClause  Removes &#x60;values&#x60; from the values of the clause indicated by &#x60;ruleId&#x60; and &#x60;clauseId&#x60;. Does not update the context kind, attribute, or operator.  ##### Parameters  - &#x60;ruleId&#x60;: ID of a rule in the segment. - &#x60;clauseId&#x60;: ID of a clause in that rule. - &#x60;values&#x60;: Array of strings, case sensitive.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeValuesFromClause\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,     \&quot;clauseId\&quot;: \&quot;10a58772-3121-400f-846b-b8a04e8944ed\&quot;,     \&quot;values\&quot;: [\&quot;beta_testers\&quot;]   }] } &#x60;&#x60;&#x60;  #### reorderRules  Rearranges the rules to match the order given in &#x60;ruleIds&#x60;. Returns an error if &#x60;ruleIds&#x60; does not match the current set of rules in the segment.  ##### Parameters  - &#x60;ruleIds&#x60;: Array of IDs of all targeting rules in the segment.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;reorderRules\&quot;,     \&quot;ruleIds\&quot;: [\&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;, \&quot;63c238d1-835d-435e-8f21-c8d5e40b2a3d\&quot;]   }] } &#x60;&#x60;&#x60;  #### updateClause  Replaces the clause indicated by &#x60;ruleId&#x60; and &#x60;clauseId&#x60; with &#x60;clause&#x60;.  ##### Parameters  - &#x60;ruleId&#x60;: ID of a rule in the segment. - &#x60;clauseId&#x60;: ID of a clause in that rule. - &#x60;clause&#x60;: New &#x60;clause&#x60; object, with &#x60;contextKind&#x60; (string), &#x60;attribute&#x60; (string), &#x60;op&#x60; (string), &#x60;negate&#x60; (boolean), and &#x60;values&#x60; (array of strings, numbers, or dates) properties. The &#x60;contextKind&#x60;, if not provided, defaults to &#x60;user&#x60;. The &#x60;contextKind&#x60;, &#x60;attribute&#x60;, and &#x60;values&#x60; are case sensitive. The &#x60;op&#x60; must be lower-case.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateClause\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,     \&quot;clauseId\&quot;: \&quot;10c7462a-2062-45ba-a8bb-dfb3de0f8af5\&quot;,     \&quot;clause\&quot;: {       \&quot;contextKind\&quot;: \&quot;user\&quot;,       \&quot;attribute\&quot;: \&quot;country\&quot;,       \&quot;op\&quot;: \&quot;in\&quot;,       \&quot;negate\&quot;: false,       \&quot;values\&quot;: [\&quot;Mexico\&quot;, \&quot;Canada\&quot;]     }   }] } &#x60;&#x60;&#x60;  #### updateRuleDescription  Updates the description of the segment targeting rule.  ##### Parameters  - &#x60;description&#x60;: The new human-readable description for this rule. - &#x60;ruleId&#x60;: The ID of the rule. You can retrieve this by making a GET request for the segment.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateRuleDescription\&quot;,     \&quot;description\&quot;: \&quot;New rule description\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;   }] } &#x60;&#x60;&#x60;  #### updateRuleRolloutAndContextKind  For a rule that includes a percentage of targets, updates the percentage and the context kind of the targets to include.  ##### Parameters  - &#x60;ruleId&#x60;: The ID of a targeting rule in the segment that includes a percentage of targets. - &#x60;weight&#x60;: The weight, in thousandths of a percent (0-100000). - &#x60;contextKind&#x60;: The context kind.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;reorderRules\&quot;,     \&quot;ruleId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;,     \&quot;weight\&quot;: \&quot;20000\&quot;,     \&quot;contextKind\&quot;: \&quot;device\&quot;   }] } &#x60;&#x60;&#x60;  &lt;/details&gt;  &lt;details&gt; &lt;summary&gt;Click to expand instructions for &lt;strong&gt;working with Big Segments&lt;/strong&gt;&lt;/summary&gt;  A \&quot;big segment\&quot; is a segment that is either a synced segment, or a list-based segment with more than 15,000 entries that includes only one targeted context kind. LaunchDarkly uses different implementations for different types of segments so that all of your segments have good performance.  The following semantic patch instructions apply only to these [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments).  #### addBigSegmentExcludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Adds context keys to the context targets excluded from the segment. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - &#x60;values&#x60;: List of context keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addBigSegmentExcludedTargets\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### addBigSegmentIncludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Adds context keys to the context targets included in the segment. Returns an error if this causes the same context key to be both included and excluded.  ##### Parameters  - &#x60;values&#x60;: List of context keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;addBigSegmentIncludedTargets\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### processBigSegmentImport  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Processes a segment import.  ##### Parameters  - &#x60;importId&#x60;: The ID of the import. The import ID is returned in the &#x60;Location&#x60; header as part of the [Create big segment import](https://apidocs.launchdarkly.com/tag/Segments-(beta)#operation/createBigSegmentImport) request.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;processBigSegmentImport\&quot;,     \&quot;importId\&quot;: \&quot;a902ef4a-2faf-4eaf-88e1-ecc356708a29\&quot;   }] } &#x60;&#x60;&#x60;   #### removeBigSegmentExcludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Removes context keys from the context targets excluded from the segment.  ##### Parameters  - &#x60;values&#x60;: List of context keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeBigSegmentExcludedTargets\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  #### removeBigSegmentIncludedTargets  For use with [larger list-based segments](https://docs.launchdarkly.com/home/flags/segments-create#create-larger-list-based-segments) ONLY. Removes context keys from the context targets included in the segment.  ##### Parameters  - &#x60;values&#x60;: List of context keys.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;removeBigSegmentIncludedTargets\&quot;,     \&quot;values\&quot;: [ \&quot;org-key-123abc\&quot;, \&quot;org-key-456def\&quot; ]   }] } &#x60;&#x60;&#x60;  &lt;/details&gt;  ### Using JSON patches on a segment  If you do not include the header described above, you can use a [JSON patch](/reference#updates-using-json-patch) or [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) representation of the desired changes.  For example, to update the description for a segment with a JSON patch, use the following request body:  &#x60;&#x60;&#x60;json {   \&quot;patch\&quot;: [     {       \&quot;op\&quot;: \&quot;replace\&quot;,       \&quot;path\&quot;: \&quot;/description\&quot;,       \&quot;value\&quot;: \&quot;new description\&quot;     }   ] } &#x60;&#x60;&#x60;  To update fields in the segment that are arrays, set the &#x60;path&#x60; to the name of the field and then append &#x60;/&lt;array index&gt;&#x60;. Use &#x60;/0&#x60; to add the new entry to the beginning of the array. Use &#x60;/-&#x60; to add the new entry to the end of the array.  For example, to add a rule to a segment, use the following request body:  &#x60;&#x60;&#x60;json {   \&quot;patch\&quot;:[     {       \&quot;op\&quot;: \&quot;add\&quot;,       \&quot;path\&quot;: \&quot;/rules/0\&quot;,       \&quot;value\&quot;: {         \&quot;clauses\&quot;: [{ \&quot;contextKind\&quot;: \&quot;user\&quot;, \&quot;attribute\&quot;: \&quot;email\&quot;, \&quot;op\&quot;: \&quot;endsWith\&quot;, \&quot;values\&quot;: [\&quot;.edu\&quot;], \&quot;negate\&quot;: false }]       }     }   ] } &#x60;&#x60;&#x60;  To add or remove targets from segments, we recommend using semantic patch. Semantic patch for segments includes specific instructions for adding and removing both included and excluded targets. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param patch_with_comment [PatchWithComment] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(UserSegment, Integer, Hash)>] UserSegment data, response status code and response headers
    def patch_segment_with_http_info(project_key, environment_key, segment_key, patch_with_comment, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.patch_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.patch_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.patch_segment"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.patch_segment"
      end
      # verify the required parameter 'patch_with_comment' is set
      if @api_client.config.client_side_validation && patch_with_comment.nil?
        fail ArgumentError, "Missing the required parameter 'patch_with_comment' when calling SegmentsApi.patch_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(patch_with_comment)

      # return_type
      return_type = opts[:debug_return_type] || 'UserSegment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.patch_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:PATCH, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#patch_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Create segment
    # Create a new segment.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_body [SegmentBody] 
    # @param [Hash] opts the optional parameters
    # @return [UserSegment]
    def post_segment(project_key, environment_key, segment_body, opts = {})
      data, _status_code, _headers = post_segment_with_http_info(project_key, environment_key, segment_body, opts)
      data
    end

    # Create segment
    # Create a new segment.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_body [SegmentBody] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(UserSegment, Integer, Hash)>] UserSegment data, response status code and response headers
    def post_segment_with_http_info(project_key, environment_key, segment_body, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.post_segment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.post_segment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.post_segment"
      end
      # verify the required parameter 'segment_body' is set
      if @api_client.config.client_side_validation && segment_body.nil?
        fail ArgumentError, "Missing the required parameter 'segment_body' when calling SegmentsApi.post_segment"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(segment_body)

      # return_type
      return_type = opts[:debug_return_type] || 'UserSegment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.post_segment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#post_segment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Update context targets on a big segment
    # Update context targets included or excluded in a big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param segment_user_state [SegmentUserState] 
    # @param [Hash] opts the optional parameters
    # @return [nil]
    def update_big_segment_context_targets(project_key, environment_key, segment_key, segment_user_state, opts = {})
      update_big_segment_context_targets_with_http_info(project_key, environment_key, segment_key, segment_user_state, opts)
      nil
    end

    # Update context targets on a big segment
    # Update context targets included or excluded in a big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param segment_user_state [SegmentUserState] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(nil, Integer, Hash)>] nil, response status code and response headers
    def update_big_segment_context_targets_with_http_info(project_key, environment_key, segment_key, segment_user_state, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.update_big_segment_context_targets ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.update_big_segment_context_targets"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.update_big_segment_context_targets"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.update_big_segment_context_targets"
      end
      # verify the required parameter 'segment_user_state' is set
      if @api_client.config.client_side_validation && segment_user_state.nil?
        fail ArgumentError, "Missing the required parameter 'segment_user_state' when calling SegmentsApi.update_big_segment_context_targets"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(segment_user_state)

      # return_type
      return_type = opts[:debug_return_type]

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.update_big_segment_context_targets",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#update_big_segment_context_targets\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Update user context targets on a big segment
    # Update user context targets included or excluded in a big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param segment_user_state [SegmentUserState] 
    # @param [Hash] opts the optional parameters
    # @return [nil]
    def update_big_segment_targets(project_key, environment_key, segment_key, segment_user_state, opts = {})
      update_big_segment_targets_with_http_info(project_key, environment_key, segment_key, segment_user_state, opts)
      nil
    end

    # Update user context targets on a big segment
    # Update user context targets included or excluded in a big segment. Big segments include larger list-based segments and synced segments. This operation does not support standard segments.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param segment_key [String] The segment key
    # @param segment_user_state [SegmentUserState] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(nil, Integer, Hash)>] nil, response status code and response headers
    def update_big_segment_targets_with_http_info(project_key, environment_key, segment_key, segment_user_state, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: SegmentsApi.update_big_segment_targets ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling SegmentsApi.update_big_segment_targets"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling SegmentsApi.update_big_segment_targets"
      end
      # verify the required parameter 'segment_key' is set
      if @api_client.config.client_side_validation && segment_key.nil?
        fail ArgumentError, "Missing the required parameter 'segment_key' when calling SegmentsApi.update_big_segment_targets"
      end
      # verify the required parameter 'segment_user_state' is set
      if @api_client.config.client_side_validation && segment_user_state.nil?
        fail ArgumentError, "Missing the required parameter 'segment_user_state' when calling SegmentsApi.update_big_segment_targets"
      end
      # resource path
      local_var_path = '/api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'segmentKey' + '}', CGI.escape(segment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']
      # HTTP header 'Content-Type'
      content_type = @api_client.select_header_content_type(['application/json'])
      if !content_type.nil?
          header_params['Content-Type'] = content_type
      end

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body] || @api_client.object_to_http_body(segment_user_state)

      # return_type
      return_type = opts[:debug_return_type]

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"SegmentsApi.update_big_segment_targets",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: SegmentsApi#update_big_segment_targets\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end
  end
end
