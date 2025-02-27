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
  class ExperimentsApi
    attr_accessor :api_client

    def initialize(api_client = ApiClient.default)
      @api_client = api_client
    end
    # Create experiment
    # Create an experiment.  To run this experiment, you'll need to [create an iteration](/tag/Experiments-(beta)#operation/createIteration) and then [update the experiment](/tag/Experiments-(beta)#operation/patchExperiment) with the `startIteration` instruction.  To learn more, read [Creating experiments](https://docs.launchdarkly.com/home/experimentation/create). 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_post [ExperimentPost] 
    # @param [Hash] opts the optional parameters
    # @return [Experiment]
    def create_experiment(project_key, environment_key, experiment_post, opts = {})
      data, _status_code, _headers = create_experiment_with_http_info(project_key, environment_key, experiment_post, opts)
      data
    end

    # Create experiment
    # Create an experiment.  To run this experiment, you&#39;ll need to [create an iteration](/tag/Experiments-(beta)#operation/createIteration) and then [update the experiment](/tag/Experiments-(beta)#operation/patchExperiment) with the &#x60;startIteration&#x60; instruction.  To learn more, read [Creating experiments](https://docs.launchdarkly.com/home/experimentation/create). 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_post [ExperimentPost] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(Experiment, Integer, Hash)>] Experiment data, response status code and response headers
    def create_experiment_with_http_info(project_key, environment_key, experiment_post, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.create_experiment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.create_experiment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.create_experiment"
      end
      # verify the required parameter 'experiment_post' is set
      if @api_client.config.client_side_validation && experiment_post.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_post' when calling ExperimentsApi.create_experiment"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s))

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
      post_body = opts[:debug_body] || @api_client.object_to_http_body(experiment_post)

      # return_type
      return_type = opts[:debug_return_type] || 'Experiment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.create_experiment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#create_experiment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Create iteration
    # Create an experiment iteration.  Experiment iterations let you record experiments in individual blocks of time. Initially, iterations are created with a status of `not_started` and appear in the `draftIteration` field of an experiment. To start or stop an iteration, [update the experiment](/tag/Experiments-(beta)#operation/patchExperiment) with the `startIteration` or `stopIteration` instruction.   To learn more, read [Start experiment iterations](https://docs.launchdarkly.com/home/experimentation/feature#start-experiment-iterations). 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param iteration_input [IterationInput] 
    # @param [Hash] opts the optional parameters
    # @return [IterationRep]
    def create_iteration(project_key, environment_key, experiment_key, iteration_input, opts = {})
      data, _status_code, _headers = create_iteration_with_http_info(project_key, environment_key, experiment_key, iteration_input, opts)
      data
    end

    # Create iteration
    # Create an experiment iteration.  Experiment iterations let you record experiments in individual blocks of time. Initially, iterations are created with a status of &#x60;not_started&#x60; and appear in the &#x60;draftIteration&#x60; field of an experiment. To start or stop an iteration, [update the experiment](/tag/Experiments-(beta)#operation/patchExperiment) with the &#x60;startIteration&#x60; or &#x60;stopIteration&#x60; instruction.   To learn more, read [Start experiment iterations](https://docs.launchdarkly.com/home/experimentation/feature#start-experiment-iterations). 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param iteration_input [IterationInput] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(IterationRep, Integer, Hash)>] IterationRep data, response status code and response headers
    def create_iteration_with_http_info(project_key, environment_key, experiment_key, iteration_input, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.create_iteration ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.create_iteration"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.create_iteration"
      end
      # verify the required parameter 'experiment_key' is set
      if @api_client.config.client_side_validation && experiment_key.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_key' when calling ExperimentsApi.create_iteration"
      end
      # verify the required parameter 'iteration_input' is set
      if @api_client.config.client_side_validation && iteration_input.nil?
        fail ArgumentError, "Missing the required parameter 'iteration_input' when calling ExperimentsApi.create_iteration"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/iterations'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'experimentKey' + '}', CGI.escape(experiment_key.to_s))

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
      post_body = opts[:debug_body] || @api_client.object_to_http_body(iteration_input)

      # return_type
      return_type = opts[:debug_return_type] || 'IterationRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.create_iteration",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:POST, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#create_iteration\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get experiment
    # Get details about an experiment.  ### Expanding the experiment response  LaunchDarkly supports four fields for expanding the \"Get experiment\" response. By default, these fields are **not** included in the response.  To expand the response, append the `expand` query parameter and add a comma-separated list with any of the following fields:  - `previousIterations` includes all iterations prior to the current iteration. By default only the current iteration is included in the response. - `draftIteration` includes the iteration which has not been started yet, if any. - `secondaryMetrics` includes secondary metrics. By default only the primary metric is included in the response. - `treatments` includes all treatment and parameter details. By default treatment data is not included in the response.  For example, `expand=draftIteration,treatments` includes the `draftIteration` and `treatments` fields in the response. If fields that you request with the `expand` query parameter are empty, they are not included in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :expand A comma-separated list of properties that can reveal additional information in the response. Supported fields are explained above.
    # @return [Experiment]
    def get_experiment(project_key, environment_key, experiment_key, opts = {})
      data, _status_code, _headers = get_experiment_with_http_info(project_key, environment_key, experiment_key, opts)
      data
    end

    # Get experiment
    # Get details about an experiment.  ### Expanding the experiment response  LaunchDarkly supports four fields for expanding the \&quot;Get experiment\&quot; response. By default, these fields are **not** included in the response.  To expand the response, append the &#x60;expand&#x60; query parameter and add a comma-separated list with any of the following fields:  - &#x60;previousIterations&#x60; includes all iterations prior to the current iteration. By default only the current iteration is included in the response. - &#x60;draftIteration&#x60; includes the iteration which has not been started yet, if any. - &#x60;secondaryMetrics&#x60; includes secondary metrics. By default only the primary metric is included in the response. - &#x60;treatments&#x60; includes all treatment and parameter details. By default treatment data is not included in the response.  For example, &#x60;expand&#x3D;draftIteration,treatments&#x60; includes the &#x60;draftIteration&#x60; and &#x60;treatments&#x60; fields in the response. If fields that you request with the &#x60;expand&#x60; query parameter are empty, they are not included in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :expand A comma-separated list of properties that can reveal additional information in the response. Supported fields are explained above.
    # @return [Array<(Experiment, Integer, Hash)>] Experiment data, response status code and response headers
    def get_experiment_with_http_info(project_key, environment_key, experiment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.get_experiment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.get_experiment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.get_experiment"
      end
      # verify the required parameter 'experiment_key' is set
      if @api_client.config.client_side_validation && experiment_key.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_key' when calling ExperimentsApi.get_experiment"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'experimentKey' + '}', CGI.escape(experiment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}
      query_params[:'expand'] = opts[:'expand'] if !opts[:'expand'].nil?

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'Experiment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.get_experiment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#get_experiment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get experiment results
    # Get results from an experiment for a particular metric.  LaunchDarkly supports one field for expanding the \"Get experiment results\" response. By default, this field is **not** included in the response.  To expand the response, append the `expand` query parameter with the following field: * `traffic` includes the total count of units for each treatment.  For example, `expand=traffic` includes the `traffic` field for the project in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param metric_key [String] The metric key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :iteration_id The iteration ID
    # @option opts [String] :expand A comma-separated list of fields to expand in the response. Supported fields are explained above.
    # @return [ExperimentBayesianResultsRep]
    def get_experiment_results(project_key, environment_key, experiment_key, metric_key, opts = {})
      data, _status_code, _headers = get_experiment_results_with_http_info(project_key, environment_key, experiment_key, metric_key, opts)
      data
    end

    # Get experiment results
    # Get results from an experiment for a particular metric.  LaunchDarkly supports one field for expanding the \&quot;Get experiment results\&quot; response. By default, this field is **not** included in the response.  To expand the response, append the &#x60;expand&#x60; query parameter with the following field: * &#x60;traffic&#x60; includes the total count of units for each treatment.  For example, &#x60;expand&#x3D;traffic&#x60; includes the &#x60;traffic&#x60; field for the project in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param metric_key [String] The metric key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :iteration_id The iteration ID
    # @option opts [String] :expand A comma-separated list of fields to expand in the response. Supported fields are explained above.
    # @return [Array<(ExperimentBayesianResultsRep, Integer, Hash)>] ExperimentBayesianResultsRep data, response status code and response headers
    def get_experiment_results_with_http_info(project_key, environment_key, experiment_key, metric_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.get_experiment_results ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.get_experiment_results"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.get_experiment_results"
      end
      # verify the required parameter 'experiment_key' is set
      if @api_client.config.client_side_validation && experiment_key.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_key' when calling ExperimentsApi.get_experiment_results"
      end
      # verify the required parameter 'metric_key' is set
      if @api_client.config.client_side_validation && metric_key.nil?
        fail ArgumentError, "Missing the required parameter 'metric_key' when calling ExperimentsApi.get_experiment_results"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metrics/{metricKey}/results'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'experimentKey' + '}', CGI.escape(experiment_key.to_s)).sub('{' + 'metricKey' + '}', CGI.escape(metric_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}
      query_params[:'iterationId'] = opts[:'iteration_id'] if !opts[:'iteration_id'].nil?
      query_params[:'expand'] = opts[:'expand'] if !opts[:'expand'].nil?

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'ExperimentBayesianResultsRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.get_experiment_results",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#get_experiment_results\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get experiment results for metric group
    # Get results from an experiment for a particular metric group.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param metric_group_key [String] The metric group key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :iteration_id The iteration ID
    # @return [MetricGroupResultsRep]
    def get_experiment_results_for_metric_group(project_key, environment_key, experiment_key, metric_group_key, opts = {})
      data, _status_code, _headers = get_experiment_results_for_metric_group_with_http_info(project_key, environment_key, experiment_key, metric_group_key, opts)
      data
    end

    # Get experiment results for metric group
    # Get results from an experiment for a particular metric group.
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param metric_group_key [String] The metric group key
    # @param [Hash] opts the optional parameters
    # @option opts [String] :iteration_id The iteration ID
    # @return [Array<(MetricGroupResultsRep, Integer, Hash)>] MetricGroupResultsRep data, response status code and response headers
    def get_experiment_results_for_metric_group_with_http_info(project_key, environment_key, experiment_key, metric_group_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.get_experiment_results_for_metric_group ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.get_experiment_results_for_metric_group"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.get_experiment_results_for_metric_group"
      end
      # verify the required parameter 'experiment_key' is set
      if @api_client.config.client_side_validation && experiment_key.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_key' when calling ExperimentsApi.get_experiment_results_for_metric_group"
      end
      # verify the required parameter 'metric_group_key' is set
      if @api_client.config.client_side_validation && metric_group_key.nil?
        fail ArgumentError, "Missing the required parameter 'metric_group_key' when calling ExperimentsApi.get_experiment_results_for_metric_group"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metric-groups/{metricGroupKey}/results'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'experimentKey' + '}', CGI.escape(experiment_key.to_s)).sub('{' + 'metricGroupKey' + '}', CGI.escape(metric_group_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}
      query_params[:'iterationId'] = opts[:'iteration_id'] if !opts[:'iteration_id'].nil?

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'MetricGroupResultsRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.get_experiment_results_for_metric_group",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#get_experiment_results_for_metric_group\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get experimentation settings
    # Get current experimentation settings for the given project
    # @param project_key [String] The project key
    # @param [Hash] opts the optional parameters
    # @return [RandomizationSettingsRep]
    def get_experimentation_settings(project_key, opts = {})
      data, _status_code, _headers = get_experimentation_settings_with_http_info(project_key, opts)
      data
    end

    # Get experimentation settings
    # Get current experimentation settings for the given project
    # @param project_key [String] The project key
    # @param [Hash] opts the optional parameters
    # @return [Array<(RandomizationSettingsRep, Integer, Hash)>] RandomizationSettingsRep data, response status code and response headers
    def get_experimentation_settings_with_http_info(project_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.get_experimentation_settings ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.get_experimentation_settings"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/experimentation-settings'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s))

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
      return_type = opts[:debug_return_type] || 'RandomizationSettingsRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.get_experimentation_settings",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#get_experimentation_settings\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Get experiments
    # Get details about all experiments in an environment.  ### Filtering experiments  LaunchDarkly supports the `filter` query param for filtering, with the following fields:  - `flagKey` filters for only experiments that use the flag with the given key. - `metricKey` filters for only experiments that use the metric with the given key. - `status` filters for only experiments with an iteration with the given status. An iteration can have the status `not_started`, `running` or `stopped`.  For example, `filter=flagKey:my-flag,status:running,metricKey:page-load-ms` filters for experiments for the given flag key and the given metric key which have a currently running iteration.  ### Expanding the experiments response  LaunchDarkly supports four fields for expanding the \"Get experiments\" response. By default, these fields are **not** included in the response.  To expand the response, append the `expand` query parameter and add a comma-separated list with any of the following fields:  - `previousIterations` includes all iterations prior to the current iteration. By default only the current iteration is included in the response. - `draftIteration` includes the iteration which has not been started yet, if any. - `secondaryMetrics` includes secondary metrics. By default only the primary metric is included in the response. - `treatments` includes all treatment and parameter details. By default treatment data is not included in the response.  For example, `expand=draftIteration,treatments` includes the `draftIteration` and `treatments` fields in the response. If fields that you request with the `expand` query parameter are empty, they are not included in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param [Hash] opts the optional parameters
    # @option opts [Integer] :limit The maximum number of experiments to return. Defaults to 20.
    # @option opts [Integer] :offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;.
    # @option opts [String] :filter A comma-separated list of filters. Each filter is of the form &#x60;field:value&#x60;. Supported fields are explained above.
    # @option opts [String] :expand A comma-separated list of properties that can reveal additional information in the response. Supported fields are explained above.
    # @option opts [String] :lifecycle_state A comma-separated list of experiment archived states. Supports &#x60;archived&#x60;, &#x60;active&#x60;, or both. Defaults to &#x60;active&#x60; experiments.
    # @return [ExperimentCollectionRep]
    def get_experiments(project_key, environment_key, opts = {})
      data, _status_code, _headers = get_experiments_with_http_info(project_key, environment_key, opts)
      data
    end

    # Get experiments
    # Get details about all experiments in an environment.  ### Filtering experiments  LaunchDarkly supports the &#x60;filter&#x60; query param for filtering, with the following fields:  - &#x60;flagKey&#x60; filters for only experiments that use the flag with the given key. - &#x60;metricKey&#x60; filters for only experiments that use the metric with the given key. - &#x60;status&#x60; filters for only experiments with an iteration with the given status. An iteration can have the status &#x60;not_started&#x60;, &#x60;running&#x60; or &#x60;stopped&#x60;.  For example, &#x60;filter&#x3D;flagKey:my-flag,status:running,metricKey:page-load-ms&#x60; filters for experiments for the given flag key and the given metric key which have a currently running iteration.  ### Expanding the experiments response  LaunchDarkly supports four fields for expanding the \&quot;Get experiments\&quot; response. By default, these fields are **not** included in the response.  To expand the response, append the &#x60;expand&#x60; query parameter and add a comma-separated list with any of the following fields:  - &#x60;previousIterations&#x60; includes all iterations prior to the current iteration. By default only the current iteration is included in the response. - &#x60;draftIteration&#x60; includes the iteration which has not been started yet, if any. - &#x60;secondaryMetrics&#x60; includes secondary metrics. By default only the primary metric is included in the response. - &#x60;treatments&#x60; includes all treatment and parameter details. By default treatment data is not included in the response.  For example, &#x60;expand&#x3D;draftIteration,treatments&#x60; includes the &#x60;draftIteration&#x60; and &#x60;treatments&#x60; fields in the response. If fields that you request with the &#x60;expand&#x60; query parameter are empty, they are not included in the response. 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param [Hash] opts the optional parameters
    # @option opts [Integer] :limit The maximum number of experiments to return. Defaults to 20.
    # @option opts [Integer] :offset Where to start in the list. Use this with pagination. For example, an offset of 10 skips the first ten items and then returns the next items in the list, up to the query &#x60;limit&#x60;.
    # @option opts [String] :filter A comma-separated list of filters. Each filter is of the form &#x60;field:value&#x60;. Supported fields are explained above.
    # @option opts [String] :expand A comma-separated list of properties that can reveal additional information in the response. Supported fields are explained above.
    # @option opts [String] :lifecycle_state A comma-separated list of experiment archived states. Supports &#x60;archived&#x60;, &#x60;active&#x60;, or both. Defaults to &#x60;active&#x60; experiments.
    # @return [Array<(ExperimentCollectionRep, Integer, Hash)>] ExperimentCollectionRep data, response status code and response headers
    def get_experiments_with_http_info(project_key, environment_key, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.get_experiments ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.get_experiments"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.get_experiments"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s))

      # query parameters
      query_params = opts[:query_params] || {}
      query_params[:'limit'] = opts[:'limit'] if !opts[:'limit'].nil?
      query_params[:'offset'] = opts[:'offset'] if !opts[:'offset'].nil?
      query_params[:'filter'] = opts[:'filter'] if !opts[:'filter'].nil?
      query_params[:'expand'] = opts[:'expand'] if !opts[:'expand'].nil?
      query_params[:'lifecycleState'] = opts[:'lifecycle_state'] if !opts[:'lifecycle_state'].nil?

      # header parameters
      header_params = opts[:header_params] || {}
      # HTTP header 'Accept' (if needed)
      header_params['Accept'] = @api_client.select_header_accept(['application/json']) unless header_params['Accept']

      # form parameters
      form_params = opts[:form_params] || {}

      # http body (model)
      post_body = opts[:debug_body]

      # return_type
      return_type = opts[:debug_return_type] || 'ExperimentCollectionRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.get_experiments",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:GET, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#get_experiments\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Patch experiment
    # Update an experiment. Updating an experiment uses the semantic patch format.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  ### Instructions  Semantic patch requests support the following `kind` instructions for updating experiments.  #### updateName  Updates the experiment name.  ##### Parameters  - `value`: The new name.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateName\",     \"value\": \"Example updated experiment name\"   }] } ```  #### updateDescription  Updates the experiment description.  ##### Parameters  - `value`: The new description.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"updateDescription\",     \"value\": \"Example updated description\"   }] } ```  #### startIteration  Starts a new iteration for this experiment. You must [create a new iteration](/tag/Experiments-(beta)#operation/createIteration) before calling this instruction.  An iteration may not be started until it meets the following criteria:  * Its associated flag is toggled on and is not archived * Its `randomizationUnit` is set * At least one of its `treatments` has a non-zero `allocationPercent`  ##### Parameters  - `changeJustification`: The reason for starting a new iteration. Required when you call `startIteration` on an already running experiment, otherwise optional.  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"startIteration\",     \"changeJustification\": \"It's time to start a new iteration\"   }] } ```  #### stopIteration  Stops the current iteration for this experiment.  ##### Parameters  - `winningTreatmentId`: The ID of the winning treatment. Treatment IDs are returned as part of the [Get experiment](/tag/Experiments-(beta)#operation/getExperiment) response. They are the `_id` of each element in the `treatments` array. - `winningReason`: The reason for the winner  Here's an example:  ```json {   \"instructions\": [{     \"kind\": \"stopIteration\",     \"winningTreatmentId\": \"3a548ec2-72ac-4e59-8518-5c24f5609ccf\",     \"winningReason\": \"Example reason to stop the iteration\"   }] } ```  #### archiveExperiment  Archives this experiment. Archived experiments are hidden by default in the LaunchDarkly user interface. You cannot start new iterations for archived experiments.  Here's an example:  ```json {   \"instructions\": [{ \"kind\": \"archiveExperiment\" }] } ```  #### restoreExperiment  Restores an archived experiment. After restoring an experiment, you can start new iterations for it again.  Here's an example:  ```json {   \"instructions\": [{ \"kind\": \"restoreExperiment\" }] } ``` 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param experiment_patch_input [ExperimentPatchInput] 
    # @param [Hash] opts the optional parameters
    # @return [Experiment]
    def patch_experiment(project_key, environment_key, experiment_key, experiment_patch_input, opts = {})
      data, _status_code, _headers = patch_experiment_with_http_info(project_key, environment_key, experiment_key, experiment_patch_input, opts)
      data
    end

    # Patch experiment
    # Update an experiment. Updating an experiment uses the semantic patch format.  To make a semantic patch request, you must append &#x60;domain-model&#x3D;launchdarkly.semanticpatch&#x60; to your &#x60;Content-Type&#x60; header. To learn more, read [Updates using semantic patch](/reference#updates-using-semantic-patch).  ### Instructions  Semantic patch requests support the following &#x60;kind&#x60; instructions for updating experiments.  #### updateName  Updates the experiment name.  ##### Parameters  - &#x60;value&#x60;: The new name.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateName\&quot;,     \&quot;value\&quot;: \&quot;Example updated experiment name\&quot;   }] } &#x60;&#x60;&#x60;  #### updateDescription  Updates the experiment description.  ##### Parameters  - &#x60;value&#x60;: The new description.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;updateDescription\&quot;,     \&quot;value\&quot;: \&quot;Example updated description\&quot;   }] } &#x60;&#x60;&#x60;  #### startIteration  Starts a new iteration for this experiment. You must [create a new iteration](/tag/Experiments-(beta)#operation/createIteration) before calling this instruction.  An iteration may not be started until it meets the following criteria:  * Its associated flag is toggled on and is not archived * Its &#x60;randomizationUnit&#x60; is set * At least one of its &#x60;treatments&#x60; has a non-zero &#x60;allocationPercent&#x60;  ##### Parameters  - &#x60;changeJustification&#x60;: The reason for starting a new iteration. Required when you call &#x60;startIteration&#x60; on an already running experiment, otherwise optional.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;startIteration\&quot;,     \&quot;changeJustification\&quot;: \&quot;It&#39;s time to start a new iteration\&quot;   }] } &#x60;&#x60;&#x60;  #### stopIteration  Stops the current iteration for this experiment.  ##### Parameters  - &#x60;winningTreatmentId&#x60;: The ID of the winning treatment. Treatment IDs are returned as part of the [Get experiment](/tag/Experiments-(beta)#operation/getExperiment) response. They are the &#x60;_id&#x60; of each element in the &#x60;treatments&#x60; array. - &#x60;winningReason&#x60;: The reason for the winner  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{     \&quot;kind\&quot;: \&quot;stopIteration\&quot;,     \&quot;winningTreatmentId\&quot;: \&quot;3a548ec2-72ac-4e59-8518-5c24f5609ccf\&quot;,     \&quot;winningReason\&quot;: \&quot;Example reason to stop the iteration\&quot;   }] } &#x60;&#x60;&#x60;  #### archiveExperiment  Archives this experiment. Archived experiments are hidden by default in the LaunchDarkly user interface. You cannot start new iterations for archived experiments.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{ \&quot;kind\&quot;: \&quot;archiveExperiment\&quot; }] } &#x60;&#x60;&#x60;  #### restoreExperiment  Restores an archived experiment. After restoring an experiment, you can start new iterations for it again.  Here&#39;s an example:  &#x60;&#x60;&#x60;json {   \&quot;instructions\&quot;: [{ \&quot;kind\&quot;: \&quot;restoreExperiment\&quot; }] } &#x60;&#x60;&#x60; 
    # @param project_key [String] The project key
    # @param environment_key [String] The environment key
    # @param experiment_key [String] The experiment key
    # @param experiment_patch_input [ExperimentPatchInput] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(Experiment, Integer, Hash)>] Experiment data, response status code and response headers
    def patch_experiment_with_http_info(project_key, environment_key, experiment_key, experiment_patch_input, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.patch_experiment ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.patch_experiment"
      end
      # verify the required parameter 'environment_key' is set
      if @api_client.config.client_side_validation && environment_key.nil?
        fail ArgumentError, "Missing the required parameter 'environment_key' when calling ExperimentsApi.patch_experiment"
      end
      # verify the required parameter 'experiment_key' is set
      if @api_client.config.client_side_validation && experiment_key.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_key' when calling ExperimentsApi.patch_experiment"
      end
      # verify the required parameter 'experiment_patch_input' is set
      if @api_client.config.client_side_validation && experiment_patch_input.nil?
        fail ArgumentError, "Missing the required parameter 'experiment_patch_input' when calling ExperimentsApi.patch_experiment"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s)).sub('{' + 'environmentKey' + '}', CGI.escape(environment_key.to_s)).sub('{' + 'experimentKey' + '}', CGI.escape(experiment_key.to_s))

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
      post_body = opts[:debug_body] || @api_client.object_to_http_body(experiment_patch_input)

      # return_type
      return_type = opts[:debug_return_type] || 'Experiment'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.patch_experiment",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:PATCH, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#patch_experiment\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end

    # Update experimentation settings
    # Update experimentation settings for the given project
    # @param project_key [String] The project key
    # @param randomization_settings_put [RandomizationSettingsPut] 
    # @param [Hash] opts the optional parameters
    # @return [RandomizationSettingsRep]
    def put_experimentation_settings(project_key, randomization_settings_put, opts = {})
      data, _status_code, _headers = put_experimentation_settings_with_http_info(project_key, randomization_settings_put, opts)
      data
    end

    # Update experimentation settings
    # Update experimentation settings for the given project
    # @param project_key [String] The project key
    # @param randomization_settings_put [RandomizationSettingsPut] 
    # @param [Hash] opts the optional parameters
    # @return [Array<(RandomizationSettingsRep, Integer, Hash)>] RandomizationSettingsRep data, response status code and response headers
    def put_experimentation_settings_with_http_info(project_key, randomization_settings_put, opts = {})
      if @api_client.config.debugging
        @api_client.config.logger.debug 'Calling API: ExperimentsApi.put_experimentation_settings ...'
      end
      # verify the required parameter 'project_key' is set
      if @api_client.config.client_side_validation && project_key.nil?
        fail ArgumentError, "Missing the required parameter 'project_key' when calling ExperimentsApi.put_experimentation_settings"
      end
      # verify the required parameter 'randomization_settings_put' is set
      if @api_client.config.client_side_validation && randomization_settings_put.nil?
        fail ArgumentError, "Missing the required parameter 'randomization_settings_put' when calling ExperimentsApi.put_experimentation_settings"
      end
      # resource path
      local_var_path = '/api/v2/projects/{projectKey}/experimentation-settings'.sub('{' + 'projectKey' + '}', CGI.escape(project_key.to_s))

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
      post_body = opts[:debug_body] || @api_client.object_to_http_body(randomization_settings_put)

      # return_type
      return_type = opts[:debug_return_type] || 'RandomizationSettingsRep'

      # auth_names
      auth_names = opts[:debug_auth_names] || ['ApiKey']

      new_options = opts.merge(
        :operation => :"ExperimentsApi.put_experimentation_settings",
        :header_params => header_params,
        :query_params => query_params,
        :form_params => form_params,
        :body => post_body,
        :auth_names => auth_names,
        :return_type => return_type
      )

      data, status_code, headers = @api_client.call_api(:PUT, local_var_path, new_options)
      if @api_client.config.debugging
        @api_client.config.logger.debug "API called: ExperimentsApi#put_experimentation_settings\nData: #{data.inspect}\nStatus code: #{status_code}\nHeaders: #{headers}"
      end
      return data, status_code, headers
    end
  end
end
