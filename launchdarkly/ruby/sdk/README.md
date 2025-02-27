# launchdarkly_client

LaunchDarklyClient - the Ruby gem for the LaunchDarkly REST API

# Overview

## Authentication

LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.

All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.

LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.

| Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          |
| ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | -------------------------------------------------- |
| [Personal or service access tokens](https://docs.launchdarkly.com/home/account/api) | Can be customized on a per-token basis                                                                | Building scripts, custom integrations, data export. |
| SDK keys                                                                                        | Can only access read-only resources specific to server-side SDKs. Restricted to a single environment. | Server-side SDKs                     |
| Mobile keys                                                                                     | Can only access read-only resources specific to mobile SDKs, and only for flags marked available to mobile keys. Restricted to a single environment.           | Mobile SDKs                                        |
| Client-side ID                                                                                  | Can only access read-only resources specific to JavaScript-based client-side SDKs, and only for flags marked available to client-side. Restricted to a single environment.           | Client-side JavaScript                             |

> #### Keep your access tokens and SDK keys private
>
> Access tokens should _never_ be exposed in untrusted contexts. Never put an access token in client-side JavaScript, or embed it in a mobile application. LaunchDarkly has special mobile keys that you can embed in mobile apps. If you accidentally expose an access token or SDK key, you can reset it from your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.
>
> The client-side ID is safe to embed in untrusted contexts. It's designed for use in client-side JavaScript.

### Authentication using request header

The preferred way to authenticate with the API is by adding an `Authorization` header containing your access token to your requests. The value of the `Authorization` header must be your access token.

Manage personal access tokens from the [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.

### Authentication using session cookie

For testing purposes, you can make API calls directly from your web browser. If you are logged in to the LaunchDarkly application, the API will use your existing session to authenticate calls.

If you have a [role](https://docs.launchdarkly.com/home/account/built-in-roles) other than Admin, or have a [custom role](https://docs.launchdarkly.com/home/account/custom-roles) defined, you may not have permission to perform some API calls. You will receive a `401` response code in that case.

> ### Modifying the Origin header causes an error
>
> LaunchDarkly validates that the Origin header for any API request authenticated by a session cookie matches the expected Origin header. The expected Origin header is `https://app.launchdarkly.com`.
>
> If the Origin header does not match what's expected, LaunchDarkly returns an error. This error can prevent the LaunchDarkly app from working correctly.
>
> Any browser extension that intentionally changes the Origin header can cause this problem. For example, the `Allow-Control-Allow-Origin: *` Chrome extension changes the Origin header to `http://evil.com` and causes the app to fail.
>
> To prevent this error, do not modify your Origin header.
>
> LaunchDarkly does not require origin matching when authenticating with an access token, so this issue does not affect normal API usage.

## Representations

All resources expect and return JSON response bodies. Error responses also send a JSON body. To learn more about the error format of the API, read [Errors](/#section/Overview/Errors).

In practice this means that you always get a response with a `Content-Type` header set to `application/json`.

In addition, request bodies for `PATCH`, `POST`, and `PUT` requests must be encoded as JSON with a `Content-Type` header set to `application/json`.

### Summary and detailed representations

When you fetch a list of resources, the response includes only the most important attributes of each resource. This is a _summary representation_ of the resource. When you fetch an individual resource, such as a single feature flag, you receive a _detailed representation_ of the resource.

The best way to find a detailed representation is to follow links. Every summary representation includes a link to its detailed representation.

### Expanding responses

Sometimes the detailed representation of a resource does not include all of the attributes of the resource by default. If this is the case, the request method will clearly document this and describe which attributes you can include in an expanded response.

To include the additional attributes, append the `expand` request parameter to your request and add a comma-separated list of the attributes to include. For example, when you append `?expand=members,maintainers` to the [Get team](/tag/Teams#operation/getTeam) endpoint, the expanded response includes both of these attributes.

### Links and addressability

The best way to navigate the API is by following links. These are attributes in representations that link to other resources. The API always uses the same format for links:

- Links to other resources within the API are encapsulated in a `_links` object
- If the resource has a corresponding link to HTML content on the site, it is stored in a special `_site` link

Each link has two attributes:

- An `href`, which contains the URL
- A `type`, which describes the content type

For example, a feature resource might return the following:

```json
{
  \"_links\": {
    \"parent\": {
      \"href\": \"/api/features\",
      \"type\": \"application/json\"
    },
    \"self\": {
      \"href\": \"/api/features/sort.order\",
      \"type\": \"application/json\"
    }
  },
  \"_site\": {
    \"href\": \"/features/sort.order\",
    \"type\": \"text/html\"
  }
}
```

From this, you can navigate to the parent collection of features by following the `parent` link, or navigate to the site page for the feature by following the `_site` link.

Collections are always represented as a JSON object with an `items` attribute containing an array of representations. Like all other representations, collections have `_links` defined at the top level.

Paginated collections include `first`, `last`, `next`, and `prev` links containing a URL with the respective set of elements in the collection.

## Updates

Resources that accept partial updates use the `PATCH` verb. Most resources support the [JSON patch](/reference#updates-using-json-patch) format. Some resources also support the [JSON merge patch](/reference#updates-using-json-merge-patch) format, and some resources support the [semantic patch](/reference#updates-using-semantic-patch) format, which is a way to specify the modifications to perform as a set of executable instructions. Each resource supports optional [comments](/reference#updates-with-comments) that you can submit with updates. Comments appear in outgoing webhooks, the audit log, and other integrations.

When a resource supports both JSON patch and semantic patch, we document both in the request method. However, the specific request body fields and descriptions included in our documentation only match one type of patch or the other.

### Updates using JSON patch

[JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) is a way to specify the modifications to perform on a resource. JSON patch uses paths and a limited set of operations to describe how to transform the current state of the resource into a new state. JSON patch documents are always arrays, where each element contains an operation, a path to the field to update, and the new value.

For example, in this feature flag representation:

```json
{
    \"name\": \"New recommendations engine\",
    \"key\": \"engine.enable\",
    \"description\": \"This is the description\",
    ...
}
```
You can change the feature flag's description with the following patch document:

```json
[{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"This is the new description\" }]
```

You can specify multiple modifications to perform in a single request. You can also test that certain preconditions are met before applying the patch:

```json
[
  { \"op\": \"test\", \"path\": \"/version\", \"value\": 10 },
  { \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }
]
```

The above patch request tests whether the feature flag's `version` is `10`, and if so, changes the feature flag's description.

Attributes that are not editable, such as a resource's `_links`, have names that start with an underscore.

### Updates using JSON merge patch

[JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) is another format for specifying the modifications to perform on a resource. JSON merge patch is less expressive than JSON patch. However, in many cases it is simpler to construct a merge patch document. For example, you can change a feature flag's description with the following merge patch document:

```json
{
  \"description\": \"New flag description\"
}
```

### Updates using semantic patch

Some resources support the semantic patch format. A semantic patch is a way to specify the modifications to perform on a resource as a set of executable instructions.

Semantic patch allows you to be explicit about intent using precise, custom instructions. In many cases, you can define semantic patch instructions independently of the current state of the resource. This can be useful when defining a change that may be applied at a future date.

To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header.

Here's how:

```
Content-Type: application/json; domain-model=launchdarkly.semanticpatch
```

If you call a semantic patch resource without this header, you will receive a `400` response because your semantic patch will be interpreted as a JSON patch.

The body of a semantic patch request takes the following properties:

* `comment` (string): (Optional) A description of the update.
* `environmentKey` (string): (Required for some resources only) The environment key.
* `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the instruction requires parameters, you must include those parameters as additional fields in the object. The documentation for each resource that supports semantic patch includes the available instructions and any additional parameters.

For example:

```json
{
  \"comment\": \"optional comment\",
  \"instructions\": [ {\"kind\": \"turnFlagOn\"} ]
}
```

Semantic patches are not applied partially; either all of the instructions are applied or none of them are. If **any** instruction is invalid, the endpoint returns an error and will not change the resource. If all instructions are valid, the request succeeds and the resources are updated if necessary, or left unchanged if they are already in the state you request.

### Updates with comments

You can submit optional comments with `PATCH` changes.

To submit a comment along with a JSON patch document, use the following format:

```json
{
  \"comment\": \"This is a comment string\",
  \"patch\": [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }]
}
```

To submit a comment along with a JSON merge patch document, use the following format:

```json
{
  \"comment\": \"This is a comment string\",
  \"merge\": { \"description\": \"New flag description\" }
}
```

To submit a comment along with a semantic patch, use the following format:

```json
{
  \"comment\": \"This is a comment string\",
  \"instructions\": [ {\"kind\": \"turnFlagOn\"} ]
}
```

## Errors

The API always returns errors in a common format. Here's an example:

```json
{
  \"code\": \"invalid_request\",
  \"message\": \"A feature with that key already exists\",
  \"id\": \"30ce6058-87da-11e4-b116-123b93f75cba\"
}
```

The `code` indicates the general class of error. The `message` is a human-readable explanation of what went wrong. The `id` is a unique identifier. Use it when you're working with LaunchDarkly Support to debug a problem with a specific API call.

### HTTP status error response codes

| Code | Definition        | Description                                                                                       | Possible Solution                                                |
| ---- | ----------------- | ------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- |
| 400  | Invalid request       | The request cannot be understood.                                    | Ensure JSON syntax in request body is correct.                   |
| 401  | Invalid access token      | Requestor is unauthorized or does not have permission for this API call.                                                | Ensure your API access token is valid and has the appropriate permissions.                                     |
| 403  | Forbidden         | Requestor does not have access to this resource.                                                | Ensure that the account member or access token has proper permissions set. |
| 404  | Invalid resource identifier | The requested resource is not valid. | Ensure that the resource is correctly identified by ID or key. |
| 405  | Method not allowed | The request method is not allowed on this resource. | Ensure that the HTTP verb is correct. |
| 409  | Conflict          | The API request can not be completed because it conflicts with a concurrent API request. | Retry your request.                                              |
| 422  | Unprocessable entity | The API request can not be completed because the update description can not be understood. | Ensure that the request body is correct for the type of patch you are using, either JSON patch or semantic patch.
| 429  | Too many requests | Read [Rate limiting](/#section/Overview/Rate-limiting).                                               | Wait and try again later.                                        |

## CORS

The LaunchDarkly API supports Cross Origin Resource Sharing (CORS) for AJAX requests from any origin. If an `Origin` header is given in a request, it will be echoed as an explicitly allowed origin. Otherwise the request returns a wildcard, `Access-Control-Allow-Origin: *`. For more information on CORS, read the [CORS W3C Recommendation](http://www.w3.org/TR/cors). Example CORS headers might look like:

```http
Access-Control-Allow-Headers: Accept, Content-Type, Content-Length, Accept-Encoding, Authorization
Access-Control-Allow-Methods: OPTIONS, GET, DELETE, PATCH
Access-Control-Allow-Origin: *
Access-Control-Max-Age: 300
```

You can make authenticated CORS calls just as you would make same-origin calls, using either [token or session-based authentication](/#section/Overview/Authentication). If you are using session authentication, you should set the `withCredentials` property for your `xhr` request to `true`. You should never expose your access tokens to untrusted entities.

## Rate limiting

We use several rate limiting strategies to ensure the availability of our APIs. Rate-limited calls to our APIs return a `429` status code. Calls to our APIs include headers indicating the current rate limit status. The specific headers returned depend on the API route being called. The limits differ based on the route, authentication mechanism, and other factors. Routes that are not rate limited may not contain any of the headers described below.

> ### Rate limiting and SDKs
>
> LaunchDarkly SDKs are never rate limited and do not use the API endpoints defined here. LaunchDarkly uses a different set of approaches, including streaming/server-sent events and a global CDN, to ensure availability to the routes used by LaunchDarkly SDKs.

### Global rate limits

Authenticated requests are subject to a global limit. This is the maximum number of calls that your account can make to the API per ten seconds. All service and personal access tokens on the account share this limit, so exceeding the limit with one access token will impact other tokens. Calls that are subject to global rate limits may return the headers below:

| Header name                    | Description                                                                      |
| ------------------------------ | -------------------------------------------------------------------------------- |
| `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. |
| `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |

We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.

### Route-level rate limits

Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:

| Header name                   | Description                                                                                           |
| ----------------------------- | ----------------------------------------------------------------------------------------------------- |
| `X-Ratelimit-Route-Remaining` | The maximum number of requests to the current route the account is permitted to make per ten seconds. |
| `X-Ratelimit-Reset`           | The time at which the current rate limit window resets in epoch milliseconds.                         |

A _route_ represents a specific URL pattern and verb. For example, the [Delete environment](/tag/Environments#operation/deleteEnvironment) endpoint is considered a single route, and each call to delete an environment counts against your route-level rate limit for that route.

We do not publicly document the specific number of calls that an account can make to each endpoint per ten seconds. These limits may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limits.

### IP-based rate limiting

We also employ IP-based rate limiting on some API routes. If you hit an IP-based rate limit, your API response will include a `Retry-After` header indicating how long to wait before re-trying the call. Clients must wait at least `Retry-After` seconds before making additional calls to our API, and should employ jitter and backoff strategies to avoid triggering rate limits again.

## OpenAPI (Swagger) and client libraries

We have a [complete OpenAPI (Swagger) specification](https://app.launchdarkly.com/api/v2/openapi.json) for our API.

We auto-generate multiple client libraries based on our OpenAPI specification. To learn more, visit the [collection of client libraries on GitHub](https://github.com/search?q=topic%3Alaunchdarkly-api+org%3Alaunchdarkly&type=Repositories). You can also use this specification to generate client libraries to interact with our REST API in your language of choice.

Our OpenAPI specification is supported by several API-based tools such as Postman and Insomnia. In many cases, you can directly import our specification to explore our APIs.

## Method overriding

Some firewalls and HTTP clients restrict the use of verbs other than `GET` and `POST`. In those environments, our API endpoints that use `DELETE`, `PATCH`, and `PUT` verbs are inaccessible.

To avoid this issue, our API supports the `X-HTTP-Method-Override` header, allowing clients to \"tunnel\" `DELETE`, `PATCH`, and `PUT` requests using a `POST` request.

For example, to call a `PATCH` endpoint using a `POST` request, you can include `X-HTTP-Method-Override:PATCH` as a header.

## Beta resources

We sometimes release new API resources in **beta** status before we release them with general availability.

Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.

We try to promote resources into general availability as quickly as possible. This happens after sufficient testing and when we're satisfied that we no longer need to make backwards-incompatible changes.

We mark beta resources with a \"Beta\" callout in our documentation, pictured below:

> ### This feature is in beta
>
> To use this feature, pass in a header including the `LD-API-Version` key with value set to `beta`. Use this header with each call. To learn more, read [Beta resources](/#section/Overview/Beta-resources).
>
> Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.

### Using beta resources

To use a beta resource, you must include a header in the request. If you call a beta resource without this header, you receive a `403` response.

Use this header:

```
LD-API-Version: beta
```

## Federal environments

The version of LaunchDarkly that is available on domains controlled by the United States government is different from the version of LaunchDarkly available to the general public. If you are an employee or contractor for a United States federal agency and use LaunchDarkly in your work, you likely use the federal instance of LaunchDarkly.

If you are working in the federal instance of LaunchDarkly, the base URI for each request is `https://app.launchdarkly.us`. In the \"Try it\" sandbox for each request, click the request path to view the complete resource path for the federal environment.

To learn more, read [LaunchDarkly in federal environments](https://docs.launchdarkly.com/home/infrastructure/federal).

## Versioning

We try hard to keep our REST API backwards compatible, but we occasionally have to make backwards-incompatible changes in the process of shipping new features. These breaking changes can cause unexpected behavior if you don't prepare for them accordingly.

Updates to our REST API include support for the latest features in LaunchDarkly. We also release a new version of our REST API every time we make a breaking change. We provide simultaneous support for multiple API versions so you can migrate from your current API version to a new version at your own pace.

### Setting the API version per request

You can set the API version on a specific request by sending an `LD-API-Version` header, as shown in the example below:

```
LD-API-Version: 20240415
```

The header value is the version number of the API version you would like to request. The number for each version corresponds to the date the version was released in `yyyymmdd` format. In the example above the version `20240415` corresponds to April 15, 2024.

### Setting the API version per access token

When you create an access token, you must specify a specific version of the API to use. This ensures that integrations using this token cannot be broken by version changes.

Tokens created before versioning was released have their version set to `20160426`, which is the version of the API that existed before the current versioning scheme, so that they continue working the same way they did before versioning.

If you would like to upgrade your integration to use a new API version, you can explicitly set the header described above.

> ### Best practice: Set the header for every client or integration
>
> We recommend that you set the API version header explicitly in any client or integration you build.
>
> Only rely on the access token API version during manual testing.

### API version changelog

|<div style=\"width:75px\">Version</div> | Changes | End of life (EOL)
|---|---|---|
| `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current |
| `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 |
| `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 |
| `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 |
| `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |

To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/).


This SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 2.0
- Package version: 1.0.0
- Generator version: 7.11.0
- Build package: org.openapitools.codegen.languages.RubyClientCodegen
For more information, please visit [https://support.launchdarkly.com](https://support.launchdarkly.com)

## Installation

### Build a gem

To build the Ruby code into a gem:

```shell
gem build launchdarkly_client.gemspec
```

Then either install the gem locally:

```shell
gem install ./launchdarkly_client-1.0.0.gem
```

(for development, run `gem install --dev ./launchdarkly_client-1.0.0.gem` to install the development dependencies)

or publish the gem to a gem hosting service, e.g. [RubyGems](https://rubygems.org/).

Finally add this to the Gemfile:

    gem 'launchdarkly_client', '~> 1.0.0'

### Install from Git

If the Ruby gem is hosted at a git repository: https://github.com/GIT_USER_ID/GIT_REPO_ID, then add the following in the Gemfile:

    gem 'launchdarkly_client', :git => 'https://github.com/GIT_USER_ID/GIT_REPO_ID.git'

### Include the Ruby code directly

Include the Ruby code directly using `-I` as follows:

```shell
ruby -Ilib script.rb
```

## Getting Started

Please follow the [installation](#installation) procedure and then run the following code:

```ruby
# Load the gem
require 'launchdarkly_client'

# Setup authorization
LaunchDarklyClient.configure do |config|
  # Configure API key authorization: ApiKey
  config.api_key['Authorization'] = 'YOUR API KEY'
  # Uncomment the following line to set a prefix for the API key, e.g. 'Bearer' (defaults to nil)
  # config.api_key_prefix['Authorization'] = 'Bearer'
end

api_instance = LaunchDarklyClient::AIConfigsBetaApi.new
ld_api_version = 'beta' # String | Version of the endpoint.
project_key = 'default' # String | 
config_key = 'config_key_example' # String | 

begin
  #Delete AI config
  api_instance.delete_ai_config(ld_api_version, project_key, config_key)
rescue LaunchDarklyClient::ApiError => e
  puts "Exception when calling AIConfigsBetaApi->delete_ai_config: #{e}"
end

```

## Documentation for API Endpoints

All URIs are relative to *https://app.launchdarkly.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*LaunchDarklyClient::AIConfigsBetaApi* | [**delete_ai_config**](docs/AIConfigsBetaApi.md#delete_ai_config) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Delete AI config
*LaunchDarklyClient::AIConfigsBetaApi* | [**delete_ai_config_variation**](docs/AIConfigsBetaApi.md#delete_ai_config_variation) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Delete AI config variation
*LaunchDarklyClient::AIConfigsBetaApi* | [**delete_model_config**](docs/AIConfigsBetaApi.md#delete_model_config) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey} | Delete an AI model config
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_ai_config**](docs/AIConfigsBetaApi.md#get_ai_config) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Get AI config
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_ai_config_metrics**](docs/AIConfigsBetaApi.md#get_ai_config_metrics) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics | Get AI config metrics
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_ai_config_metrics_by_variation**](docs/AIConfigsBetaApi.md#get_ai_config_metrics_by_variation) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics-by-variation | Get AI config metrics by variation
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_ai_config_variation**](docs/AIConfigsBetaApi.md#get_ai_config_variation) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Get AI config variation
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_ai_configs**](docs/AIConfigsBetaApi.md#get_ai_configs) | **GET** /api/v2/projects/{projectKey}/ai-configs | List AI configs
*LaunchDarklyClient::AIConfigsBetaApi* | [**get_model_config**](docs/AIConfigsBetaApi.md#get_model_config) | **GET** /api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey} | Get AI model config
*LaunchDarklyClient::AIConfigsBetaApi* | [**list_model_configs**](docs/AIConfigsBetaApi.md#list_model_configs) | **GET** /api/v2/projects/{projectKey}/ai-configs/model-configs | List AI model configs
*LaunchDarklyClient::AIConfigsBetaApi* | [**patch_ai_config**](docs/AIConfigsBetaApi.md#patch_ai_config) | **PATCH** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Update AI config
*LaunchDarklyClient::AIConfigsBetaApi* | [**patch_ai_config_variation**](docs/AIConfigsBetaApi.md#patch_ai_config_variation) | **PATCH** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Update AI config variation
*LaunchDarklyClient::AIConfigsBetaApi* | [**post_ai_config**](docs/AIConfigsBetaApi.md#post_ai_config) | **POST** /api/v2/projects/{projectKey}/ai-configs | Create new AI config
*LaunchDarklyClient::AIConfigsBetaApi* | [**post_ai_config_variation**](docs/AIConfigsBetaApi.md#post_ai_config_variation) | **POST** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations | Create AI config variation
*LaunchDarklyClient::AIConfigsBetaApi* | [**post_model_config**](docs/AIConfigsBetaApi.md#post_model_config) | **POST** /api/v2/projects/{projectKey}/ai-configs/model-configs | Create an AI model config
*LaunchDarklyClient::AccessTokensApi* | [**delete_token**](docs/AccessTokensApi.md#delete_token) | **DELETE** /api/v2/tokens/{id} | Delete access token
*LaunchDarklyClient::AccessTokensApi* | [**get_token**](docs/AccessTokensApi.md#get_token) | **GET** /api/v2/tokens/{id} | Get access token
*LaunchDarklyClient::AccessTokensApi* | [**get_tokens**](docs/AccessTokensApi.md#get_tokens) | **GET** /api/v2/tokens | List access tokens
*LaunchDarklyClient::AccessTokensApi* | [**patch_token**](docs/AccessTokensApi.md#patch_token) | **PATCH** /api/v2/tokens/{id} | Patch access token
*LaunchDarklyClient::AccessTokensApi* | [**post_token**](docs/AccessTokensApi.md#post_token) | **POST** /api/v2/tokens | Create access token
*LaunchDarklyClient::AccessTokensApi* | [**reset_token**](docs/AccessTokensApi.md#reset_token) | **POST** /api/v2/tokens/{id}/reset | Reset access token
*LaunchDarklyClient::AccountMembersApi* | [**delete_member**](docs/AccountMembersApi.md#delete_member) | **DELETE** /api/v2/members/{id} | Delete account member
*LaunchDarklyClient::AccountMembersApi* | [**get_member**](docs/AccountMembersApi.md#get_member) | **GET** /api/v2/members/{id} | Get account member
*LaunchDarklyClient::AccountMembersApi* | [**get_members**](docs/AccountMembersApi.md#get_members) | **GET** /api/v2/members | List account members
*LaunchDarklyClient::AccountMembersApi* | [**patch_member**](docs/AccountMembersApi.md#patch_member) | **PATCH** /api/v2/members/{id} | Modify an account member
*LaunchDarklyClient::AccountMembersApi* | [**post_member_teams**](docs/AccountMembersApi.md#post_member_teams) | **POST** /api/v2/members/{id}/teams | Add a member to teams
*LaunchDarklyClient::AccountMembersApi* | [**post_members**](docs/AccountMembersApi.md#post_members) | **POST** /api/v2/members | Invite new members
*LaunchDarklyClient::AccountMembersBetaApi* | [**patch_members**](docs/AccountMembersBetaApi.md#patch_members) | **PATCH** /api/v2/members | Modify account members
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_data_export_events_usage**](docs/AccountUsageBetaApi.md#get_data_export_events_usage) | **GET** /api/v2/usage/data-export-events | Get data export events usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_evaluations_usage**](docs/AccountUsageBetaApi.md#get_evaluations_usage) | **GET** /api/v2/usage/evaluations/{projectKey}/{environmentKey}/{featureFlagKey} | Get evaluations usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_events_usage**](docs/AccountUsageBetaApi.md#get_events_usage) | **GET** /api/v2/usage/events/{type} | Get events usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_experimentation_keys_usage**](docs/AccountUsageBetaApi.md#get_experimentation_keys_usage) | **GET** /api/v2/usage/experimentation-keys | Get experimentation keys usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_experimentation_units_usage**](docs/AccountUsageBetaApi.md#get_experimentation_units_usage) | **GET** /api/v2/usage/experimentation-units | Get experimentation units usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_mau_sdks_by_type**](docs/AccountUsageBetaApi.md#get_mau_sdks_by_type) | **GET** /api/v2/usage/mau/sdks | Get MAU SDKs by type
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_mau_usage**](docs/AccountUsageBetaApi.md#get_mau_usage) | **GET** /api/v2/usage/mau | Get MAU usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_mau_usage_by_category**](docs/AccountUsageBetaApi.md#get_mau_usage_by_category) | **GET** /api/v2/usage/mau/bycategory | Get MAU usage by category
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_service_connection_usage**](docs/AccountUsageBetaApi.md#get_service_connection_usage) | **GET** /api/v2/usage/service-connections | Get service connection usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_stream_usage**](docs/AccountUsageBetaApi.md#get_stream_usage) | **GET** /api/v2/usage/streams/{source} | Get stream usage
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_stream_usage_by_sdk_version**](docs/AccountUsageBetaApi.md#get_stream_usage_by_sdk_version) | **GET** /api/v2/usage/streams/{source}/bysdkversion | Get stream usage by SDK version
*LaunchDarklyClient::AccountUsageBetaApi* | [**get_stream_usage_sdkversion**](docs/AccountUsageBetaApi.md#get_stream_usage_sdkversion) | **GET** /api/v2/usage/streams/{source}/sdkversions | Get stream usage SDK versions
*LaunchDarklyClient::ApplicationsBetaApi* | [**delete_application**](docs/ApplicationsBetaApi.md#delete_application) | **DELETE** /api/v2/applications/{applicationKey} | Delete application
*LaunchDarklyClient::ApplicationsBetaApi* | [**delete_application_version**](docs/ApplicationsBetaApi.md#delete_application_version) | **DELETE** /api/v2/applications/{applicationKey}/versions/{versionKey} | Delete application version
*LaunchDarklyClient::ApplicationsBetaApi* | [**get_application**](docs/ApplicationsBetaApi.md#get_application) | **GET** /api/v2/applications/{applicationKey} | Get application by key
*LaunchDarklyClient::ApplicationsBetaApi* | [**get_application_versions**](docs/ApplicationsBetaApi.md#get_application_versions) | **GET** /api/v2/applications/{applicationKey}/versions | Get application versions by application key
*LaunchDarklyClient::ApplicationsBetaApi* | [**get_applications**](docs/ApplicationsBetaApi.md#get_applications) | **GET** /api/v2/applications | Get applications
*LaunchDarklyClient::ApplicationsBetaApi* | [**patch_application**](docs/ApplicationsBetaApi.md#patch_application) | **PATCH** /api/v2/applications/{applicationKey} | Update application
*LaunchDarklyClient::ApplicationsBetaApi* | [**patch_application_version**](docs/ApplicationsBetaApi.md#patch_application_version) | **PATCH** /api/v2/applications/{applicationKey}/versions/{versionKey} | Update application version
*LaunchDarklyClient::ApprovalsApi* | [**delete_approval_request**](docs/ApprovalsApi.md#delete_approval_request) | **DELETE** /api/v2/approval-requests/{id} | Delete approval request
*LaunchDarklyClient::ApprovalsApi* | [**delete_approval_request_for_flag**](docs/ApprovalsApi.md#delete_approval_request_for_flag) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Delete approval request for a flag
*LaunchDarklyClient::ApprovalsApi* | [**get_approval_for_flag**](docs/ApprovalsApi.md#get_approval_for_flag) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Get approval request for a flag
*LaunchDarklyClient::ApprovalsApi* | [**get_approval_request**](docs/ApprovalsApi.md#get_approval_request) | **GET** /api/v2/approval-requests/{id} | Get approval request
*LaunchDarklyClient::ApprovalsApi* | [**get_approval_requests**](docs/ApprovalsApi.md#get_approval_requests) | **GET** /api/v2/approval-requests | List approval requests
*LaunchDarklyClient::ApprovalsApi* | [**get_approvals_for_flag**](docs/ApprovalsApi.md#get_approvals_for_flag) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests | List approval requests for a flag
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request**](docs/ApprovalsApi.md#post_approval_request) | **POST** /api/v2/approval-requests | Create approval request
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request_apply**](docs/ApprovalsApi.md#post_approval_request_apply) | **POST** /api/v2/approval-requests/{id}/apply | Apply approval request
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request_apply_for_flag**](docs/ApprovalsApi.md#post_approval_request_apply_for_flag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id}/apply | Apply approval request for a flag
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request_for_flag**](docs/ApprovalsApi.md#post_approval_request_for_flag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests | Create approval request for a flag
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request_review**](docs/ApprovalsApi.md#post_approval_request_review) | **POST** /api/v2/approval-requests/{id}/reviews | Review approval request
*LaunchDarklyClient::ApprovalsApi* | [**post_approval_request_review_for_flag**](docs/ApprovalsApi.md#post_approval_request_review_for_flag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id}/reviews | Review approval request for a flag
*LaunchDarklyClient::ApprovalsApi* | [**post_flag_copy_config_approval_request**](docs/ApprovalsApi.md#post_flag_copy_config_approval_request) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests-flag-copy | Create approval request to copy flag configurations across environments
*LaunchDarklyClient::ApprovalsBetaApi* | [**patch_approval_request**](docs/ApprovalsBetaApi.md#patch_approval_request) | **PATCH** /api/v2/approval-requests/{id} | Update approval request
*LaunchDarklyClient::ApprovalsBetaApi* | [**patch_flag_config_approval_request**](docs/ApprovalsBetaApi.md#patch_flag_config_approval_request) | **PATCH** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Update flag approval request
*LaunchDarklyClient::AuditLogApi* | [**get_audit_log_entries**](docs/AuditLogApi.md#get_audit_log_entries) | **GET** /api/v2/auditlog | List audit log entries
*LaunchDarklyClient::AuditLogApi* | [**get_audit_log_entry**](docs/AuditLogApi.md#get_audit_log_entry) | **GET** /api/v2/auditlog/{id} | Get audit log entry
*LaunchDarklyClient::AuditLogApi* | [**post_audit_log_entries**](docs/AuditLogApi.md#post_audit_log_entries) | **POST** /api/v2/auditlog | Search audit log entries
*LaunchDarklyClient::CodeReferencesApi* | [**delete_branches**](docs/CodeReferencesApi.md#delete_branches) | **POST** /api/v2/code-refs/repositories/{repo}/branch-delete-tasks | Delete branches
*LaunchDarklyClient::CodeReferencesApi* | [**delete_repository**](docs/CodeReferencesApi.md#delete_repository) | **DELETE** /api/v2/code-refs/repositories/{repo} | Delete repository
*LaunchDarklyClient::CodeReferencesApi* | [**get_branch**](docs/CodeReferencesApi.md#get_branch) | **GET** /api/v2/code-refs/repositories/{repo}/branches/{branch} | Get branch
*LaunchDarklyClient::CodeReferencesApi* | [**get_branches**](docs/CodeReferencesApi.md#get_branches) | **GET** /api/v2/code-refs/repositories/{repo}/branches | List branches
*LaunchDarklyClient::CodeReferencesApi* | [**get_extinctions**](docs/CodeReferencesApi.md#get_extinctions) | **GET** /api/v2/code-refs/extinctions | List extinctions
*LaunchDarklyClient::CodeReferencesApi* | [**get_repositories**](docs/CodeReferencesApi.md#get_repositories) | **GET** /api/v2/code-refs/repositories | List repositories
*LaunchDarklyClient::CodeReferencesApi* | [**get_repository**](docs/CodeReferencesApi.md#get_repository) | **GET** /api/v2/code-refs/repositories/{repo} | Get repository
*LaunchDarklyClient::CodeReferencesApi* | [**get_root_statistic**](docs/CodeReferencesApi.md#get_root_statistic) | **GET** /api/v2/code-refs/statistics | Get links to code reference repositories for each project
*LaunchDarklyClient::CodeReferencesApi* | [**get_statistics**](docs/CodeReferencesApi.md#get_statistics) | **GET** /api/v2/code-refs/statistics/{projectKey} | Get code references statistics for flags
*LaunchDarklyClient::CodeReferencesApi* | [**patch_repository**](docs/CodeReferencesApi.md#patch_repository) | **PATCH** /api/v2/code-refs/repositories/{repo} | Update repository
*LaunchDarklyClient::CodeReferencesApi* | [**post_extinction**](docs/CodeReferencesApi.md#post_extinction) | **POST** /api/v2/code-refs/repositories/{repo}/branches/{branch}/extinction-events | Create extinction
*LaunchDarklyClient::CodeReferencesApi* | [**post_repository**](docs/CodeReferencesApi.md#post_repository) | **POST** /api/v2/code-refs/repositories | Create repository
*LaunchDarklyClient::CodeReferencesApi* | [**put_branch**](docs/CodeReferencesApi.md#put_branch) | **PUT** /api/v2/code-refs/repositories/{repo}/branches/{branch} | Upsert branch
*LaunchDarklyClient::ContextSettingsApi* | [**put_context_flag_setting**](docs/ContextSettingsApi.md#put_context_flag_setting) | **PUT** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{contextKind}/{contextKey}/flags/{featureFlagKey} | Update flag settings for context
*LaunchDarklyClient::ContextsApi* | [**delete_context_instances**](docs/ContextsApi.md#delete_context_instances) | **DELETE** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id} | Delete context instances
*LaunchDarklyClient::ContextsApi* | [**evaluate_context_instance**](docs/ContextsApi.md#evaluate_context_instance) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/flags/evaluate | Evaluate flags for context instance
*LaunchDarklyClient::ContextsApi* | [**get_context_attribute_names**](docs/ContextsApi.md#get_context_attribute_names) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes | Get context attribute names
*LaunchDarklyClient::ContextsApi* | [**get_context_attribute_values**](docs/ContextsApi.md#get_context_attribute_values) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes/{attributeName} | Get context attribute values
*LaunchDarklyClient::ContextsApi* | [**get_context_instances**](docs/ContextsApi.md#get_context_instances) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id} | Get context instances
*LaunchDarklyClient::ContextsApi* | [**get_context_kinds_by_project_key**](docs/ContextsApi.md#get_context_kinds_by_project_key) | **GET** /api/v2/projects/{projectKey}/context-kinds | Get context kinds
*LaunchDarklyClient::ContextsApi* | [**get_contexts**](docs/ContextsApi.md#get_contexts) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{kind}/{key} | Get contexts
*LaunchDarklyClient::ContextsApi* | [**put_context_kind**](docs/ContextsApi.md#put_context_kind) | **PUT** /api/v2/projects/{projectKey}/context-kinds/{key} | Create or update context kind
*LaunchDarklyClient::ContextsApi* | [**search_context_instances**](docs/ContextsApi.md#search_context_instances) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/search | Search for context instances
*LaunchDarklyClient::ContextsApi* | [**search_contexts**](docs/ContextsApi.md#search_contexts) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/search | Search for contexts
*LaunchDarklyClient::CustomRolesApi* | [**delete_custom_role**](docs/CustomRolesApi.md#delete_custom_role) | **DELETE** /api/v2/roles/{customRoleKey} | Delete custom role
*LaunchDarklyClient::CustomRolesApi* | [**get_custom_role**](docs/CustomRolesApi.md#get_custom_role) | **GET** /api/v2/roles/{customRoleKey} | Get custom role
*LaunchDarklyClient::CustomRolesApi* | [**get_custom_roles**](docs/CustomRolesApi.md#get_custom_roles) | **GET** /api/v2/roles | List custom roles
*LaunchDarklyClient::CustomRolesApi* | [**patch_custom_role**](docs/CustomRolesApi.md#patch_custom_role) | **PATCH** /api/v2/roles/{customRoleKey} | Update custom role
*LaunchDarklyClient::CustomRolesApi* | [**post_custom_role**](docs/CustomRolesApi.md#post_custom_role) | **POST** /api/v2/roles | Create custom role
*LaunchDarklyClient::DataExportDestinationsApi* | [**delete_destination**](docs/DataExportDestinationsApi.md#delete_destination) | **DELETE** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Delete Data Export destination
*LaunchDarklyClient::DataExportDestinationsApi* | [**get_destination**](docs/DataExportDestinationsApi.md#get_destination) | **GET** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Get destination
*LaunchDarklyClient::DataExportDestinationsApi* | [**get_destinations**](docs/DataExportDestinationsApi.md#get_destinations) | **GET** /api/v2/destinations | List destinations
*LaunchDarklyClient::DataExportDestinationsApi* | [**patch_destination**](docs/DataExportDestinationsApi.md#patch_destination) | **PATCH** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Update Data Export destination
*LaunchDarklyClient::DataExportDestinationsApi* | [**post_destination**](docs/DataExportDestinationsApi.md#post_destination) | **POST** /api/v2/destinations/{projectKey}/{environmentKey} | Create Data Export destination
*LaunchDarklyClient::EnvironmentsApi* | [**delete_environment**](docs/EnvironmentsApi.md#delete_environment) | **DELETE** /api/v2/projects/{projectKey}/environments/{environmentKey} | Delete environment
*LaunchDarklyClient::EnvironmentsApi* | [**get_environment**](docs/EnvironmentsApi.md#get_environment) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey} | Get environment
*LaunchDarklyClient::EnvironmentsApi* | [**get_environments_by_project**](docs/EnvironmentsApi.md#get_environments_by_project) | **GET** /api/v2/projects/{projectKey}/environments | List environments
*LaunchDarklyClient::EnvironmentsApi* | [**patch_environment**](docs/EnvironmentsApi.md#patch_environment) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey} | Update environment
*LaunchDarklyClient::EnvironmentsApi* | [**post_environment**](docs/EnvironmentsApi.md#post_environment) | **POST** /api/v2/projects/{projectKey}/environments | Create environment
*LaunchDarklyClient::EnvironmentsApi* | [**reset_environment_mobile_key**](docs/EnvironmentsApi.md#reset_environment_mobile_key) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/mobileKey | Reset environment mobile SDK key
*LaunchDarklyClient::EnvironmentsApi* | [**reset_environment_sdk_key**](docs/EnvironmentsApi.md#reset_environment_sdk_key) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/apiKey | Reset environment SDK key
*LaunchDarklyClient::ExperimentsApi* | [**create_experiment**](docs/ExperimentsApi.md#create_experiment) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments | Create experiment
*LaunchDarklyClient::ExperimentsApi* | [**create_iteration**](docs/ExperimentsApi.md#create_iteration) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/iterations | Create iteration
*LaunchDarklyClient::ExperimentsApi* | [**get_experiment**](docs/ExperimentsApi.md#get_experiment) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey} | Get experiment
*LaunchDarklyClient::ExperimentsApi* | [**get_experiment_results**](docs/ExperimentsApi.md#get_experiment_results) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metrics/{metricKey}/results | Get experiment results
*LaunchDarklyClient::ExperimentsApi* | [**get_experiment_results_for_metric_group**](docs/ExperimentsApi.md#get_experiment_results_for_metric_group) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metric-groups/{metricGroupKey}/results | Get experiment results for metric group
*LaunchDarklyClient::ExperimentsApi* | [**get_experimentation_settings**](docs/ExperimentsApi.md#get_experimentation_settings) | **GET** /api/v2/projects/{projectKey}/experimentation-settings | Get experimentation settings
*LaunchDarklyClient::ExperimentsApi* | [**get_experiments**](docs/ExperimentsApi.md#get_experiments) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments | Get experiments
*LaunchDarklyClient::ExperimentsApi* | [**patch_experiment**](docs/ExperimentsApi.md#patch_experiment) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey} | Patch experiment
*LaunchDarklyClient::ExperimentsApi* | [**put_experimentation_settings**](docs/ExperimentsApi.md#put_experimentation_settings) | **PUT** /api/v2/projects/{projectKey}/experimentation-settings | Update experimentation settings
*LaunchDarklyClient::FeatureFlagsApi* | [**copy_feature_flag**](docs/FeatureFlagsApi.md#copy_feature_flag) | **POST** /api/v2/flags/{projectKey}/{featureFlagKey}/copy | Copy feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**delete_feature_flag**](docs/FeatureFlagsApi.md#delete_feature_flag) | **DELETE** /api/v2/flags/{projectKey}/{featureFlagKey} | Delete feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**get_expiring_context_targets**](docs/FeatureFlagsApi.md#get_expiring_context_targets) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-targets/{environmentKey} | Get expiring context targets for feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**get_expiring_user_targets**](docs/FeatureFlagsApi.md#get_expiring_user_targets) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-user-targets/{environmentKey} | Get expiring user targets for feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**get_feature_flag**](docs/FeatureFlagsApi.md#get_feature_flag) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey} | Get feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**get_feature_flag_status**](docs/FeatureFlagsApi.md#get_feature_flag_status) | **GET** /api/v2/flag-statuses/{projectKey}/{environmentKey}/{featureFlagKey} | Get feature flag status
*LaunchDarklyClient::FeatureFlagsApi* | [**get_feature_flag_status_across_environments**](docs/FeatureFlagsApi.md#get_feature_flag_status_across_environments) | **GET** /api/v2/flag-status/{projectKey}/{featureFlagKey} | Get flag status across environments
*LaunchDarklyClient::FeatureFlagsApi* | [**get_feature_flag_statuses**](docs/FeatureFlagsApi.md#get_feature_flag_statuses) | **GET** /api/v2/flag-statuses/{projectKey}/{environmentKey} | List feature flag statuses
*LaunchDarklyClient::FeatureFlagsApi* | [**get_feature_flags**](docs/FeatureFlagsApi.md#get_feature_flags) | **GET** /api/v2/flags/{projectKey} | List feature flags
*LaunchDarklyClient::FeatureFlagsApi* | [**patch_expiring_targets**](docs/FeatureFlagsApi.md#patch_expiring_targets) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-targets/{environmentKey} | Update expiring context targets on feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**patch_expiring_user_targets**](docs/FeatureFlagsApi.md#patch_expiring_user_targets) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-user-targets/{environmentKey} | Update expiring user targets on feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**patch_feature_flag**](docs/FeatureFlagsApi.md#patch_feature_flag) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey} | Update feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**post_feature_flag**](docs/FeatureFlagsApi.md#post_feature_flag) | **POST** /api/v2/flags/{projectKey} | Create a feature flag
*LaunchDarklyClient::FeatureFlagsApi* | [**post_migration_safety_issues**](docs/FeatureFlagsApi.md#post_migration_safety_issues) | **POST** /api/v2/projects/{projectKey}/flags/{flagKey}/environments/{environmentKey}/migration-safety-issues | Get migration safety issues
*LaunchDarklyClient::FeatureFlagsBetaApi* | [**get_dependent_flags**](docs/FeatureFlagsBetaApi.md#get_dependent_flags) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/dependent-flags | List dependent feature flags
*LaunchDarklyClient::FeatureFlagsBetaApi* | [**get_dependent_flags_by_env**](docs/FeatureFlagsBetaApi.md#get_dependent_flags_by_env) | **GET** /api/v2/flags/{projectKey}/{environmentKey}/{featureFlagKey}/dependent-flags | List dependent feature flags by environment
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**create_flag_import_configuration**](docs/FlagImportConfigurationsBetaApi.md#create_flag_import_configuration) | **POST** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey} | Create a flag import configuration
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**delete_flag_import_configuration**](docs/FlagImportConfigurationsBetaApi.md#delete_flag_import_configuration) | **DELETE** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Delete a flag import configuration
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**get_flag_import_configuration**](docs/FlagImportConfigurationsBetaApi.md#get_flag_import_configuration) | **GET** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Get a single flag import configuration
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**get_flag_import_configurations**](docs/FlagImportConfigurationsBetaApi.md#get_flag_import_configurations) | **GET** /api/v2/integration-capabilities/flag-import | List all flag import configurations
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**patch_flag_import_configuration**](docs/FlagImportConfigurationsBetaApi.md#patch_flag_import_configuration) | **PATCH** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Update a flag import configuration
*LaunchDarklyClient::FlagImportConfigurationsBetaApi* | [**trigger_flag_import_job**](docs/FlagImportConfigurationsBetaApi.md#trigger_flag_import_job) | **POST** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId}/trigger | Trigger a single flag import run
*LaunchDarklyClient::FlagLinksBetaApi* | [**create_flag_link**](docs/FlagLinksBetaApi.md#create_flag_link) | **POST** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey} | Create flag link
*LaunchDarklyClient::FlagLinksBetaApi* | [**delete_flag_link**](docs/FlagLinksBetaApi.md#delete_flag_link) | **DELETE** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey}/{id} | Delete flag link
*LaunchDarklyClient::FlagLinksBetaApi* | [**get_flag_links**](docs/FlagLinksBetaApi.md#get_flag_links) | **GET** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey} | List flag links
*LaunchDarklyClient::FlagLinksBetaApi* | [**update_flag_link**](docs/FlagLinksBetaApi.md#update_flag_link) | **PATCH** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey}/{id} | Update flag link
*LaunchDarklyClient::FlagTriggersApi* | [**create_trigger_workflow**](docs/FlagTriggersApi.md#create_trigger_workflow) | **POST** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey} | Create flag trigger
*LaunchDarklyClient::FlagTriggersApi* | [**delete_trigger_workflow**](docs/FlagTriggersApi.md#delete_trigger_workflow) | **DELETE** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Delete flag trigger
*LaunchDarklyClient::FlagTriggersApi* | [**get_trigger_workflow_by_id**](docs/FlagTriggersApi.md#get_trigger_workflow_by_id) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Get flag trigger by ID
*LaunchDarklyClient::FlagTriggersApi* | [**get_trigger_workflows**](docs/FlagTriggersApi.md#get_trigger_workflows) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey} | List flag triggers
*LaunchDarklyClient::FlagTriggersApi* | [**patch_trigger_workflow**](docs/FlagTriggersApi.md#patch_trigger_workflow) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Update flag trigger
*LaunchDarklyClient::FollowFlagsApi* | [**delete_flag_follower**](docs/FollowFlagsApi.md#delete_flag_follower) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers/{memberId} | Remove a member as a follower of a flag in a project and environment
*LaunchDarklyClient::FollowFlagsApi* | [**get_flag_followers**](docs/FollowFlagsApi.md#get_flag_followers) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers | Get followers of a flag in a project and environment
*LaunchDarklyClient::FollowFlagsApi* | [**get_followers_by_proj_env**](docs/FollowFlagsApi.md#get_followers_by_proj_env) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/followers | Get followers of all flags in a given project and environment
*LaunchDarklyClient::FollowFlagsApi* | [**put_flag_follower**](docs/FollowFlagsApi.md#put_flag_follower) | **PUT** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers/{memberId} | Add a member as a follower of a flag in a project and environment
*LaunchDarklyClient::HoldoutsBetaApi* | [**get_all_holdouts**](docs/HoldoutsBetaApi.md#get_all_holdouts) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts | Get all holdouts
*LaunchDarklyClient::HoldoutsBetaApi* | [**get_holdout**](docs/HoldoutsBetaApi.md#get_holdout) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/{holdoutKey} | Get holdout
*LaunchDarklyClient::HoldoutsBetaApi* | [**get_holdout_by_id**](docs/HoldoutsBetaApi.md#get_holdout_by_id) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/id/{holdoutId} | Get Holdout by Id
*LaunchDarklyClient::HoldoutsBetaApi* | [**patch_holdout**](docs/HoldoutsBetaApi.md#patch_holdout) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/{holdoutKey} | Patch holdout
*LaunchDarklyClient::HoldoutsBetaApi* | [**post_holdout**](docs/HoldoutsBetaApi.md#post_holdout) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts | Create holdout
*LaunchDarklyClient::InsightsChartsBetaApi* | [**get_deployment_frequency_chart**](docs/InsightsChartsBetaApi.md#get_deployment_frequency_chart) | **GET** /api/v2/engineering-insights/charts/deployments/frequency | Get deployment frequency chart data
*LaunchDarklyClient::InsightsChartsBetaApi* | [**get_flag_status_chart**](docs/InsightsChartsBetaApi.md#get_flag_status_chart) | **GET** /api/v2/engineering-insights/charts/flags/status | Get flag status chart data
*LaunchDarklyClient::InsightsChartsBetaApi* | [**get_lead_time_chart**](docs/InsightsChartsBetaApi.md#get_lead_time_chart) | **GET** /api/v2/engineering-insights/charts/lead-time | Get lead time chart data
*LaunchDarklyClient::InsightsChartsBetaApi* | [**get_release_frequency_chart**](docs/InsightsChartsBetaApi.md#get_release_frequency_chart) | **GET** /api/v2/engineering-insights/charts/releases/frequency | Get release frequency chart data
*LaunchDarklyClient::InsightsChartsBetaApi* | [**get_stale_flags_chart**](docs/InsightsChartsBetaApi.md#get_stale_flags_chart) | **GET** /api/v2/engineering-insights/charts/flags/stale | Get stale flags chart data
*LaunchDarklyClient::InsightsDeploymentsBetaApi* | [**create_deployment_event**](docs/InsightsDeploymentsBetaApi.md#create_deployment_event) | **POST** /api/v2/engineering-insights/deployment-events | Create deployment event
*LaunchDarklyClient::InsightsDeploymentsBetaApi* | [**get_deployment**](docs/InsightsDeploymentsBetaApi.md#get_deployment) | **GET** /api/v2/engineering-insights/deployments/{deploymentID} | Get deployment
*LaunchDarklyClient::InsightsDeploymentsBetaApi* | [**get_deployments**](docs/InsightsDeploymentsBetaApi.md#get_deployments) | **GET** /api/v2/engineering-insights/deployments | List deployments
*LaunchDarklyClient::InsightsDeploymentsBetaApi* | [**update_deployment**](docs/InsightsDeploymentsBetaApi.md#update_deployment) | **PATCH** /api/v2/engineering-insights/deployments/{deploymentID} | Update deployment
*LaunchDarklyClient::InsightsFlagEventsBetaApi* | [**get_flag_events**](docs/InsightsFlagEventsBetaApi.md#get_flag_events) | **GET** /api/v2/engineering-insights/flag-events | List flag events
*LaunchDarklyClient::InsightsPullRequestsBetaApi* | [**get_pull_requests**](docs/InsightsPullRequestsBetaApi.md#get_pull_requests) | **GET** /api/v2/engineering-insights/pull-requests | List pull requests
*LaunchDarklyClient::InsightsRepositoriesBetaApi* | [**associate_repositories_and_projects**](docs/InsightsRepositoriesBetaApi.md#associate_repositories_and_projects) | **PUT** /api/v2/engineering-insights/repositories/projects | Associate repositories with projects
*LaunchDarklyClient::InsightsRepositoriesBetaApi* | [**delete_repository_project**](docs/InsightsRepositoriesBetaApi.md#delete_repository_project) | **DELETE** /api/v2/engineering-insights/repositories/{repositoryKey}/projects/{projectKey} | Remove repository project association
*LaunchDarklyClient::InsightsRepositoriesBetaApi* | [**get_insights_repositories**](docs/InsightsRepositoriesBetaApi.md#get_insights_repositories) | **GET** /api/v2/engineering-insights/repositories | List repositories
*LaunchDarklyClient::InsightsScoresBetaApi* | [**create_insight_group**](docs/InsightsScoresBetaApi.md#create_insight_group) | **POST** /api/v2/engineering-insights/insights/group | Create insight group
*LaunchDarklyClient::InsightsScoresBetaApi* | [**delete_insight_group**](docs/InsightsScoresBetaApi.md#delete_insight_group) | **DELETE** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Delete insight group
*LaunchDarklyClient::InsightsScoresBetaApi* | [**get_insight_group**](docs/InsightsScoresBetaApi.md#get_insight_group) | **GET** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Get insight group
*LaunchDarklyClient::InsightsScoresBetaApi* | [**get_insight_groups**](docs/InsightsScoresBetaApi.md#get_insight_groups) | **GET** /api/v2/engineering-insights/insights/groups | List insight groups
*LaunchDarklyClient::InsightsScoresBetaApi* | [**get_insights_scores**](docs/InsightsScoresBetaApi.md#get_insights_scores) | **GET** /api/v2/engineering-insights/insights/scores | Get insight scores
*LaunchDarklyClient::InsightsScoresBetaApi* | [**patch_insight_group**](docs/InsightsScoresBetaApi.md#patch_insight_group) | **PATCH** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Patch insight group
*LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi* | [**create_subscription**](docs/IntegrationAuditLogSubscriptionsApi.md#create_subscription) | **POST** /api/v2/integrations/{integrationKey} | Create audit log subscription
*LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi* | [**delete_subscription**](docs/IntegrationAuditLogSubscriptionsApi.md#delete_subscription) | **DELETE** /api/v2/integrations/{integrationKey}/{id} | Delete audit log subscription
*LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi* | [**get_subscription_by_id**](docs/IntegrationAuditLogSubscriptionsApi.md#get_subscription_by_id) | **GET** /api/v2/integrations/{integrationKey}/{id} | Get audit log subscription by ID
*LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi* | [**get_subscriptions**](docs/IntegrationAuditLogSubscriptionsApi.md#get_subscriptions) | **GET** /api/v2/integrations/{integrationKey} | Get audit log subscriptions by integration
*LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi* | [**update_subscription**](docs/IntegrationAuditLogSubscriptionsApi.md#update_subscription) | **PATCH** /api/v2/integrations/{integrationKey}/{id} | Update audit log subscription
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**create_integration_delivery_configuration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#create_integration_delivery_configuration) | **POST** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey} | Create delivery configuration
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**delete_integration_delivery_configuration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#delete_integration_delivery_configuration) | **DELETE** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Delete delivery configuration
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**get_integration_delivery_configuration_by_environment**](docs/IntegrationDeliveryConfigurationsBetaApi.md#get_integration_delivery_configuration_by_environment) | **GET** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey} | Get delivery configurations by environment
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**get_integration_delivery_configuration_by_id**](docs/IntegrationDeliveryConfigurationsBetaApi.md#get_integration_delivery_configuration_by_id) | **GET** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Get delivery configuration by ID
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**get_integration_delivery_configurations**](docs/IntegrationDeliveryConfigurationsBetaApi.md#get_integration_delivery_configurations) | **GET** /api/v2/integration-capabilities/featureStore | List all delivery configurations
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**patch_integration_delivery_configuration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#patch_integration_delivery_configuration) | **PATCH** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Update delivery configuration
*LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi* | [**validate_integration_delivery_configuration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#validate_integration_delivery_configuration) | **POST** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id}/validate | Validate delivery configuration
*LaunchDarklyClient::IntegrationsBetaApi* | [**create_integration_configuration**](docs/IntegrationsBetaApi.md#create_integration_configuration) | **POST** /api/v2/integration-configurations/keys/{integrationKey} | Create integration configuration
*LaunchDarklyClient::IntegrationsBetaApi* | [**delete_integration_configuration**](docs/IntegrationsBetaApi.md#delete_integration_configuration) | **DELETE** /api/v2/integration-configurations/{integrationConfigurationId} | Delete integration configuration
*LaunchDarklyClient::IntegrationsBetaApi* | [**get_all_integration_configurations**](docs/IntegrationsBetaApi.md#get_all_integration_configurations) | **GET** /api/v2/integration-configurations/keys/{integrationKey} | Get all configurations for the integration
*LaunchDarklyClient::IntegrationsBetaApi* | [**get_integration_configuration**](docs/IntegrationsBetaApi.md#get_integration_configuration) | **GET** /api/v2/integration-configurations/{integrationConfigurationId} | Get an integration configuration
*LaunchDarklyClient::IntegrationsBetaApi* | [**update_integration_configuration**](docs/IntegrationsBetaApi.md#update_integration_configuration) | **PATCH** /api/v2/integration-configurations/{integrationConfigurationId} | Update integration configuration
*LaunchDarklyClient::LayersApi* | [**create_layer**](docs/LayersApi.md#create_layer) | **POST** /api/v2/projects/{projectKey}/layers | Create layer
*LaunchDarklyClient::LayersApi* | [**get_layers**](docs/LayersApi.md#get_layers) | **GET** /api/v2/projects/{projectKey}/layers | Get layers
*LaunchDarklyClient::LayersApi* | [**update_layer**](docs/LayersApi.md#update_layer) | **PATCH** /api/v2/projects/{projectKey}/layers/{layerKey} | Update layer
*LaunchDarklyClient::MetricsApi* | [**delete_metric**](docs/MetricsApi.md#delete_metric) | **DELETE** /api/v2/metrics/{projectKey}/{metricKey} | Delete metric
*LaunchDarklyClient::MetricsApi* | [**get_metric**](docs/MetricsApi.md#get_metric) | **GET** /api/v2/metrics/{projectKey}/{metricKey} | Get metric
*LaunchDarklyClient::MetricsApi* | [**get_metrics**](docs/MetricsApi.md#get_metrics) | **GET** /api/v2/metrics/{projectKey} | List metrics
*LaunchDarklyClient::MetricsApi* | [**patch_metric**](docs/MetricsApi.md#patch_metric) | **PATCH** /api/v2/metrics/{projectKey}/{metricKey} | Update metric
*LaunchDarklyClient::MetricsApi* | [**post_metric**](docs/MetricsApi.md#post_metric) | **POST** /api/v2/metrics/{projectKey} | Create metric
*LaunchDarklyClient::MetricsBetaApi* | [**create_metric_group**](docs/MetricsBetaApi.md#create_metric_group) | **POST** /api/v2/projects/{projectKey}/metric-groups | Create metric group
*LaunchDarklyClient::MetricsBetaApi* | [**delete_metric_group**](docs/MetricsBetaApi.md#delete_metric_group) | **DELETE** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Delete metric group
*LaunchDarklyClient::MetricsBetaApi* | [**get_metric_group**](docs/MetricsBetaApi.md#get_metric_group) | **GET** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Get metric group
*LaunchDarklyClient::MetricsBetaApi* | [**get_metric_groups**](docs/MetricsBetaApi.md#get_metric_groups) | **GET** /api/v2/projects/{projectKey}/metric-groups | List metric groups
*LaunchDarklyClient::MetricsBetaApi* | [**patch_metric_group**](docs/MetricsBetaApi.md#patch_metric_group) | **PATCH** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Patch metric group
*LaunchDarklyClient::OAuth2ClientsApi* | [**create_o_auth2_client**](docs/OAuth2ClientsApi.md#create_o_auth2_client) | **POST** /api/v2/oauth/clients | Create a LaunchDarkly OAuth 2.0 client
*LaunchDarklyClient::OAuth2ClientsApi* | [**delete_o_auth_client**](docs/OAuth2ClientsApi.md#delete_o_auth_client) | **DELETE** /api/v2/oauth/clients/{clientId} | Delete OAuth 2.0 client
*LaunchDarklyClient::OAuth2ClientsApi* | [**get_o_auth_client_by_id**](docs/OAuth2ClientsApi.md#get_o_auth_client_by_id) | **GET** /api/v2/oauth/clients/{clientId} | Get client by ID
*LaunchDarklyClient::OAuth2ClientsApi* | [**get_o_auth_clients**](docs/OAuth2ClientsApi.md#get_o_auth_clients) | **GET** /api/v2/oauth/clients | Get clients
*LaunchDarklyClient::OAuth2ClientsApi* | [**patch_o_auth_client**](docs/OAuth2ClientsApi.md#patch_o_auth_client) | **PATCH** /api/v2/oauth/clients/{clientId} | Patch client by ID
*LaunchDarklyClient::OtherApi* | [**get_caller_identity**](docs/OtherApi.md#get_caller_identity) | **GET** /api/v2/caller-identity | Identify the caller
*LaunchDarklyClient::OtherApi* | [**get_ips**](docs/OtherApi.md#get_ips) | **GET** /api/v2/public-ip-list | Gets the public IP list
*LaunchDarklyClient::OtherApi* | [**get_openapi_spec**](docs/OtherApi.md#get_openapi_spec) | **GET** /api/v2/openapi.json | Gets the OpenAPI spec in json
*LaunchDarklyClient::OtherApi* | [**get_root**](docs/OtherApi.md#get_root) | **GET** /api/v2 | Root resource
*LaunchDarklyClient::OtherApi* | [**get_versions**](docs/OtherApi.md#get_versions) | **GET** /api/v2/versions | Get version information
*LaunchDarklyClient::PersistentStoreIntegrationsBetaApi* | [**create_big_segment_store_integration**](docs/PersistentStoreIntegrationsBetaApi.md#create_big_segment_store_integration) | **POST** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey} | Create big segment store integration
*LaunchDarklyClient::PersistentStoreIntegrationsBetaApi* | [**delete_big_segment_store_integration**](docs/PersistentStoreIntegrationsBetaApi.md#delete_big_segment_store_integration) | **DELETE** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Delete big segment store integration
*LaunchDarklyClient::PersistentStoreIntegrationsBetaApi* | [**get_big_segment_store_integration**](docs/PersistentStoreIntegrationsBetaApi.md#get_big_segment_store_integration) | **GET** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Get big segment store integration by ID
*LaunchDarklyClient::PersistentStoreIntegrationsBetaApi* | [**get_big_segment_store_integrations**](docs/PersistentStoreIntegrationsBetaApi.md#get_big_segment_store_integrations) | **GET** /api/v2/integration-capabilities/big-segment-store | List all big segment store integrations
*LaunchDarklyClient::PersistentStoreIntegrationsBetaApi* | [**patch_big_segment_store_integration**](docs/PersistentStoreIntegrationsBetaApi.md#patch_big_segment_store_integration) | **PATCH** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Update big segment store integration
*LaunchDarklyClient::ProjectsApi* | [**delete_project**](docs/ProjectsApi.md#delete_project) | **DELETE** /api/v2/projects/{projectKey} | Delete project
*LaunchDarklyClient::ProjectsApi* | [**get_flag_defaults_by_project**](docs/ProjectsApi.md#get_flag_defaults_by_project) | **GET** /api/v2/projects/{projectKey}/flag-defaults | Get flag defaults for project
*LaunchDarklyClient::ProjectsApi* | [**get_project**](docs/ProjectsApi.md#get_project) | **GET** /api/v2/projects/{projectKey} | Get project
*LaunchDarklyClient::ProjectsApi* | [**get_projects**](docs/ProjectsApi.md#get_projects) | **GET** /api/v2/projects | List projects
*LaunchDarklyClient::ProjectsApi* | [**patch_flag_defaults_by_project**](docs/ProjectsApi.md#patch_flag_defaults_by_project) | **PATCH** /api/v2/projects/{projectKey}/flag-defaults | Update flag default for project
*LaunchDarklyClient::ProjectsApi* | [**patch_project**](docs/ProjectsApi.md#patch_project) | **PATCH** /api/v2/projects/{projectKey} | Update project
*LaunchDarklyClient::ProjectsApi* | [**post_project**](docs/ProjectsApi.md#post_project) | **POST** /api/v2/projects | Create project
*LaunchDarklyClient::ProjectsApi* | [**put_flag_defaults_by_project**](docs/ProjectsApi.md#put_flag_defaults_by_project) | **PUT** /api/v2/projects/{projectKey}/flag-defaults | Create or update flag defaults for project
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**delete_relay_auto_config**](docs/RelayProxyConfigurationsApi.md#delete_relay_auto_config) | **DELETE** /api/v2/account/relay-auto-configs/{id} | Delete Relay Proxy config by ID
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**get_relay_proxy_config**](docs/RelayProxyConfigurationsApi.md#get_relay_proxy_config) | **GET** /api/v2/account/relay-auto-configs/{id} | Get Relay Proxy config
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**get_relay_proxy_configs**](docs/RelayProxyConfigurationsApi.md#get_relay_proxy_configs) | **GET** /api/v2/account/relay-auto-configs | List Relay Proxy configs
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**patch_relay_auto_config**](docs/RelayProxyConfigurationsApi.md#patch_relay_auto_config) | **PATCH** /api/v2/account/relay-auto-configs/{id} | Update a Relay Proxy config
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**post_relay_auto_config**](docs/RelayProxyConfigurationsApi.md#post_relay_auto_config) | **POST** /api/v2/account/relay-auto-configs | Create a new Relay Proxy config
*LaunchDarklyClient::RelayProxyConfigurationsApi* | [**reset_relay_auto_config**](docs/RelayProxyConfigurationsApi.md#reset_relay_auto_config) | **POST** /api/v2/account/relay-auto-configs/{id}/reset | Reset Relay Proxy configuration key
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**delete_release_pipeline**](docs/ReleasePipelinesBetaApi.md#delete_release_pipeline) | **DELETE** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Delete release pipeline
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**get_all_release_pipelines**](docs/ReleasePipelinesBetaApi.md#get_all_release_pipelines) | **GET** /api/v2/projects/{projectKey}/release-pipelines | Get all release pipelines
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**get_all_release_progressions_for_release_pipeline**](docs/ReleasePipelinesBetaApi.md#get_all_release_progressions_for_release_pipeline) | **GET** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey}/releases | Get release progressions for release pipeline
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**get_release_pipeline_by_key**](docs/ReleasePipelinesBetaApi.md#get_release_pipeline_by_key) | **GET** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Get release pipeline by key
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**post_release_pipeline**](docs/ReleasePipelinesBetaApi.md#post_release_pipeline) | **POST** /api/v2/projects/{projectKey}/release-pipelines | Create a release pipeline
*LaunchDarklyClient::ReleasePipelinesBetaApi* | [**put_release_pipeline**](docs/ReleasePipelinesBetaApi.md#put_release_pipeline) | **PUT** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Update a release pipeline
*LaunchDarklyClient::ReleasesBetaApi* | [**create_release_for_flag**](docs/ReleasesBetaApi.md#create_release_for_flag) | **PUT** /api/v2/projects/{projectKey}/flags/{flagKey}/release | Create a new release for flag
*LaunchDarklyClient::ReleasesBetaApi* | [**delete_release_by_flag_key**](docs/ReleasesBetaApi.md#delete_release_by_flag_key) | **DELETE** /api/v2/flags/{projectKey}/{flagKey}/release | Delete a release for flag
*LaunchDarklyClient::ReleasesBetaApi* | [**get_release_by_flag_key**](docs/ReleasesBetaApi.md#get_release_by_flag_key) | **GET** /api/v2/flags/{projectKey}/{flagKey}/release | Get release for flag
*LaunchDarklyClient::ReleasesBetaApi* | [**patch_release_by_flag_key**](docs/ReleasesBetaApi.md#patch_release_by_flag_key) | **PATCH** /api/v2/flags/{projectKey}/{flagKey}/release | Patch release for flag
*LaunchDarklyClient::ReleasesBetaApi* | [**update_phase_status**](docs/ReleasesBetaApi.md#update_phase_status) | **PUT** /api/v2/projects/{projectKey}/flags/{flagKey}/release/phases/{phaseId} | Update phase status for release
*LaunchDarklyClient::ScheduledChangesApi* | [**delete_flag_config_scheduled_changes**](docs/ScheduledChangesApi.md#delete_flag_config_scheduled_changes) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Delete scheduled changes workflow
*LaunchDarklyClient::ScheduledChangesApi* | [**get_feature_flag_scheduled_change**](docs/ScheduledChangesApi.md#get_feature_flag_scheduled_change) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Get a scheduled change
*LaunchDarklyClient::ScheduledChangesApi* | [**get_flag_config_scheduled_changes**](docs/ScheduledChangesApi.md#get_flag_config_scheduled_changes) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes | List scheduled changes
*LaunchDarklyClient::ScheduledChangesApi* | [**patch_flag_config_scheduled_change**](docs/ScheduledChangesApi.md#patch_flag_config_scheduled_change) | **PATCH** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Update scheduled changes workflow
*LaunchDarklyClient::ScheduledChangesApi* | [**post_flag_config_scheduled_changes**](docs/ScheduledChangesApi.md#post_flag_config_scheduled_changes) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes | Create scheduled changes workflow
*LaunchDarklyClient::SegmentsApi* | [**create_big_segment_export**](docs/SegmentsApi.md#create_big_segment_export) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports | Create big segment export
*LaunchDarklyClient::SegmentsApi* | [**create_big_segment_import**](docs/SegmentsApi.md#create_big_segment_import) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports | Create big segment import
*LaunchDarklyClient::SegmentsApi* | [**delete_segment**](docs/SegmentsApi.md#delete_segment) | **DELETE** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Delete segment
*LaunchDarklyClient::SegmentsApi* | [**get_big_segment_export**](docs/SegmentsApi.md#get_big_segment_export) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports/{exportID} | Get big segment export
*LaunchDarklyClient::SegmentsApi* | [**get_big_segment_import**](docs/SegmentsApi.md#get_big_segment_import) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports/{importID} | Get big segment import
*LaunchDarklyClient::SegmentsApi* | [**get_context_instance_segments_membership_by_env**](docs/SegmentsApi.md#get_context_instance_segments_membership_by_env) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/segments/evaluate | List segment memberships for context instance
*LaunchDarklyClient::SegmentsApi* | [**get_expiring_targets_for_segment**](docs/SegmentsApi.md#get_expiring_targets_for_segment) | **GET** /api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey} | Get expiring targets for segment
*LaunchDarklyClient::SegmentsApi* | [**get_expiring_user_targets_for_segment**](docs/SegmentsApi.md#get_expiring_user_targets_for_segment) | **GET** /api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey} | Get expiring user targets for segment
*LaunchDarklyClient::SegmentsApi* | [**get_segment**](docs/SegmentsApi.md#get_segment) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Get segment
*LaunchDarklyClient::SegmentsApi* | [**get_segment_membership_for_context**](docs/SegmentsApi.md#get_segment_membership_for_context) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts/{contextKey} | Get big segment membership for context
*LaunchDarklyClient::SegmentsApi* | [**get_segment_membership_for_user**](docs/SegmentsApi.md#get_segment_membership_for_user) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users/{userKey} | Get big segment membership for user
*LaunchDarklyClient::SegmentsApi* | [**get_segments**](docs/SegmentsApi.md#get_segments) | **GET** /api/v2/segments/{projectKey}/{environmentKey} | List segments
*LaunchDarklyClient::SegmentsApi* | [**patch_expiring_targets_for_segment**](docs/SegmentsApi.md#patch_expiring_targets_for_segment) | **PATCH** /api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey} | Update expiring targets for segment
*LaunchDarklyClient::SegmentsApi* | [**patch_expiring_user_targets_for_segment**](docs/SegmentsApi.md#patch_expiring_user_targets_for_segment) | **PATCH** /api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey} | Update expiring user targets for segment
*LaunchDarklyClient::SegmentsApi* | [**patch_segment**](docs/SegmentsApi.md#patch_segment) | **PATCH** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Patch segment
*LaunchDarklyClient::SegmentsApi* | [**post_segment**](docs/SegmentsApi.md#post_segment) | **POST** /api/v2/segments/{projectKey}/{environmentKey} | Create segment
*LaunchDarklyClient::SegmentsApi* | [**update_big_segment_context_targets**](docs/SegmentsApi.md#update_big_segment_context_targets) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts | Update context targets on a big segment
*LaunchDarklyClient::SegmentsApi* | [**update_big_segment_targets**](docs/SegmentsApi.md#update_big_segment_targets) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users | Update user context targets on a big segment
*LaunchDarklyClient::TagsApi* | [**get_tags**](docs/TagsApi.md#get_tags) | **GET** /api/v2/tags | List tags
*LaunchDarklyClient::TeamsApi* | [**delete_team**](docs/TeamsApi.md#delete_team) | **DELETE** /api/v2/teams/{teamKey} | Delete team
*LaunchDarklyClient::TeamsApi* | [**get_team**](docs/TeamsApi.md#get_team) | **GET** /api/v2/teams/{teamKey} | Get team
*LaunchDarklyClient::TeamsApi* | [**get_team_maintainers**](docs/TeamsApi.md#get_team_maintainers) | **GET** /api/v2/teams/{teamKey}/maintainers | Get team maintainers
*LaunchDarklyClient::TeamsApi* | [**get_team_roles**](docs/TeamsApi.md#get_team_roles) | **GET** /api/v2/teams/{teamKey}/roles | Get team custom roles
*LaunchDarklyClient::TeamsApi* | [**get_teams**](docs/TeamsApi.md#get_teams) | **GET** /api/v2/teams | List teams
*LaunchDarklyClient::TeamsApi* | [**patch_team**](docs/TeamsApi.md#patch_team) | **PATCH** /api/v2/teams/{teamKey} | Update team
*LaunchDarklyClient::TeamsApi* | [**post_team**](docs/TeamsApi.md#post_team) | **POST** /api/v2/teams | Create team
*LaunchDarklyClient::TeamsApi* | [**post_team_members**](docs/TeamsApi.md#post_team_members) | **POST** /api/v2/teams/{teamKey}/members | Add multiple members to team
*LaunchDarklyClient::TeamsBetaApi* | [**patch_teams**](docs/TeamsBetaApi.md#patch_teams) | **PATCH** /api/v2/teams | Update teams
*LaunchDarklyClient::UserSettingsApi* | [**get_expiring_flags_for_user**](docs/UserSettingsApi.md#get_expiring_flags_for_user) | **GET** /api/v2/users/{projectKey}/{userKey}/expiring-user-targets/{environmentKey} | Get expiring dates on flags for user
*LaunchDarklyClient::UserSettingsApi* | [**get_user_flag_setting**](docs/UserSettingsApi.md#get_user_flag_setting) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags/{featureFlagKey} | Get flag setting for user
*LaunchDarklyClient::UserSettingsApi* | [**get_user_flag_settings**](docs/UserSettingsApi.md#get_user_flag_settings) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags | List flag settings for user
*LaunchDarklyClient::UserSettingsApi* | [**patch_expiring_flags_for_user**](docs/UserSettingsApi.md#patch_expiring_flags_for_user) | **PATCH** /api/v2/users/{projectKey}/{userKey}/expiring-user-targets/{environmentKey} | Update expiring user target for flags
*LaunchDarklyClient::UserSettingsApi* | [**put_flag_setting**](docs/UserSettingsApi.md#put_flag_setting) | **PUT** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags/{featureFlagKey} | Update flag settings for user
*LaunchDarklyClient::UsersApi* | [**delete_user**](docs/UsersApi.md#delete_user) | **DELETE** /api/v2/users/{projectKey}/{environmentKey}/{userKey} | Delete user
*LaunchDarklyClient::UsersApi* | [**get_search_users**](docs/UsersApi.md#get_search_users) | **GET** /api/v2/user-search/{projectKey}/{environmentKey} | Find users
*LaunchDarklyClient::UsersApi* | [**get_user**](docs/UsersApi.md#get_user) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey} | Get user
*LaunchDarklyClient::UsersApi* | [**get_users**](docs/UsersApi.md#get_users) | **GET** /api/v2/users/{projectKey}/{environmentKey} | List users
*LaunchDarklyClient::UsersBetaApi* | [**get_user_attribute_names**](docs/UsersBetaApi.md#get_user_attribute_names) | **GET** /api/v2/user-attributes/{projectKey}/{environmentKey} | Get user attribute names
*LaunchDarklyClient::WebhooksApi* | [**delete_webhook**](docs/WebhooksApi.md#delete_webhook) | **DELETE** /api/v2/webhooks/{id} | Delete webhook
*LaunchDarklyClient::WebhooksApi* | [**get_all_webhooks**](docs/WebhooksApi.md#get_all_webhooks) | **GET** /api/v2/webhooks | List webhooks
*LaunchDarklyClient::WebhooksApi* | [**get_webhook**](docs/WebhooksApi.md#get_webhook) | **GET** /api/v2/webhooks/{id} | Get webhook
*LaunchDarklyClient::WebhooksApi* | [**patch_webhook**](docs/WebhooksApi.md#patch_webhook) | **PATCH** /api/v2/webhooks/{id} | Update webhook
*LaunchDarklyClient::WebhooksApi* | [**post_webhook**](docs/WebhooksApi.md#post_webhook) | **POST** /api/v2/webhooks | Creates a webhook
*LaunchDarklyClient::WorkflowTemplatesApi* | [**create_workflow_template**](docs/WorkflowTemplatesApi.md#create_workflow_template) | **POST** /api/v2/templates | Create workflow template
*LaunchDarklyClient::WorkflowTemplatesApi* | [**delete_workflow_template**](docs/WorkflowTemplatesApi.md#delete_workflow_template) | **DELETE** /api/v2/templates/{templateKey} | Delete workflow template
*LaunchDarklyClient::WorkflowTemplatesApi* | [**get_workflow_templates**](docs/WorkflowTemplatesApi.md#get_workflow_templates) | **GET** /api/v2/templates | Get workflow templates
*LaunchDarklyClient::WorkflowsApi* | [**delete_workflow**](docs/WorkflowsApi.md#delete_workflow) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows/{workflowId} | Delete workflow
*LaunchDarklyClient::WorkflowsApi* | [**get_custom_workflow**](docs/WorkflowsApi.md#get_custom_workflow) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows/{workflowId} | Get custom workflow
*LaunchDarklyClient::WorkflowsApi* | [**get_workflows**](docs/WorkflowsApi.md#get_workflows) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows | Get workflows
*LaunchDarklyClient::WorkflowsApi* | [**post_workflow**](docs/WorkflowsApi.md#post_workflow) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows | Create workflow


## Documentation for Models

 - [LaunchDarklyClient::AIConfig](docs/AIConfig.md)
 - [LaunchDarklyClient::AIConfigPatch](docs/AIConfigPatch.md)
 - [LaunchDarklyClient::AIConfigPost](docs/AIConfigPost.md)
 - [LaunchDarklyClient::AIConfigVariation](docs/AIConfigVariation.md)
 - [LaunchDarklyClient::AIConfigVariationPatch](docs/AIConfigVariationPatch.md)
 - [LaunchDarklyClient::AIConfigVariationPost](docs/AIConfigVariationPost.md)
 - [LaunchDarklyClient::AIConfigVariationsResponse](docs/AIConfigVariationsResponse.md)
 - [LaunchDarklyClient::AIConfigs](docs/AIConfigs.md)
 - [LaunchDarklyClient::Access](docs/Access.md)
 - [LaunchDarklyClient::AccessAllowedReason](docs/AccessAllowedReason.md)
 - [LaunchDarklyClient::AccessAllowedRep](docs/AccessAllowedRep.md)
 - [LaunchDarklyClient::AccessDenied](docs/AccessDenied.md)
 - [LaunchDarklyClient::AccessDeniedReason](docs/AccessDeniedReason.md)
 - [LaunchDarklyClient::AccessTokenPost](docs/AccessTokenPost.md)
 - [LaunchDarklyClient::ActionInput](docs/ActionInput.md)
 - [LaunchDarklyClient::ActionOutput](docs/ActionOutput.md)
 - [LaunchDarklyClient::AiConfigsAccess](docs/AiConfigsAccess.md)
 - [LaunchDarklyClient::AiConfigsAccessAllowedReason](docs/AiConfigsAccessAllowedReason.md)
 - [LaunchDarklyClient::AiConfigsAccessAllowedRep](docs/AiConfigsAccessAllowedRep.md)
 - [LaunchDarklyClient::AiConfigsAccessDenied](docs/AiConfigsAccessDenied.md)
 - [LaunchDarklyClient::AiConfigsAccessDeniedReason](docs/AiConfigsAccessDeniedReason.md)
 - [LaunchDarklyClient::AiConfigsLink](docs/AiConfigsLink.md)
 - [LaunchDarklyClient::ApplicationCollectionRep](docs/ApplicationCollectionRep.md)
 - [LaunchDarklyClient::ApplicationFlagCollectionRep](docs/ApplicationFlagCollectionRep.md)
 - [LaunchDarklyClient::ApplicationRep](docs/ApplicationRep.md)
 - [LaunchDarklyClient::ApplicationVersionRep](docs/ApplicationVersionRep.md)
 - [LaunchDarklyClient::ApplicationVersionsCollectionRep](docs/ApplicationVersionsCollectionRep.md)
 - [LaunchDarklyClient::ApprovalRequestResponse](docs/ApprovalRequestResponse.md)
 - [LaunchDarklyClient::ApprovalSettings](docs/ApprovalSettings.md)
 - [LaunchDarklyClient::ApprovalsCapabilityConfig](docs/ApprovalsCapabilityConfig.md)
 - [LaunchDarklyClient::AssignedToRep](docs/AssignedToRep.md)
 - [LaunchDarklyClient::Audience](docs/Audience.md)
 - [LaunchDarklyClient::AudienceConfiguration](docs/AudienceConfiguration.md)
 - [LaunchDarklyClient::AudiencePost](docs/AudiencePost.md)
 - [LaunchDarklyClient::AuditLogEntryListingRep](docs/AuditLogEntryListingRep.md)
 - [LaunchDarklyClient::AuditLogEntryListingRepCollection](docs/AuditLogEntryListingRepCollection.md)
 - [LaunchDarklyClient::AuditLogEntryRep](docs/AuditLogEntryRep.md)
 - [LaunchDarklyClient::AuditLogEventsHookCapabilityConfigPost](docs/AuditLogEventsHookCapabilityConfigPost.md)
 - [LaunchDarklyClient::AuditLogEventsHookCapabilityConfigRep](docs/AuditLogEventsHookCapabilityConfigRep.md)
 - [LaunchDarklyClient::AuthorizedAppDataRep](docs/AuthorizedAppDataRep.md)
 - [LaunchDarklyClient::BayesianBetaBinomialStatsRep](docs/BayesianBetaBinomialStatsRep.md)
 - [LaunchDarklyClient::BayesianNormalStatsRep](docs/BayesianNormalStatsRep.md)
 - [LaunchDarklyClient::BigSegmentStoreIntegration](docs/BigSegmentStoreIntegration.md)
 - [LaunchDarklyClient::BigSegmentStoreIntegrationCollection](docs/BigSegmentStoreIntegrationCollection.md)
 - [LaunchDarklyClient::BigSegmentStoreIntegrationCollectionLinks](docs/BigSegmentStoreIntegrationCollectionLinks.md)
 - [LaunchDarklyClient::BigSegmentStoreIntegrationLinks](docs/BigSegmentStoreIntegrationLinks.md)
 - [LaunchDarklyClient::BigSegmentStoreStatus](docs/BigSegmentStoreStatus.md)
 - [LaunchDarklyClient::BigSegmentTarget](docs/BigSegmentTarget.md)
 - [LaunchDarklyClient::BooleanDefaults](docs/BooleanDefaults.md)
 - [LaunchDarklyClient::BooleanFlagDefaults](docs/BooleanFlagDefaults.md)
 - [LaunchDarklyClient::BranchCollectionRep](docs/BranchCollectionRep.md)
 - [LaunchDarklyClient::BranchRep](docs/BranchRep.md)
 - [LaunchDarklyClient::BulkEditMembersRep](docs/BulkEditMembersRep.md)
 - [LaunchDarklyClient::BulkEditTeamsRep](docs/BulkEditTeamsRep.md)
 - [LaunchDarklyClient::CallerIdentityRep](docs/CallerIdentityRep.md)
 - [LaunchDarklyClient::CapabilityConfigPost](docs/CapabilityConfigPost.md)
 - [LaunchDarklyClient::CapabilityConfigRep](docs/CapabilityConfigRep.md)
 - [LaunchDarklyClient::Clause](docs/Clause.md)
 - [LaunchDarklyClient::Client](docs/Client.md)
 - [LaunchDarklyClient::ClientCollection](docs/ClientCollection.md)
 - [LaunchDarklyClient::ClientSideAvailability](docs/ClientSideAvailability.md)
 - [LaunchDarklyClient::ClientSideAvailabilityPost](docs/ClientSideAvailabilityPost.md)
 - [LaunchDarklyClient::CompletedBy](docs/CompletedBy.md)
 - [LaunchDarklyClient::ConditionInput](docs/ConditionInput.md)
 - [LaunchDarklyClient::ConditionOutput](docs/ConditionOutput.md)
 - [LaunchDarklyClient::Conflict](docs/Conflict.md)
 - [LaunchDarklyClient::ConflictOutput](docs/ConflictOutput.md)
 - [LaunchDarklyClient::ContextAttributeName](docs/ContextAttributeName.md)
 - [LaunchDarklyClient::ContextAttributeNames](docs/ContextAttributeNames.md)
 - [LaunchDarklyClient::ContextAttributeNamesCollection](docs/ContextAttributeNamesCollection.md)
 - [LaunchDarklyClient::ContextAttributeValue](docs/ContextAttributeValue.md)
 - [LaunchDarklyClient::ContextAttributeValues](docs/ContextAttributeValues.md)
 - [LaunchDarklyClient::ContextAttributeValuesCollection](docs/ContextAttributeValuesCollection.md)
 - [LaunchDarklyClient::ContextInstanceEvaluation](docs/ContextInstanceEvaluation.md)
 - [LaunchDarklyClient::ContextInstanceEvaluationReason](docs/ContextInstanceEvaluationReason.md)
 - [LaunchDarklyClient::ContextInstanceEvaluations](docs/ContextInstanceEvaluations.md)
 - [LaunchDarklyClient::ContextInstanceRecord](docs/ContextInstanceRecord.md)
 - [LaunchDarklyClient::ContextInstanceSearch](docs/ContextInstanceSearch.md)
 - [LaunchDarklyClient::ContextInstanceSegmentMembership](docs/ContextInstanceSegmentMembership.md)
 - [LaunchDarklyClient::ContextInstanceSegmentMemberships](docs/ContextInstanceSegmentMemberships.md)
 - [LaunchDarklyClient::ContextInstances](docs/ContextInstances.md)
 - [LaunchDarklyClient::ContextKindRep](docs/ContextKindRep.md)
 - [LaunchDarklyClient::ContextKindsCollectionRep](docs/ContextKindsCollectionRep.md)
 - [LaunchDarklyClient::ContextRecord](docs/ContextRecord.md)
 - [LaunchDarklyClient::ContextSearch](docs/ContextSearch.md)
 - [LaunchDarklyClient::Contexts](docs/Contexts.md)
 - [LaunchDarklyClient::CopiedFromEnv](docs/CopiedFromEnv.md)
 - [LaunchDarklyClient::CoreLink](docs/CoreLink.md)
 - [LaunchDarklyClient::CreateApprovalRequestRequest](docs/CreateApprovalRequestRequest.md)
 - [LaunchDarklyClient::CreateCopyFlagConfigApprovalRequestRequest](docs/CreateCopyFlagConfigApprovalRequestRequest.md)
 - [LaunchDarklyClient::CreateFlagConfigApprovalRequestRequest](docs/CreateFlagConfigApprovalRequestRequest.md)
 - [LaunchDarklyClient::CreatePhaseInput](docs/CreatePhaseInput.md)
 - [LaunchDarklyClient::CreateReleaseInput](docs/CreateReleaseInput.md)
 - [LaunchDarklyClient::CreateReleasePipelineInput](docs/CreateReleasePipelineInput.md)
 - [LaunchDarklyClient::CreateWorkflowTemplateInput](docs/CreateWorkflowTemplateInput.md)
 - [LaunchDarklyClient::CredibleIntervalRep](docs/CredibleIntervalRep.md)
 - [LaunchDarklyClient::CustomProperty](docs/CustomProperty.md)
 - [LaunchDarklyClient::CustomRole](docs/CustomRole.md)
 - [LaunchDarklyClient::CustomRolePost](docs/CustomRolePost.md)
 - [LaunchDarklyClient::CustomRoles](docs/CustomRoles.md)
 - [LaunchDarklyClient::CustomWorkflowInput](docs/CustomWorkflowInput.md)
 - [LaunchDarklyClient::CustomWorkflowMeta](docs/CustomWorkflowMeta.md)
 - [LaunchDarklyClient::CustomWorkflowOutput](docs/CustomWorkflowOutput.md)
 - [LaunchDarklyClient::CustomWorkflowStageMeta](docs/CustomWorkflowStageMeta.md)
 - [LaunchDarklyClient::CustomWorkflowsListingOutput](docs/CustomWorkflowsListingOutput.md)
 - [LaunchDarklyClient::DefaultClientSideAvailability](docs/DefaultClientSideAvailability.md)
 - [LaunchDarklyClient::DefaultClientSideAvailabilityPost](docs/DefaultClientSideAvailabilityPost.md)
 - [LaunchDarklyClient::Defaults](docs/Defaults.md)
 - [LaunchDarklyClient::DependentExperimentRep](docs/DependentExperimentRep.md)
 - [LaunchDarklyClient::DependentFlag](docs/DependentFlag.md)
 - [LaunchDarklyClient::DependentFlagEnvironment](docs/DependentFlagEnvironment.md)
 - [LaunchDarklyClient::DependentFlagsByEnvironment](docs/DependentFlagsByEnvironment.md)
 - [LaunchDarklyClient::DependentMetricGroupRep](docs/DependentMetricGroupRep.md)
 - [LaunchDarklyClient::DependentMetricGroupRepWithMetrics](docs/DependentMetricGroupRepWithMetrics.md)
 - [LaunchDarklyClient::DependentMetricOrMetricGroupRep](docs/DependentMetricOrMetricGroupRep.md)
 - [LaunchDarklyClient::DeploymentCollectionRep](docs/DeploymentCollectionRep.md)
 - [LaunchDarklyClient::DeploymentRep](docs/DeploymentRep.md)
 - [LaunchDarklyClient::Destination](docs/Destination.md)
 - [LaunchDarklyClient::DestinationPost](docs/DestinationPost.md)
 - [LaunchDarklyClient::Destinations](docs/Destinations.md)
 - [LaunchDarklyClient::Distribution](docs/Distribution.md)
 - [LaunchDarklyClient::DynamicOptions](docs/DynamicOptions.md)
 - [LaunchDarklyClient::DynamicOptionsParser](docs/DynamicOptionsParser.md)
 - [LaunchDarklyClient::Endpoint](docs/Endpoint.md)
 - [LaunchDarklyClient::Environment](docs/Environment.md)
 - [LaunchDarklyClient::EnvironmentPost](docs/EnvironmentPost.md)
 - [LaunchDarklyClient::EnvironmentSummary](docs/EnvironmentSummary.md)
 - [LaunchDarklyClient::Environments](docs/Environments.md)
 - [LaunchDarklyClient::Error](docs/Error.md)
 - [LaunchDarklyClient::EvaluationReason](docs/EvaluationReason.md)
 - [LaunchDarklyClient::EvaluationsSummary](docs/EvaluationsSummary.md)
 - [LaunchDarklyClient::ExecutionOutput](docs/ExecutionOutput.md)
 - [LaunchDarklyClient::ExpandableApprovalRequestResponse](docs/ExpandableApprovalRequestResponse.md)
 - [LaunchDarklyClient::ExpandableApprovalRequestsResponse](docs/ExpandableApprovalRequestsResponse.md)
 - [LaunchDarklyClient::ExpandedFlagRep](docs/ExpandedFlagRep.md)
 - [LaunchDarklyClient::ExpandedResourceRep](docs/ExpandedResourceRep.md)
 - [LaunchDarklyClient::Experiment](docs/Experiment.md)
 - [LaunchDarklyClient::ExperimentAllocationRep](docs/ExperimentAllocationRep.md)
 - [LaunchDarklyClient::ExperimentBayesianResultsRep](docs/ExperimentBayesianResultsRep.md)
 - [LaunchDarklyClient::ExperimentCollectionRep](docs/ExperimentCollectionRep.md)
 - [LaunchDarklyClient::ExperimentEnabledPeriodRep](docs/ExperimentEnabledPeriodRep.md)
 - [LaunchDarklyClient::ExperimentEnvironmentSettingRep](docs/ExperimentEnvironmentSettingRep.md)
 - [LaunchDarklyClient::ExperimentInfoRep](docs/ExperimentInfoRep.md)
 - [LaunchDarklyClient::ExperimentPatchInput](docs/ExperimentPatchInput.md)
 - [LaunchDarklyClient::ExperimentPost](docs/ExperimentPost.md)
 - [LaunchDarklyClient::ExpiringTarget](docs/ExpiringTarget.md)
 - [LaunchDarklyClient::ExpiringTargetError](docs/ExpiringTargetError.md)
 - [LaunchDarklyClient::ExpiringTargetGetResponse](docs/ExpiringTargetGetResponse.md)
 - [LaunchDarklyClient::ExpiringTargetPatchResponse](docs/ExpiringTargetPatchResponse.md)
 - [LaunchDarklyClient::ExpiringUserTargetGetResponse](docs/ExpiringUserTargetGetResponse.md)
 - [LaunchDarklyClient::ExpiringUserTargetItem](docs/ExpiringUserTargetItem.md)
 - [LaunchDarklyClient::ExpiringUserTargetPatchResponse](docs/ExpiringUserTargetPatchResponse.md)
 - [LaunchDarklyClient::Export](docs/Export.md)
 - [LaunchDarklyClient::Extinction](docs/Extinction.md)
 - [LaunchDarklyClient::ExtinctionCollectionRep](docs/ExtinctionCollectionRep.md)
 - [LaunchDarklyClient::FailureReasonRep](docs/FailureReasonRep.md)
 - [LaunchDarklyClient::FeatureFlag](docs/FeatureFlag.md)
 - [LaunchDarklyClient::FeatureFlagBody](docs/FeatureFlagBody.md)
 - [LaunchDarklyClient::FeatureFlagConfig](docs/FeatureFlagConfig.md)
 - [LaunchDarklyClient::FeatureFlagScheduledChange](docs/FeatureFlagScheduledChange.md)
 - [LaunchDarklyClient::FeatureFlagScheduledChanges](docs/FeatureFlagScheduledChanges.md)
 - [LaunchDarklyClient::FeatureFlagStatus](docs/FeatureFlagStatus.md)
 - [LaunchDarklyClient::FeatureFlagStatusAcrossEnvironments](docs/FeatureFlagStatusAcrossEnvironments.md)
 - [LaunchDarklyClient::FeatureFlagStatuses](docs/FeatureFlagStatuses.md)
 - [LaunchDarklyClient::FeatureFlags](docs/FeatureFlags.md)
 - [LaunchDarklyClient::FileRep](docs/FileRep.md)
 - [LaunchDarklyClient::FlagConfigApprovalRequestResponse](docs/FlagConfigApprovalRequestResponse.md)
 - [LaunchDarklyClient::FlagConfigApprovalRequestsResponse](docs/FlagConfigApprovalRequestsResponse.md)
 - [LaunchDarklyClient::FlagConfigEvaluation](docs/FlagConfigEvaluation.md)
 - [LaunchDarklyClient::FlagConfigMigrationSettingsRep](docs/FlagConfigMigrationSettingsRep.md)
 - [LaunchDarklyClient::FlagCopyConfigEnvironment](docs/FlagCopyConfigEnvironment.md)
 - [LaunchDarklyClient::FlagCopyConfigPost](docs/FlagCopyConfigPost.md)
 - [LaunchDarklyClient::FlagDefaultsRep](docs/FlagDefaultsRep.md)
 - [LaunchDarklyClient::FlagEventCollectionRep](docs/FlagEventCollectionRep.md)
 - [LaunchDarklyClient::FlagEventExperiment](docs/FlagEventExperiment.md)
 - [LaunchDarklyClient::FlagEventExperimentCollection](docs/FlagEventExperimentCollection.md)
 - [LaunchDarklyClient::FlagEventExperimentIteration](docs/FlagEventExperimentIteration.md)
 - [LaunchDarklyClient::FlagEventImpactRep](docs/FlagEventImpactRep.md)
 - [LaunchDarklyClient::FlagEventMemberRep](docs/FlagEventMemberRep.md)
 - [LaunchDarklyClient::FlagEventRep](docs/FlagEventRep.md)
 - [LaunchDarklyClient::FlagFollowersByProjEnvGetRep](docs/FlagFollowersByProjEnvGetRep.md)
 - [LaunchDarklyClient::FlagFollowersGetRep](docs/FlagFollowersGetRep.md)
 - [LaunchDarklyClient::FlagImportConfigurationPost](docs/FlagImportConfigurationPost.md)
 - [LaunchDarklyClient::FlagImportIntegration](docs/FlagImportIntegration.md)
 - [LaunchDarklyClient::FlagImportIntegrationCollection](docs/FlagImportIntegrationCollection.md)
 - [LaunchDarklyClient::FlagImportIntegrationCollectionLinks](docs/FlagImportIntegrationCollectionLinks.md)
 - [LaunchDarklyClient::FlagImportIntegrationLinks](docs/FlagImportIntegrationLinks.md)
 - [LaunchDarklyClient::FlagImportStatus](docs/FlagImportStatus.md)
 - [LaunchDarklyClient::FlagInput](docs/FlagInput.md)
 - [LaunchDarklyClient::FlagLinkCollectionRep](docs/FlagLinkCollectionRep.md)
 - [LaunchDarklyClient::FlagLinkMember](docs/FlagLinkMember.md)
 - [LaunchDarklyClient::FlagLinkPost](docs/FlagLinkPost.md)
 - [LaunchDarklyClient::FlagLinkRep](docs/FlagLinkRep.md)
 - [LaunchDarklyClient::FlagListingRep](docs/FlagListingRep.md)
 - [LaunchDarklyClient::FlagMigrationSettingsRep](docs/FlagMigrationSettingsRep.md)
 - [LaunchDarklyClient::FlagPrerequisitePost](docs/FlagPrerequisitePost.md)
 - [LaunchDarklyClient::FlagReferenceCollectionRep](docs/FlagReferenceCollectionRep.md)
 - [LaunchDarklyClient::FlagReferenceRep](docs/FlagReferenceRep.md)
 - [LaunchDarklyClient::FlagRep](docs/FlagRep.md)
 - [LaunchDarklyClient::FlagScheduledChangesInput](docs/FlagScheduledChangesInput.md)
 - [LaunchDarklyClient::FlagSempatch](docs/FlagSempatch.md)
 - [LaunchDarklyClient::FlagStatusRep](docs/FlagStatusRep.md)
 - [LaunchDarklyClient::FlagSummary](docs/FlagSummary.md)
 - [LaunchDarklyClient::FlagTriggerInput](docs/FlagTriggerInput.md)
 - [LaunchDarklyClient::FollowFlagMember](docs/FollowFlagMember.md)
 - [LaunchDarklyClient::FollowersPerFlag](docs/FollowersPerFlag.md)
 - [LaunchDarklyClient::ForbiddenErrorRep](docs/ForbiddenErrorRep.md)
 - [LaunchDarklyClient::FormVariable](docs/FormVariable.md)
 - [LaunchDarklyClient::HMACSignature](docs/HMACSignature.md)
 - [LaunchDarklyClient::HeaderItems](docs/HeaderItems.md)
 - [LaunchDarklyClient::HoldoutDetailRep](docs/HoldoutDetailRep.md)
 - [LaunchDarklyClient::HoldoutPatchInput](docs/HoldoutPatchInput.md)
 - [LaunchDarklyClient::HoldoutPostRequest](docs/HoldoutPostRequest.md)
 - [LaunchDarklyClient::HoldoutRep](docs/HoldoutRep.md)
 - [LaunchDarklyClient::HoldoutsCollectionRep](docs/HoldoutsCollectionRep.md)
 - [LaunchDarklyClient::HunkRep](docs/HunkRep.md)
 - [LaunchDarklyClient::Import](docs/Import.md)
 - [LaunchDarklyClient::InitiatorRep](docs/InitiatorRep.md)
 - [LaunchDarklyClient::InsightGroup](docs/InsightGroup.md)
 - [LaunchDarklyClient::InsightGroupCollection](docs/InsightGroupCollection.md)
 - [LaunchDarklyClient::InsightGroupCollectionMetadata](docs/InsightGroupCollectionMetadata.md)
 - [LaunchDarklyClient::InsightGroupCollectionScoreMetadata](docs/InsightGroupCollectionScoreMetadata.md)
 - [LaunchDarklyClient::InsightGroupScores](docs/InsightGroupScores.md)
 - [LaunchDarklyClient::InsightGroupsCountByIndicator](docs/InsightGroupsCountByIndicator.md)
 - [LaunchDarklyClient::InsightPeriod](docs/InsightPeriod.md)
 - [LaunchDarklyClient::InsightScores](docs/InsightScores.md)
 - [LaunchDarklyClient::InsightsChart](docs/InsightsChart.md)
 - [LaunchDarklyClient::InsightsChartBounds](docs/InsightsChartBounds.md)
 - [LaunchDarklyClient::InsightsChartMetadata](docs/InsightsChartMetadata.md)
 - [LaunchDarklyClient::InsightsChartMetric](docs/InsightsChartMetric.md)
 - [LaunchDarklyClient::InsightsChartSeries](docs/InsightsChartSeries.md)
 - [LaunchDarklyClient::InsightsChartSeriesDataPoint](docs/InsightsChartSeriesDataPoint.md)
 - [LaunchDarklyClient::InsightsChartSeriesMetadata](docs/InsightsChartSeriesMetadata.md)
 - [LaunchDarklyClient::InsightsChartSeriesMetadataAxis](docs/InsightsChartSeriesMetadataAxis.md)
 - [LaunchDarklyClient::InsightsMetricIndicatorRange](docs/InsightsMetricIndicatorRange.md)
 - [LaunchDarklyClient::InsightsMetricScore](docs/InsightsMetricScore.md)
 - [LaunchDarklyClient::InsightsMetricTierDefinition](docs/InsightsMetricTierDefinition.md)
 - [LaunchDarklyClient::InsightsRepository](docs/InsightsRepository.md)
 - [LaunchDarklyClient::InsightsRepositoryCollection](docs/InsightsRepositoryCollection.md)
 - [LaunchDarklyClient::InsightsRepositoryProject](docs/InsightsRepositoryProject.md)
 - [LaunchDarklyClient::InsightsRepositoryProjectCollection](docs/InsightsRepositoryProjectCollection.md)
 - [LaunchDarklyClient::InsightsRepositoryProjectMappings](docs/InsightsRepositoryProjectMappings.md)
 - [LaunchDarklyClient::InstructionUserRequest](docs/InstructionUserRequest.md)
 - [LaunchDarklyClient::Integration](docs/Integration.md)
 - [LaunchDarklyClient::IntegrationConfigurationCollectionRep](docs/IntegrationConfigurationCollectionRep.md)
 - [LaunchDarklyClient::IntegrationConfigurationPost](docs/IntegrationConfigurationPost.md)
 - [LaunchDarklyClient::IntegrationConfigurationsRep](docs/IntegrationConfigurationsRep.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfiguration](docs/IntegrationDeliveryConfiguration.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfigurationCollection](docs/IntegrationDeliveryConfigurationCollection.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfigurationCollectionLinks](docs/IntegrationDeliveryConfigurationCollectionLinks.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfigurationLinks](docs/IntegrationDeliveryConfigurationLinks.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfigurationPost](docs/IntegrationDeliveryConfigurationPost.md)
 - [LaunchDarklyClient::IntegrationDeliveryConfigurationResponse](docs/IntegrationDeliveryConfigurationResponse.md)
 - [LaunchDarklyClient::IntegrationMetadata](docs/IntegrationMetadata.md)
 - [LaunchDarklyClient::IntegrationStatus](docs/IntegrationStatus.md)
 - [LaunchDarklyClient::IntegrationStatusRep](docs/IntegrationStatusRep.md)
 - [LaunchDarklyClient::IntegrationSubscriptionStatusRep](docs/IntegrationSubscriptionStatusRep.md)
 - [LaunchDarklyClient::Integrations](docs/Integrations.md)
 - [LaunchDarklyClient::InvalidRequestErrorRep](docs/InvalidRequestErrorRep.md)
 - [LaunchDarklyClient::IpList](docs/IpList.md)
 - [LaunchDarklyClient::IterationInput](docs/IterationInput.md)
 - [LaunchDarklyClient::IterationRep](docs/IterationRep.md)
 - [LaunchDarklyClient::LastSeenMetadata](docs/LastSeenMetadata.md)
 - [LaunchDarklyClient::LayerCollectionRep](docs/LayerCollectionRep.md)
 - [LaunchDarklyClient::LayerConfigurationRep](docs/LayerConfigurationRep.md)
 - [LaunchDarklyClient::LayerPatchInput](docs/LayerPatchInput.md)
 - [LaunchDarklyClient::LayerPost](docs/LayerPost.md)
 - [LaunchDarklyClient::LayerRep](docs/LayerRep.md)
 - [LaunchDarklyClient::LayerReservationRep](docs/LayerReservationRep.md)
 - [LaunchDarklyClient::LayerSnapshotRep](docs/LayerSnapshotRep.md)
 - [LaunchDarklyClient::LeadTimeStagesRep](docs/LeadTimeStagesRep.md)
 - [LaunchDarklyClient::LegacyExperimentRep](docs/LegacyExperimentRep.md)
 - [LaunchDarklyClient::Link](docs/Link.md)
 - [LaunchDarklyClient::MaintainerRep](docs/MaintainerRep.md)
 - [LaunchDarklyClient::MaintainerTeam](docs/MaintainerTeam.md)
 - [LaunchDarklyClient::Member](docs/Member.md)
 - [LaunchDarklyClient::MemberDataRep](docs/MemberDataRep.md)
 - [LaunchDarklyClient::MemberImportItem](docs/MemberImportItem.md)
 - [LaunchDarklyClient::MemberPermissionGrantSummaryRep](docs/MemberPermissionGrantSummaryRep.md)
 - [LaunchDarklyClient::MemberSummary](docs/MemberSummary.md)
 - [LaunchDarklyClient::MemberTeamSummaryRep](docs/MemberTeamSummaryRep.md)
 - [LaunchDarklyClient::MemberTeamsPostInput](docs/MemberTeamsPostInput.md)
 - [LaunchDarklyClient::Members](docs/Members.md)
 - [LaunchDarklyClient::MembersPatchInput](docs/MembersPatchInput.md)
 - [LaunchDarklyClient::Message](docs/Message.md)
 - [LaunchDarklyClient::MethodNotAllowedErrorRep](docs/MethodNotAllowedErrorRep.md)
 - [LaunchDarklyClient::MetricByVariation](docs/MetricByVariation.md)
 - [LaunchDarklyClient::MetricCollectionRep](docs/MetricCollectionRep.md)
 - [LaunchDarklyClient::MetricEventDefaultRep](docs/MetricEventDefaultRep.md)
 - [LaunchDarklyClient::MetricGroupCollectionRep](docs/MetricGroupCollectionRep.md)
 - [LaunchDarklyClient::MetricGroupPost](docs/MetricGroupPost.md)
 - [LaunchDarklyClient::MetricGroupRep](docs/MetricGroupRep.md)
 - [LaunchDarklyClient::MetricGroupResultsRep](docs/MetricGroupResultsRep.md)
 - [LaunchDarklyClient::MetricInGroupRep](docs/MetricInGroupRep.md)
 - [LaunchDarklyClient::MetricInGroupResultsRep](docs/MetricInGroupResultsRep.md)
 - [LaunchDarklyClient::MetricInMetricGroupInput](docs/MetricInMetricGroupInput.md)
 - [LaunchDarklyClient::MetricInput](docs/MetricInput.md)
 - [LaunchDarklyClient::MetricListingRep](docs/MetricListingRep.md)
 - [LaunchDarklyClient::MetricPost](docs/MetricPost.md)
 - [LaunchDarklyClient::MetricRep](docs/MetricRep.md)
 - [LaunchDarklyClient::MetricSeen](docs/MetricSeen.md)
 - [LaunchDarklyClient::MetricV2Rep](docs/MetricV2Rep.md)
 - [LaunchDarklyClient::Metrics](docs/Metrics.md)
 - [LaunchDarklyClient::MigrationSafetyIssueRep](docs/MigrationSafetyIssueRep.md)
 - [LaunchDarklyClient::MigrationSettingsPost](docs/MigrationSettingsPost.md)
 - [LaunchDarklyClient::ModelConfig](docs/ModelConfig.md)
 - [LaunchDarklyClient::ModelConfigPost](docs/ModelConfigPost.md)
 - [LaunchDarklyClient::Modification](docs/Modification.md)
 - [LaunchDarklyClient::MultiEnvironmentDependentFlag](docs/MultiEnvironmentDependentFlag.md)
 - [LaunchDarklyClient::MultiEnvironmentDependentFlags](docs/MultiEnvironmentDependentFlags.md)
 - [LaunchDarklyClient::NamingConvention](docs/NamingConvention.md)
 - [LaunchDarklyClient::NewMemberForm](docs/NewMemberForm.md)
 - [LaunchDarklyClient::NotFoundErrorRep](docs/NotFoundErrorRep.md)
 - [LaunchDarklyClient::OauthClientPost](docs/OauthClientPost.md)
 - [LaunchDarklyClient::OptionsArray](docs/OptionsArray.md)
 - [LaunchDarklyClient::PaginatedLinks](docs/PaginatedLinks.md)
 - [LaunchDarklyClient::ParameterDefault](docs/ParameterDefault.md)
 - [LaunchDarklyClient::ParameterRep](docs/ParameterRep.md)
 - [LaunchDarklyClient::ParentAndSelfLinks](docs/ParentAndSelfLinks.md)
 - [LaunchDarklyClient::ParentLink](docs/ParentLink.md)
 - [LaunchDarklyClient::ParentResourceRep](docs/ParentResourceRep.md)
 - [LaunchDarklyClient::PatchFailedErrorRep](docs/PatchFailedErrorRep.md)
 - [LaunchDarklyClient::PatchFlagsRequest](docs/PatchFlagsRequest.md)
 - [LaunchDarklyClient::PatchOperation](docs/PatchOperation.md)
 - [LaunchDarklyClient::PatchSegmentExpiringTargetInputRep](docs/PatchSegmentExpiringTargetInputRep.md)
 - [LaunchDarklyClient::PatchSegmentExpiringTargetInstruction](docs/PatchSegmentExpiringTargetInstruction.md)
 - [LaunchDarklyClient::PatchSegmentInstruction](docs/PatchSegmentInstruction.md)
 - [LaunchDarklyClient::PatchSegmentRequest](docs/PatchSegmentRequest.md)
 - [LaunchDarklyClient::PatchUsersRequest](docs/PatchUsersRequest.md)
 - [LaunchDarklyClient::PatchWithComment](docs/PatchWithComment.md)
 - [LaunchDarklyClient::PermissionGrantInput](docs/PermissionGrantInput.md)
 - [LaunchDarklyClient::Phase](docs/Phase.md)
 - [LaunchDarklyClient::PhaseInfo](docs/PhaseInfo.md)
 - [LaunchDarklyClient::PostApprovalRequestApplyRequest](docs/PostApprovalRequestApplyRequest.md)
 - [LaunchDarklyClient::PostApprovalRequestReviewRequest](docs/PostApprovalRequestReviewRequest.md)
 - [LaunchDarklyClient::PostDeploymentEventInput](docs/PostDeploymentEventInput.md)
 - [LaunchDarklyClient::PostFlagScheduledChangesInput](docs/PostFlagScheduledChangesInput.md)
 - [LaunchDarklyClient::PostInsightGroupParams](docs/PostInsightGroupParams.md)
 - [LaunchDarklyClient::Prerequisite](docs/Prerequisite.md)
 - [LaunchDarklyClient::Project](docs/Project.md)
 - [LaunchDarklyClient::ProjectPost](docs/ProjectPost.md)
 - [LaunchDarklyClient::ProjectRep](docs/ProjectRep.md)
 - [LaunchDarklyClient::ProjectSummary](docs/ProjectSummary.md)
 - [LaunchDarklyClient::ProjectSummaryCollection](docs/ProjectSummaryCollection.md)
 - [LaunchDarklyClient::Projects](docs/Projects.md)
 - [LaunchDarklyClient::PullRequestCollectionRep](docs/PullRequestCollectionRep.md)
 - [LaunchDarklyClient::PullRequestLeadTimeRep](docs/PullRequestLeadTimeRep.md)
 - [LaunchDarklyClient::PullRequestRep](docs/PullRequestRep.md)
 - [LaunchDarklyClient::PutBranch](docs/PutBranch.md)
 - [LaunchDarklyClient::RandomizationSettingsPut](docs/RandomizationSettingsPut.md)
 - [LaunchDarklyClient::RandomizationSettingsRep](docs/RandomizationSettingsRep.md)
 - [LaunchDarklyClient::RandomizationUnitInput](docs/RandomizationUnitInput.md)
 - [LaunchDarklyClient::RandomizationUnitRep](docs/RandomizationUnitRep.md)
 - [LaunchDarklyClient::RateLimitedErrorRep](docs/RateLimitedErrorRep.md)
 - [LaunchDarklyClient::RecentTriggerBody](docs/RecentTriggerBody.md)
 - [LaunchDarklyClient::ReferenceRep](docs/ReferenceRep.md)
 - [LaunchDarklyClient::RelatedExperimentRep](docs/RelatedExperimentRep.md)
 - [LaunchDarklyClient::RelativeDifferenceRep](docs/RelativeDifferenceRep.md)
 - [LaunchDarklyClient::RelayAutoConfigCollectionRep](docs/RelayAutoConfigCollectionRep.md)
 - [LaunchDarklyClient::RelayAutoConfigPost](docs/RelayAutoConfigPost.md)
 - [LaunchDarklyClient::RelayAutoConfigRep](docs/RelayAutoConfigRep.md)
 - [LaunchDarklyClient::Release](docs/Release.md)
 - [LaunchDarklyClient::ReleaseAudience](docs/ReleaseAudience.md)
 - [LaunchDarklyClient::ReleaseGuardianConfiguration](docs/ReleaseGuardianConfiguration.md)
 - [LaunchDarklyClient::ReleaseGuardianConfigurationInput](docs/ReleaseGuardianConfigurationInput.md)
 - [LaunchDarklyClient::ReleasePhase](docs/ReleasePhase.md)
 - [LaunchDarklyClient::ReleasePipeline](docs/ReleasePipeline.md)
 - [LaunchDarklyClient::ReleasePipelineCollection](docs/ReleasePipelineCollection.md)
 - [LaunchDarklyClient::ReleaseProgression](docs/ReleaseProgression.md)
 - [LaunchDarklyClient::ReleaseProgressionCollection](docs/ReleaseProgressionCollection.md)
 - [LaunchDarklyClient::ReleaserAudienceConfigInput](docs/ReleaserAudienceConfigInput.md)
 - [LaunchDarklyClient::RepositoryCollectionRep](docs/RepositoryCollectionRep.md)
 - [LaunchDarklyClient::RepositoryPost](docs/RepositoryPost.md)
 - [LaunchDarklyClient::RepositoryRep](docs/RepositoryRep.md)
 - [LaunchDarklyClient::ResourceAccess](docs/ResourceAccess.md)
 - [LaunchDarklyClient::ResourceIDResponse](docs/ResourceIDResponse.md)
 - [LaunchDarklyClient::ResourceId](docs/ResourceId.md)
 - [LaunchDarklyClient::ReviewOutput](docs/ReviewOutput.md)
 - [LaunchDarklyClient::ReviewResponse](docs/ReviewResponse.md)
 - [LaunchDarklyClient::Rollout](docs/Rollout.md)
 - [LaunchDarklyClient::RootResponse](docs/RootResponse.md)
 - [LaunchDarklyClient::Rule](docs/Rule.md)
 - [LaunchDarklyClient::RuleClause](docs/RuleClause.md)
 - [LaunchDarklyClient::SdkListRep](docs/SdkListRep.md)
 - [LaunchDarklyClient::SdkVersionListRep](docs/SdkVersionListRep.md)
 - [LaunchDarklyClient::SdkVersionRep](docs/SdkVersionRep.md)
 - [LaunchDarklyClient::SegmentBody](docs/SegmentBody.md)
 - [LaunchDarklyClient::SegmentMetadata](docs/SegmentMetadata.md)
 - [LaunchDarklyClient::SegmentTarget](docs/SegmentTarget.md)
 - [LaunchDarklyClient::SegmentUserList](docs/SegmentUserList.md)
 - [LaunchDarklyClient::SegmentUserState](docs/SegmentUserState.md)
 - [LaunchDarklyClient::Series](docs/Series.md)
 - [LaunchDarklyClient::SeriesIntervalsRep](docs/SeriesIntervalsRep.md)
 - [LaunchDarklyClient::SeriesListRep](docs/SeriesListRep.md)
 - [LaunchDarklyClient::SimpleHoldoutRep](docs/SimpleHoldoutRep.md)
 - [LaunchDarklyClient::SlicedResultsRep](docs/SlicedResultsRep.md)
 - [LaunchDarklyClient::SourceEnv](docs/SourceEnv.md)
 - [LaunchDarklyClient::SourceFlag](docs/SourceFlag.md)
 - [LaunchDarklyClient::StageInput](docs/StageInput.md)
 - [LaunchDarklyClient::StageOutput](docs/StageOutput.md)
 - [LaunchDarklyClient::Statement](docs/Statement.md)
 - [LaunchDarklyClient::StatementPost](docs/StatementPost.md)
 - [LaunchDarklyClient::StatisticCollectionRep](docs/StatisticCollectionRep.md)
 - [LaunchDarklyClient::StatisticRep](docs/StatisticRep.md)
 - [LaunchDarklyClient::StatisticsRoot](docs/StatisticsRoot.md)
 - [LaunchDarklyClient::StatusConflictErrorRep](docs/StatusConflictErrorRep.md)
 - [LaunchDarklyClient::StatusResponse](docs/StatusResponse.md)
 - [LaunchDarklyClient::StatusServiceUnavailable](docs/StatusServiceUnavailable.md)
 - [LaunchDarklyClient::StoreIntegrationError](docs/StoreIntegrationError.md)
 - [LaunchDarklyClient::SubjectDataRep](docs/SubjectDataRep.md)
 - [LaunchDarklyClient::SubscriptionPost](docs/SubscriptionPost.md)
 - [LaunchDarklyClient::TagsCollection](docs/TagsCollection.md)
 - [LaunchDarklyClient::TagsLink](docs/TagsLink.md)
 - [LaunchDarklyClient::Target](docs/Target.md)
 - [LaunchDarklyClient::TargetResourceRep](docs/TargetResourceRep.md)
 - [LaunchDarklyClient::Team](docs/Team.md)
 - [LaunchDarklyClient::TeamCustomRole](docs/TeamCustomRole.md)
 - [LaunchDarklyClient::TeamCustomRoles](docs/TeamCustomRoles.md)
 - [LaunchDarklyClient::TeamImportsRep](docs/TeamImportsRep.md)
 - [LaunchDarklyClient::TeamMaintainers](docs/TeamMaintainers.md)
 - [LaunchDarklyClient::TeamMembers](docs/TeamMembers.md)
 - [LaunchDarklyClient::TeamPatchInput](docs/TeamPatchInput.md)
 - [LaunchDarklyClient::TeamPostInput](docs/TeamPostInput.md)
 - [LaunchDarklyClient::TeamProjects](docs/TeamProjects.md)
 - [LaunchDarklyClient::Teams](docs/Teams.md)
 - [LaunchDarklyClient::TeamsPatchInput](docs/TeamsPatchInput.md)
 - [LaunchDarklyClient::TimestampRep](docs/TimestampRep.md)
 - [LaunchDarklyClient::Token](docs/Token.md)
 - [LaunchDarklyClient::TokenSummary](docs/TokenSummary.md)
 - [LaunchDarklyClient::Tokens](docs/Tokens.md)
 - [LaunchDarklyClient::TreatmentInput](docs/TreatmentInput.md)
 - [LaunchDarklyClient::TreatmentParameterInput](docs/TreatmentParameterInput.md)
 - [LaunchDarklyClient::TreatmentRep](docs/TreatmentRep.md)
 - [LaunchDarklyClient::TreatmentResultRep](docs/TreatmentResultRep.md)
 - [LaunchDarklyClient::TriggerPost](docs/TriggerPost.md)
 - [LaunchDarklyClient::TriggerWorkflowCollectionRep](docs/TriggerWorkflowCollectionRep.md)
 - [LaunchDarklyClient::TriggerWorkflowRep](docs/TriggerWorkflowRep.md)
 - [LaunchDarklyClient::UnauthorizedErrorRep](docs/UnauthorizedErrorRep.md)
 - [LaunchDarklyClient::UpdatePhaseStatusInput](docs/UpdatePhaseStatusInput.md)
 - [LaunchDarklyClient::UpdateReleasePipelineInput](docs/UpdateReleasePipelineInput.md)
 - [LaunchDarklyClient::UpsertContextKindPayload](docs/UpsertContextKindPayload.md)
 - [LaunchDarklyClient::UpsertFlagDefaultsPayload](docs/UpsertFlagDefaultsPayload.md)
 - [LaunchDarklyClient::UpsertPayloadRep](docs/UpsertPayloadRep.md)
 - [LaunchDarklyClient::UpsertResponseRep](docs/UpsertResponseRep.md)
 - [LaunchDarklyClient::UrlPost](docs/UrlPost.md)
 - [LaunchDarklyClient::User](docs/User.md)
 - [LaunchDarklyClient::UserAttributeNamesRep](docs/UserAttributeNamesRep.md)
 - [LaunchDarklyClient::UserFlagSetting](docs/UserFlagSetting.md)
 - [LaunchDarklyClient::UserFlagSettings](docs/UserFlagSettings.md)
 - [LaunchDarklyClient::UserRecord](docs/UserRecord.md)
 - [LaunchDarklyClient::UserSegment](docs/UserSegment.md)
 - [LaunchDarklyClient::UserSegmentRule](docs/UserSegmentRule.md)
 - [LaunchDarklyClient::UserSegments](docs/UserSegments.md)
 - [LaunchDarklyClient::Users](docs/Users.md)
 - [LaunchDarklyClient::UsersRep](docs/UsersRep.md)
 - [LaunchDarklyClient::ValidationFailedErrorRep](docs/ValidationFailedErrorRep.md)
 - [LaunchDarklyClient::ValuePut](docs/ValuePut.md)
 - [LaunchDarklyClient::Variation](docs/Variation.md)
 - [LaunchDarklyClient::VariationEvalSummary](docs/VariationEvalSummary.md)
 - [LaunchDarklyClient::VariationOrRolloutRep](docs/VariationOrRolloutRep.md)
 - [LaunchDarklyClient::VariationSummary](docs/VariationSummary.md)
 - [LaunchDarklyClient::VersionsRep](docs/VersionsRep.md)
 - [LaunchDarklyClient::Webhook](docs/Webhook.md)
 - [LaunchDarklyClient::WebhookPost](docs/WebhookPost.md)
 - [LaunchDarklyClient::Webhooks](docs/Webhooks.md)
 - [LaunchDarklyClient::WeightedVariation](docs/WeightedVariation.md)
 - [LaunchDarklyClient::WorkflowTemplateMetadata](docs/WorkflowTemplateMetadata.md)
 - [LaunchDarklyClient::WorkflowTemplateOutput](docs/WorkflowTemplateOutput.md)
 - [LaunchDarklyClient::WorkflowTemplateParameter](docs/WorkflowTemplateParameter.md)
 - [LaunchDarklyClient::WorkflowTemplatesListingOutputRep](docs/WorkflowTemplatesListingOutputRep.md)


## Documentation for Authorization


Authentication schemes defined for the API:
### ApiKey


- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

