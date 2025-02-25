# Org.LaunchDarklyTools - the C# library for the LaunchDarkly REST API

# Overview

## Authentication

LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.

All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.

LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.

| Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          |
| - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
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
| - -- - | - -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
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
| - -- -- -- -- -- -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- - |
| `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. |
| `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |

We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.

### Route-level rate limits

Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:

| Header name                   | Description                                                                                           |
| - -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- |
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
|- --|- --|- --|
| `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current |
| `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 |
| `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 |
| `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 |
| `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |

To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/).


This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 2.0
- SDK version: 1.0.0
- Generator version: 7.11.0
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://support.launchdarkly.com](https://support.launchdarkly.com)

<a id="frameworks-supported"></a>
## Frameworks supported

<a id="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 112.0.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a id="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;
```
<a id="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out Org.LaunchDarklyTools.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a id="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a id="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://app.launchdarkly.com";
            // Configure API key authorization: ApiKey
            config.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AIConfigsBetaApi(config);
            var lDAPIVersion = "beta";  // string | Version of the endpoint.
            var projectKey = default;  // string | 
            var configKey = "configKey_example";  // string | 

            try
            {
                // Delete AI config
                apiInstance.DeleteAIConfig(lDAPIVersion, projectKey, configKey);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling AIConfigsBetaApi.DeleteAIConfig: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a id="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://app.launchdarkly.com*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AIConfigsBetaApi* | [**DeleteAIConfig**](docs/AIConfigsBetaApi.md#deleteaiconfig) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Delete AI config
*AIConfigsBetaApi* | [**DeleteAIConfigVariation**](docs/AIConfigsBetaApi.md#deleteaiconfigvariation) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Delete AI config variation
*AIConfigsBetaApi* | [**DeleteModelConfig**](docs/AIConfigsBetaApi.md#deletemodelconfig) | **DELETE** /api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey} | Delete an AI model config
*AIConfigsBetaApi* | [**GetAIConfig**](docs/AIConfigsBetaApi.md#getaiconfig) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Get AI config
*AIConfigsBetaApi* | [**GetAIConfigMetrics**](docs/AIConfigsBetaApi.md#getaiconfigmetrics) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics | Get AI config metrics
*AIConfigsBetaApi* | [**GetAIConfigMetricsByVariation**](docs/AIConfigsBetaApi.md#getaiconfigmetricsbyvariation) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/metrics-by-variation | Get AI config metrics by variation
*AIConfigsBetaApi* | [**GetAIConfigVariation**](docs/AIConfigsBetaApi.md#getaiconfigvariation) | **GET** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Get AI config variation
*AIConfigsBetaApi* | [**GetAIConfigs**](docs/AIConfigsBetaApi.md#getaiconfigs) | **GET** /api/v2/projects/{projectKey}/ai-configs | List AI configs
*AIConfigsBetaApi* | [**GetModelConfig**](docs/AIConfigsBetaApi.md#getmodelconfig) | **GET** /api/v2/projects/{projectKey}/ai-configs/model-configs/{modelConfigKey} | Get AI model config
*AIConfigsBetaApi* | [**ListModelConfigs**](docs/AIConfigsBetaApi.md#listmodelconfigs) | **GET** /api/v2/projects/{projectKey}/ai-configs/model-configs | List AI model configs
*AIConfigsBetaApi* | [**PatchAIConfig**](docs/AIConfigsBetaApi.md#patchaiconfig) | **PATCH** /api/v2/projects/{projectKey}/ai-configs/{configKey} | Update AI config
*AIConfigsBetaApi* | [**PatchAIConfigVariation**](docs/AIConfigsBetaApi.md#patchaiconfigvariation) | **PATCH** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations/{variationKey} | Update AI config variation
*AIConfigsBetaApi* | [**PostAIConfig**](docs/AIConfigsBetaApi.md#postaiconfig) | **POST** /api/v2/projects/{projectKey}/ai-configs | Create new AI config
*AIConfigsBetaApi* | [**PostAIConfigVariation**](docs/AIConfigsBetaApi.md#postaiconfigvariation) | **POST** /api/v2/projects/{projectKey}/ai-configs/{configKey}/variations | Create AI config variation
*AIConfigsBetaApi* | [**PostModelConfig**](docs/AIConfigsBetaApi.md#postmodelconfig) | **POST** /api/v2/projects/{projectKey}/ai-configs/model-configs | Create an AI model config
*AccessTokensApi* | [**DeleteToken**](docs/AccessTokensApi.md#deletetoken) | **DELETE** /api/v2/tokens/{id} | Delete access token
*AccessTokensApi* | [**GetToken**](docs/AccessTokensApi.md#gettoken) | **GET** /api/v2/tokens/{id} | Get access token
*AccessTokensApi* | [**GetTokens**](docs/AccessTokensApi.md#gettokens) | **GET** /api/v2/tokens | List access tokens
*AccessTokensApi* | [**PatchToken**](docs/AccessTokensApi.md#patchtoken) | **PATCH** /api/v2/tokens/{id} | Patch access token
*AccessTokensApi* | [**PostToken**](docs/AccessTokensApi.md#posttoken) | **POST** /api/v2/tokens | Create access token
*AccessTokensApi* | [**ResetToken**](docs/AccessTokensApi.md#resettoken) | **POST** /api/v2/tokens/{id}/reset | Reset access token
*AccountMembersApi* | [**DeleteMember**](docs/AccountMembersApi.md#deletemember) | **DELETE** /api/v2/members/{id} | Delete account member
*AccountMembersApi* | [**GetMember**](docs/AccountMembersApi.md#getmember) | **GET** /api/v2/members/{id} | Get account member
*AccountMembersApi* | [**GetMembers**](docs/AccountMembersApi.md#getmembers) | **GET** /api/v2/members | List account members
*AccountMembersApi* | [**PatchMember**](docs/AccountMembersApi.md#patchmember) | **PATCH** /api/v2/members/{id} | Modify an account member
*AccountMembersApi* | [**PostMemberTeams**](docs/AccountMembersApi.md#postmemberteams) | **POST** /api/v2/members/{id}/teams | Add a member to teams
*AccountMembersApi* | [**PostMembers**](docs/AccountMembersApi.md#postmembers) | **POST** /api/v2/members | Invite new members
*AccountMembersBetaApi* | [**PatchMembers**](docs/AccountMembersBetaApi.md#patchmembers) | **PATCH** /api/v2/members | Modify account members
*AccountUsageBetaApi* | [**GetDataExportEventsUsage**](docs/AccountUsageBetaApi.md#getdataexporteventsusage) | **GET** /api/v2/usage/data-export-events | Get data export events usage
*AccountUsageBetaApi* | [**GetEvaluationsUsage**](docs/AccountUsageBetaApi.md#getevaluationsusage) | **GET** /api/v2/usage/evaluations/{projectKey}/{environmentKey}/{featureFlagKey} | Get evaluations usage
*AccountUsageBetaApi* | [**GetEventsUsage**](docs/AccountUsageBetaApi.md#geteventsusage) | **GET** /api/v2/usage/events/{type} | Get events usage
*AccountUsageBetaApi* | [**GetExperimentationKeysUsage**](docs/AccountUsageBetaApi.md#getexperimentationkeysusage) | **GET** /api/v2/usage/experimentation-keys | Get experimentation keys usage
*AccountUsageBetaApi* | [**GetExperimentationUnitsUsage**](docs/AccountUsageBetaApi.md#getexperimentationunitsusage) | **GET** /api/v2/usage/experimentation-units | Get experimentation units usage
*AccountUsageBetaApi* | [**GetMauSdksByType**](docs/AccountUsageBetaApi.md#getmausdksbytype) | **GET** /api/v2/usage/mau/sdks | Get MAU SDKs by type
*AccountUsageBetaApi* | [**GetMauUsage**](docs/AccountUsageBetaApi.md#getmauusage) | **GET** /api/v2/usage/mau | Get MAU usage
*AccountUsageBetaApi* | [**GetMauUsageByCategory**](docs/AccountUsageBetaApi.md#getmauusagebycategory) | **GET** /api/v2/usage/mau/bycategory | Get MAU usage by category
*AccountUsageBetaApi* | [**GetServiceConnectionUsage**](docs/AccountUsageBetaApi.md#getserviceconnectionusage) | **GET** /api/v2/usage/service-connections | Get service connection usage
*AccountUsageBetaApi* | [**GetStreamUsage**](docs/AccountUsageBetaApi.md#getstreamusage) | **GET** /api/v2/usage/streams/{source} | Get stream usage
*AccountUsageBetaApi* | [**GetStreamUsageBySdkVersion**](docs/AccountUsageBetaApi.md#getstreamusagebysdkversion) | **GET** /api/v2/usage/streams/{source}/bysdkversion | Get stream usage by SDK version
*AccountUsageBetaApi* | [**GetStreamUsageSdkversion**](docs/AccountUsageBetaApi.md#getstreamusagesdkversion) | **GET** /api/v2/usage/streams/{source}/sdkversions | Get stream usage SDK versions
*ApplicationsBetaApi* | [**DeleteApplication**](docs/ApplicationsBetaApi.md#deleteapplication) | **DELETE** /api/v2/applications/{applicationKey} | Delete application
*ApplicationsBetaApi* | [**DeleteApplicationVersion**](docs/ApplicationsBetaApi.md#deleteapplicationversion) | **DELETE** /api/v2/applications/{applicationKey}/versions/{versionKey} | Delete application version
*ApplicationsBetaApi* | [**GetApplication**](docs/ApplicationsBetaApi.md#getapplication) | **GET** /api/v2/applications/{applicationKey} | Get application by key
*ApplicationsBetaApi* | [**GetApplicationVersions**](docs/ApplicationsBetaApi.md#getapplicationversions) | **GET** /api/v2/applications/{applicationKey}/versions | Get application versions by application key
*ApplicationsBetaApi* | [**GetApplications**](docs/ApplicationsBetaApi.md#getapplications) | **GET** /api/v2/applications | Get applications
*ApplicationsBetaApi* | [**PatchApplication**](docs/ApplicationsBetaApi.md#patchapplication) | **PATCH** /api/v2/applications/{applicationKey} | Update application
*ApplicationsBetaApi* | [**PatchApplicationVersion**](docs/ApplicationsBetaApi.md#patchapplicationversion) | **PATCH** /api/v2/applications/{applicationKey}/versions/{versionKey} | Update application version
*ApprovalsApi* | [**DeleteApprovalRequest**](docs/ApprovalsApi.md#deleteapprovalrequest) | **DELETE** /api/v2/approval-requests/{id} | Delete approval request
*ApprovalsApi* | [**DeleteApprovalRequestForFlag**](docs/ApprovalsApi.md#deleteapprovalrequestforflag) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Delete approval request for a flag
*ApprovalsApi* | [**GetApprovalForFlag**](docs/ApprovalsApi.md#getapprovalforflag) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Get approval request for a flag
*ApprovalsApi* | [**GetApprovalRequest**](docs/ApprovalsApi.md#getapprovalrequest) | **GET** /api/v2/approval-requests/{id} | Get approval request
*ApprovalsApi* | [**GetApprovalRequests**](docs/ApprovalsApi.md#getapprovalrequests) | **GET** /api/v2/approval-requests | List approval requests
*ApprovalsApi* | [**GetApprovalsForFlag**](docs/ApprovalsApi.md#getapprovalsforflag) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests | List approval requests for a flag
*ApprovalsApi* | [**PostApprovalRequest**](docs/ApprovalsApi.md#postapprovalrequest) | **POST** /api/v2/approval-requests | Create approval request
*ApprovalsApi* | [**PostApprovalRequestApply**](docs/ApprovalsApi.md#postapprovalrequestapply) | **POST** /api/v2/approval-requests/{id}/apply | Apply approval request
*ApprovalsApi* | [**PostApprovalRequestApplyForFlag**](docs/ApprovalsApi.md#postapprovalrequestapplyforflag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id}/apply | Apply approval request for a flag
*ApprovalsApi* | [**PostApprovalRequestForFlag**](docs/ApprovalsApi.md#postapprovalrequestforflag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests | Create approval request for a flag
*ApprovalsApi* | [**PostApprovalRequestReview**](docs/ApprovalsApi.md#postapprovalrequestreview) | **POST** /api/v2/approval-requests/{id}/reviews | Review approval request
*ApprovalsApi* | [**PostApprovalRequestReviewForFlag**](docs/ApprovalsApi.md#postapprovalrequestreviewforflag) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id}/reviews | Review approval request for a flag
*ApprovalsApi* | [**PostFlagCopyConfigApprovalRequest**](docs/ApprovalsApi.md#postflagcopyconfigapprovalrequest) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests-flag-copy | Create approval request to copy flag configurations across environments
*ApprovalsBetaApi* | [**PatchApprovalRequest**](docs/ApprovalsBetaApi.md#patchapprovalrequest) | **PATCH** /api/v2/approval-requests/{id} | Update approval request
*ApprovalsBetaApi* | [**PatchFlagConfigApprovalRequest**](docs/ApprovalsBetaApi.md#patchflagconfigapprovalrequest) | **PATCH** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/approval-requests/{id} | Update flag approval request
*AuditLogApi* | [**GetAuditLogEntries**](docs/AuditLogApi.md#getauditlogentries) | **GET** /api/v2/auditlog | List audit log entries
*AuditLogApi* | [**GetAuditLogEntry**](docs/AuditLogApi.md#getauditlogentry) | **GET** /api/v2/auditlog/{id} | Get audit log entry
*AuditLogApi* | [**PostAuditLogEntries**](docs/AuditLogApi.md#postauditlogentries) | **POST** /api/v2/auditlog | Search audit log entries
*CodeReferencesApi* | [**DeleteBranches**](docs/CodeReferencesApi.md#deletebranches) | **POST** /api/v2/code-refs/repositories/{repo}/branch-delete-tasks | Delete branches
*CodeReferencesApi* | [**DeleteRepository**](docs/CodeReferencesApi.md#deleterepository) | **DELETE** /api/v2/code-refs/repositories/{repo} | Delete repository
*CodeReferencesApi* | [**GetBranch**](docs/CodeReferencesApi.md#getbranch) | **GET** /api/v2/code-refs/repositories/{repo}/branches/{branch} | Get branch
*CodeReferencesApi* | [**GetBranches**](docs/CodeReferencesApi.md#getbranches) | **GET** /api/v2/code-refs/repositories/{repo}/branches | List branches
*CodeReferencesApi* | [**GetExtinctions**](docs/CodeReferencesApi.md#getextinctions) | **GET** /api/v2/code-refs/extinctions | List extinctions
*CodeReferencesApi* | [**GetRepositories**](docs/CodeReferencesApi.md#getrepositories) | **GET** /api/v2/code-refs/repositories | List repositories
*CodeReferencesApi* | [**GetRepository**](docs/CodeReferencesApi.md#getrepository) | **GET** /api/v2/code-refs/repositories/{repo} | Get repository
*CodeReferencesApi* | [**GetRootStatistic**](docs/CodeReferencesApi.md#getrootstatistic) | **GET** /api/v2/code-refs/statistics | Get links to code reference repositories for each project
*CodeReferencesApi* | [**GetStatistics**](docs/CodeReferencesApi.md#getstatistics) | **GET** /api/v2/code-refs/statistics/{projectKey} | Get code references statistics for flags
*CodeReferencesApi* | [**PatchRepository**](docs/CodeReferencesApi.md#patchrepository) | **PATCH** /api/v2/code-refs/repositories/{repo} | Update repository
*CodeReferencesApi* | [**PostExtinction**](docs/CodeReferencesApi.md#postextinction) | **POST** /api/v2/code-refs/repositories/{repo}/branches/{branch}/extinction-events | Create extinction
*CodeReferencesApi* | [**PostRepository**](docs/CodeReferencesApi.md#postrepository) | **POST** /api/v2/code-refs/repositories | Create repository
*CodeReferencesApi* | [**PutBranch**](docs/CodeReferencesApi.md#putbranch) | **PUT** /api/v2/code-refs/repositories/{repo}/branches/{branch} | Upsert branch
*ContextSettingsApi* | [**PutContextFlagSetting**](docs/ContextSettingsApi.md#putcontextflagsetting) | **PUT** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{contextKind}/{contextKey}/flags/{featureFlagKey} | Update flag settings for context
*ContextsApi* | [**DeleteContextInstances**](docs/ContextsApi.md#deletecontextinstances) | **DELETE** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id} | Delete context instances
*ContextsApi* | [**EvaluateContextInstance**](docs/ContextsApi.md#evaluatecontextinstance) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/flags/evaluate | Evaluate flags for context instance
*ContextsApi* | [**GetContextAttributeNames**](docs/ContextsApi.md#getcontextattributenames) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes | Get context attribute names
*ContextsApi* | [**GetContextAttributeValues**](docs/ContextsApi.md#getcontextattributevalues) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-attributes/{attributeName} | Get context attribute values
*ContextsApi* | [**GetContextInstances**](docs/ContextsApi.md#getcontextinstances) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/{id} | Get context instances
*ContextsApi* | [**GetContextKindsByProjectKey**](docs/ContextsApi.md#getcontextkindsbyprojectkey) | **GET** /api/v2/projects/{projectKey}/context-kinds | Get context kinds
*ContextsApi* | [**GetContexts**](docs/ContextsApi.md#getcontexts) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/{kind}/{key} | Get contexts
*ContextsApi* | [**PutContextKind**](docs/ContextsApi.md#putcontextkind) | **PUT** /api/v2/projects/{projectKey}/context-kinds/{key} | Create or update context kind
*ContextsApi* | [**SearchContextInstances**](docs/ContextsApi.md#searchcontextinstances) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/context-instances/search | Search for context instances
*ContextsApi* | [**SearchContexts**](docs/ContextsApi.md#searchcontexts) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/contexts/search | Search for contexts
*CustomRolesApi* | [**DeleteCustomRole**](docs/CustomRolesApi.md#deletecustomrole) | **DELETE** /api/v2/roles/{customRoleKey} | Delete custom role
*CustomRolesApi* | [**GetCustomRole**](docs/CustomRolesApi.md#getcustomrole) | **GET** /api/v2/roles/{customRoleKey} | Get custom role
*CustomRolesApi* | [**GetCustomRoles**](docs/CustomRolesApi.md#getcustomroles) | **GET** /api/v2/roles | List custom roles
*CustomRolesApi* | [**PatchCustomRole**](docs/CustomRolesApi.md#patchcustomrole) | **PATCH** /api/v2/roles/{customRoleKey} | Update custom role
*CustomRolesApi* | [**PostCustomRole**](docs/CustomRolesApi.md#postcustomrole) | **POST** /api/v2/roles | Create custom role
*DataExportDestinationsApi* | [**DeleteDestination**](docs/DataExportDestinationsApi.md#deletedestination) | **DELETE** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Delete Data Export destination
*DataExportDestinationsApi* | [**GetDestination**](docs/DataExportDestinationsApi.md#getdestination) | **GET** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Get destination
*DataExportDestinationsApi* | [**GetDestinations**](docs/DataExportDestinationsApi.md#getdestinations) | **GET** /api/v2/destinations | List destinations
*DataExportDestinationsApi* | [**PatchDestination**](docs/DataExportDestinationsApi.md#patchdestination) | **PATCH** /api/v2/destinations/{projectKey}/{environmentKey}/{id} | Update Data Export destination
*DataExportDestinationsApi* | [**PostDestination**](docs/DataExportDestinationsApi.md#postdestination) | **POST** /api/v2/destinations/{projectKey}/{environmentKey} | Create Data Export destination
*EnvironmentsApi* | [**DeleteEnvironment**](docs/EnvironmentsApi.md#deleteenvironment) | **DELETE** /api/v2/projects/{projectKey}/environments/{environmentKey} | Delete environment
*EnvironmentsApi* | [**GetEnvironment**](docs/EnvironmentsApi.md#getenvironment) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey} | Get environment
*EnvironmentsApi* | [**GetEnvironmentsByProject**](docs/EnvironmentsApi.md#getenvironmentsbyproject) | **GET** /api/v2/projects/{projectKey}/environments | List environments
*EnvironmentsApi* | [**PatchEnvironment**](docs/EnvironmentsApi.md#patchenvironment) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey} | Update environment
*EnvironmentsApi* | [**PostEnvironment**](docs/EnvironmentsApi.md#postenvironment) | **POST** /api/v2/projects/{projectKey}/environments | Create environment
*EnvironmentsApi* | [**ResetEnvironmentMobileKey**](docs/EnvironmentsApi.md#resetenvironmentmobilekey) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/mobileKey | Reset environment mobile SDK key
*EnvironmentsApi* | [**ResetEnvironmentSDKKey**](docs/EnvironmentsApi.md#resetenvironmentsdkkey) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/apiKey | Reset environment SDK key
*ExperimentsApi* | [**CreateExperiment**](docs/ExperimentsApi.md#createexperiment) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments | Create experiment
*ExperimentsApi* | [**CreateIteration**](docs/ExperimentsApi.md#createiteration) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/iterations | Create iteration
*ExperimentsApi* | [**GetExperiment**](docs/ExperimentsApi.md#getexperiment) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey} | Get experiment
*ExperimentsApi* | [**GetExperimentResults**](docs/ExperimentsApi.md#getexperimentresults) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metrics/{metricKey}/results | Get experiment results
*ExperimentsApi* | [**GetExperimentResultsForMetricGroup**](docs/ExperimentsApi.md#getexperimentresultsformetricgroup) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey}/metric-groups/{metricGroupKey}/results | Get experiment results for metric group
*ExperimentsApi* | [**GetExperimentationSettings**](docs/ExperimentsApi.md#getexperimentationsettings) | **GET** /api/v2/projects/{projectKey}/experimentation-settings | Get experimentation settings
*ExperimentsApi* | [**GetExperiments**](docs/ExperimentsApi.md#getexperiments) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments | Get experiments
*ExperimentsApi* | [**PatchExperiment**](docs/ExperimentsApi.md#patchexperiment) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey}/experiments/{experimentKey} | Patch experiment
*ExperimentsApi* | [**PutExperimentationSettings**](docs/ExperimentsApi.md#putexperimentationsettings) | **PUT** /api/v2/projects/{projectKey}/experimentation-settings | Update experimentation settings
*FeatureFlagsApi* | [**CopyFeatureFlag**](docs/FeatureFlagsApi.md#copyfeatureflag) | **POST** /api/v2/flags/{projectKey}/{featureFlagKey}/copy | Copy feature flag
*FeatureFlagsApi* | [**DeleteFeatureFlag**](docs/FeatureFlagsApi.md#deletefeatureflag) | **DELETE** /api/v2/flags/{projectKey}/{featureFlagKey} | Delete feature flag
*FeatureFlagsApi* | [**GetExpiringContextTargets**](docs/FeatureFlagsApi.md#getexpiringcontexttargets) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-targets/{environmentKey} | Get expiring context targets for feature flag
*FeatureFlagsApi* | [**GetExpiringUserTargets**](docs/FeatureFlagsApi.md#getexpiringusertargets) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-user-targets/{environmentKey} | Get expiring user targets for feature flag
*FeatureFlagsApi* | [**GetFeatureFlag**](docs/FeatureFlagsApi.md#getfeatureflag) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey} | Get feature flag
*FeatureFlagsApi* | [**GetFeatureFlagStatus**](docs/FeatureFlagsApi.md#getfeatureflagstatus) | **GET** /api/v2/flag-statuses/{projectKey}/{environmentKey}/{featureFlagKey} | Get feature flag status
*FeatureFlagsApi* | [**GetFeatureFlagStatusAcrossEnvironments**](docs/FeatureFlagsApi.md#getfeatureflagstatusacrossenvironments) | **GET** /api/v2/flag-status/{projectKey}/{featureFlagKey} | Get flag status across environments
*FeatureFlagsApi* | [**GetFeatureFlagStatuses**](docs/FeatureFlagsApi.md#getfeatureflagstatuses) | **GET** /api/v2/flag-statuses/{projectKey}/{environmentKey} | List feature flag statuses
*FeatureFlagsApi* | [**GetFeatureFlags**](docs/FeatureFlagsApi.md#getfeatureflags) | **GET** /api/v2/flags/{projectKey} | List feature flags
*FeatureFlagsApi* | [**PatchExpiringTargets**](docs/FeatureFlagsApi.md#patchexpiringtargets) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-targets/{environmentKey} | Update expiring context targets on feature flag
*FeatureFlagsApi* | [**PatchExpiringUserTargets**](docs/FeatureFlagsApi.md#patchexpiringusertargets) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/expiring-user-targets/{environmentKey} | Update expiring user targets on feature flag
*FeatureFlagsApi* | [**PatchFeatureFlag**](docs/FeatureFlagsApi.md#patchfeatureflag) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey} | Update feature flag
*FeatureFlagsApi* | [**PostFeatureFlag**](docs/FeatureFlagsApi.md#postfeatureflag) | **POST** /api/v2/flags/{projectKey} | Create a feature flag
*FeatureFlagsApi* | [**PostMigrationSafetyIssues**](docs/FeatureFlagsApi.md#postmigrationsafetyissues) | **POST** /api/v2/projects/{projectKey}/flags/{flagKey}/environments/{environmentKey}/migration-safety-issues | Get migration safety issues
*FeatureFlagsBetaApi* | [**GetDependentFlags**](docs/FeatureFlagsBetaApi.md#getdependentflags) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/dependent-flags | List dependent feature flags
*FeatureFlagsBetaApi* | [**GetDependentFlagsByEnv**](docs/FeatureFlagsBetaApi.md#getdependentflagsbyenv) | **GET** /api/v2/flags/{projectKey}/{environmentKey}/{featureFlagKey}/dependent-flags | List dependent feature flags by environment
*FlagImportConfigurationsBetaApi* | [**CreateFlagImportConfiguration**](docs/FlagImportConfigurationsBetaApi.md#createflagimportconfiguration) | **POST** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey} | Create a flag import configuration
*FlagImportConfigurationsBetaApi* | [**DeleteFlagImportConfiguration**](docs/FlagImportConfigurationsBetaApi.md#deleteflagimportconfiguration) | **DELETE** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Delete a flag import configuration
*FlagImportConfigurationsBetaApi* | [**GetFlagImportConfiguration**](docs/FlagImportConfigurationsBetaApi.md#getflagimportconfiguration) | **GET** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Get a single flag import configuration
*FlagImportConfigurationsBetaApi* | [**GetFlagImportConfigurations**](docs/FlagImportConfigurationsBetaApi.md#getflagimportconfigurations) | **GET** /api/v2/integration-capabilities/flag-import | List all flag import configurations
*FlagImportConfigurationsBetaApi* | [**PatchFlagImportConfiguration**](docs/FlagImportConfigurationsBetaApi.md#patchflagimportconfiguration) | **PATCH** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId} | Update a flag import configuration
*FlagImportConfigurationsBetaApi* | [**TriggerFlagImportJob**](docs/FlagImportConfigurationsBetaApi.md#triggerflagimportjob) | **POST** /api/v2/integration-capabilities/flag-import/{projectKey}/{integrationKey}/{integrationId}/trigger | Trigger a single flag import run
*FlagLinksBetaApi* | [**CreateFlagLink**](docs/FlagLinksBetaApi.md#createflaglink) | **POST** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey} | Create flag link
*FlagLinksBetaApi* | [**DeleteFlagLink**](docs/FlagLinksBetaApi.md#deleteflaglink) | **DELETE** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey}/{id} | Delete flag link
*FlagLinksBetaApi* | [**GetFlagLinks**](docs/FlagLinksBetaApi.md#getflaglinks) | **GET** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey} | List flag links
*FlagLinksBetaApi* | [**UpdateFlagLink**](docs/FlagLinksBetaApi.md#updateflaglink) | **PATCH** /api/v2/flag-links/projects/{projectKey}/flags/{featureFlagKey}/{id} | Update flag link
*FlagTriggersApi* | [**CreateTriggerWorkflow**](docs/FlagTriggersApi.md#createtriggerworkflow) | **POST** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey} | Create flag trigger
*FlagTriggersApi* | [**DeleteTriggerWorkflow**](docs/FlagTriggersApi.md#deletetriggerworkflow) | **DELETE** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Delete flag trigger
*FlagTriggersApi* | [**GetTriggerWorkflowById**](docs/FlagTriggersApi.md#gettriggerworkflowbyid) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Get flag trigger by ID
*FlagTriggersApi* | [**GetTriggerWorkflows**](docs/FlagTriggersApi.md#gettriggerworkflows) | **GET** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey} | List flag triggers
*FlagTriggersApi* | [**PatchTriggerWorkflow**](docs/FlagTriggersApi.md#patchtriggerworkflow) | **PATCH** /api/v2/flags/{projectKey}/{featureFlagKey}/triggers/{environmentKey}/{id} | Update flag trigger
*FollowFlagsApi* | [**DeleteFlagFollower**](docs/FollowFlagsApi.md#deleteflagfollower) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers/{memberId} | Remove a member as a follower of a flag in a project and environment
*FollowFlagsApi* | [**GetFlagFollowers**](docs/FollowFlagsApi.md#getflagfollowers) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers | Get followers of a flag in a project and environment
*FollowFlagsApi* | [**GetFollowersByProjEnv**](docs/FollowFlagsApi.md#getfollowersbyprojenv) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/followers | Get followers of all flags in a given project and environment
*FollowFlagsApi* | [**PutFlagFollower**](docs/FollowFlagsApi.md#putflagfollower) | **PUT** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/followers/{memberId} | Add a member as a follower of a flag in a project and environment
*HoldoutsBetaApi* | [**GetAllHoldouts**](docs/HoldoutsBetaApi.md#getallholdouts) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts | Get all holdouts
*HoldoutsBetaApi* | [**GetHoldout**](docs/HoldoutsBetaApi.md#getholdout) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/{holdoutKey} | Get holdout
*HoldoutsBetaApi* | [**GetHoldoutById**](docs/HoldoutsBetaApi.md#getholdoutbyid) | **GET** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/id/{holdoutId} | Get Holdout by Id
*HoldoutsBetaApi* | [**PatchHoldout**](docs/HoldoutsBetaApi.md#patchholdout) | **PATCH** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts/{holdoutKey} | Patch holdout
*HoldoutsBetaApi* | [**PostHoldout**](docs/HoldoutsBetaApi.md#postholdout) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/holdouts | Create holdout
*InsightsChartsBetaApi* | [**GetDeploymentFrequencyChart**](docs/InsightsChartsBetaApi.md#getdeploymentfrequencychart) | **GET** /api/v2/engineering-insights/charts/deployments/frequency | Get deployment frequency chart data
*InsightsChartsBetaApi* | [**GetFlagStatusChart**](docs/InsightsChartsBetaApi.md#getflagstatuschart) | **GET** /api/v2/engineering-insights/charts/flags/status | Get flag status chart data
*InsightsChartsBetaApi* | [**GetLeadTimeChart**](docs/InsightsChartsBetaApi.md#getleadtimechart) | **GET** /api/v2/engineering-insights/charts/lead-time | Get lead time chart data
*InsightsChartsBetaApi* | [**GetReleaseFrequencyChart**](docs/InsightsChartsBetaApi.md#getreleasefrequencychart) | **GET** /api/v2/engineering-insights/charts/releases/frequency | Get release frequency chart data
*InsightsChartsBetaApi* | [**GetStaleFlagsChart**](docs/InsightsChartsBetaApi.md#getstaleflagschart) | **GET** /api/v2/engineering-insights/charts/flags/stale | Get stale flags chart data
*InsightsDeploymentsBetaApi* | [**CreateDeploymentEvent**](docs/InsightsDeploymentsBetaApi.md#createdeploymentevent) | **POST** /api/v2/engineering-insights/deployment-events | Create deployment event
*InsightsDeploymentsBetaApi* | [**GetDeployment**](docs/InsightsDeploymentsBetaApi.md#getdeployment) | **GET** /api/v2/engineering-insights/deployments/{deploymentID} | Get deployment
*InsightsDeploymentsBetaApi* | [**GetDeployments**](docs/InsightsDeploymentsBetaApi.md#getdeployments) | **GET** /api/v2/engineering-insights/deployments | List deployments
*InsightsDeploymentsBetaApi* | [**UpdateDeployment**](docs/InsightsDeploymentsBetaApi.md#updatedeployment) | **PATCH** /api/v2/engineering-insights/deployments/{deploymentID} | Update deployment
*InsightsFlagEventsBetaApi* | [**GetFlagEvents**](docs/InsightsFlagEventsBetaApi.md#getflagevents) | **GET** /api/v2/engineering-insights/flag-events | List flag events
*InsightsPullRequestsBetaApi* | [**GetPullRequests**](docs/InsightsPullRequestsBetaApi.md#getpullrequests) | **GET** /api/v2/engineering-insights/pull-requests | List pull requests
*InsightsRepositoriesBetaApi* | [**AssociateRepositoriesAndProjects**](docs/InsightsRepositoriesBetaApi.md#associaterepositoriesandprojects) | **PUT** /api/v2/engineering-insights/repositories/projects | Associate repositories with projects
*InsightsRepositoriesBetaApi* | [**DeleteRepositoryProject**](docs/InsightsRepositoriesBetaApi.md#deleterepositoryproject) | **DELETE** /api/v2/engineering-insights/repositories/{repositoryKey}/projects/{projectKey} | Remove repository project association
*InsightsRepositoriesBetaApi* | [**GetInsightsRepositories**](docs/InsightsRepositoriesBetaApi.md#getinsightsrepositories) | **GET** /api/v2/engineering-insights/repositories | List repositories
*InsightsScoresBetaApi* | [**CreateInsightGroup**](docs/InsightsScoresBetaApi.md#createinsightgroup) | **POST** /api/v2/engineering-insights/insights/group | Create insight group
*InsightsScoresBetaApi* | [**DeleteInsightGroup**](docs/InsightsScoresBetaApi.md#deleteinsightgroup) | **DELETE** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Delete insight group
*InsightsScoresBetaApi* | [**GetInsightGroup**](docs/InsightsScoresBetaApi.md#getinsightgroup) | **GET** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Get insight group
*InsightsScoresBetaApi* | [**GetInsightGroups**](docs/InsightsScoresBetaApi.md#getinsightgroups) | **GET** /api/v2/engineering-insights/insights/groups | List insight groups
*InsightsScoresBetaApi* | [**GetInsightsScores**](docs/InsightsScoresBetaApi.md#getinsightsscores) | **GET** /api/v2/engineering-insights/insights/scores | Get insight scores
*InsightsScoresBetaApi* | [**PatchInsightGroup**](docs/InsightsScoresBetaApi.md#patchinsightgroup) | **PATCH** /api/v2/engineering-insights/insights/groups/{insightGroupKey} | Patch insight group
*IntegrationAuditLogSubscriptionsApi* | [**CreateSubscription**](docs/IntegrationAuditLogSubscriptionsApi.md#createsubscription) | **POST** /api/v2/integrations/{integrationKey} | Create audit log subscription
*IntegrationAuditLogSubscriptionsApi* | [**DeleteSubscription**](docs/IntegrationAuditLogSubscriptionsApi.md#deletesubscription) | **DELETE** /api/v2/integrations/{integrationKey}/{id} | Delete audit log subscription
*IntegrationAuditLogSubscriptionsApi* | [**GetSubscriptionByID**](docs/IntegrationAuditLogSubscriptionsApi.md#getsubscriptionbyid) | **GET** /api/v2/integrations/{integrationKey}/{id} | Get audit log subscription by ID
*IntegrationAuditLogSubscriptionsApi* | [**GetSubscriptions**](docs/IntegrationAuditLogSubscriptionsApi.md#getsubscriptions) | **GET** /api/v2/integrations/{integrationKey} | Get audit log subscriptions by integration
*IntegrationAuditLogSubscriptionsApi* | [**UpdateSubscription**](docs/IntegrationAuditLogSubscriptionsApi.md#updatesubscription) | **PATCH** /api/v2/integrations/{integrationKey}/{id} | Update audit log subscription
*IntegrationDeliveryConfigurationsBetaApi* | [**CreateIntegrationDeliveryConfiguration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#createintegrationdeliveryconfiguration) | **POST** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey} | Create delivery configuration
*IntegrationDeliveryConfigurationsBetaApi* | [**DeleteIntegrationDeliveryConfiguration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#deleteintegrationdeliveryconfiguration) | **DELETE** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Delete delivery configuration
*IntegrationDeliveryConfigurationsBetaApi* | [**GetIntegrationDeliveryConfigurationByEnvironment**](docs/IntegrationDeliveryConfigurationsBetaApi.md#getintegrationdeliveryconfigurationbyenvironment) | **GET** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey} | Get delivery configurations by environment
*IntegrationDeliveryConfigurationsBetaApi* | [**GetIntegrationDeliveryConfigurationById**](docs/IntegrationDeliveryConfigurationsBetaApi.md#getintegrationdeliveryconfigurationbyid) | **GET** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Get delivery configuration by ID
*IntegrationDeliveryConfigurationsBetaApi* | [**GetIntegrationDeliveryConfigurations**](docs/IntegrationDeliveryConfigurationsBetaApi.md#getintegrationdeliveryconfigurations) | **GET** /api/v2/integration-capabilities/featureStore | List all delivery configurations
*IntegrationDeliveryConfigurationsBetaApi* | [**PatchIntegrationDeliveryConfiguration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#patchintegrationdeliveryconfiguration) | **PATCH** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id} | Update delivery configuration
*IntegrationDeliveryConfigurationsBetaApi* | [**ValidateIntegrationDeliveryConfiguration**](docs/IntegrationDeliveryConfigurationsBetaApi.md#validateintegrationdeliveryconfiguration) | **POST** /api/v2/integration-capabilities/featureStore/{projectKey}/{environmentKey}/{integrationKey}/{id}/validate | Validate delivery configuration
*IntegrationsBetaApi* | [**CreateIntegrationConfiguration**](docs/IntegrationsBetaApi.md#createintegrationconfiguration) | **POST** /api/v2/integration-configurations/keys/{integrationKey} | Create integration configuration
*IntegrationsBetaApi* | [**DeleteIntegrationConfiguration**](docs/IntegrationsBetaApi.md#deleteintegrationconfiguration) | **DELETE** /api/v2/integration-configurations/{integrationConfigurationId} | Delete integration configuration
*IntegrationsBetaApi* | [**GetAllIntegrationConfigurations**](docs/IntegrationsBetaApi.md#getallintegrationconfigurations) | **GET** /api/v2/integration-configurations/keys/{integrationKey} | Get all configurations for the integration
*IntegrationsBetaApi* | [**GetIntegrationConfiguration**](docs/IntegrationsBetaApi.md#getintegrationconfiguration) | **GET** /api/v2/integration-configurations/{integrationConfigurationId} | Get an integration configuration
*IntegrationsBetaApi* | [**UpdateIntegrationConfiguration**](docs/IntegrationsBetaApi.md#updateintegrationconfiguration) | **PATCH** /api/v2/integration-configurations/{integrationConfigurationId} | Update integration configuration
*LayersApi* | [**CreateLayer**](docs/LayersApi.md#createlayer) | **POST** /api/v2/projects/{projectKey}/layers | Create layer
*LayersApi* | [**GetLayers**](docs/LayersApi.md#getlayers) | **GET** /api/v2/projects/{projectKey}/layers | Get layers
*LayersApi* | [**UpdateLayer**](docs/LayersApi.md#updatelayer) | **PATCH** /api/v2/projects/{projectKey}/layers/{layerKey} | Update layer
*MetricsApi* | [**DeleteMetric**](docs/MetricsApi.md#deletemetric) | **DELETE** /api/v2/metrics/{projectKey}/{metricKey} | Delete metric
*MetricsApi* | [**GetMetric**](docs/MetricsApi.md#getmetric) | **GET** /api/v2/metrics/{projectKey}/{metricKey} | Get metric
*MetricsApi* | [**GetMetrics**](docs/MetricsApi.md#getmetrics) | **GET** /api/v2/metrics/{projectKey} | List metrics
*MetricsApi* | [**PatchMetric**](docs/MetricsApi.md#patchmetric) | **PATCH** /api/v2/metrics/{projectKey}/{metricKey} | Update metric
*MetricsApi* | [**PostMetric**](docs/MetricsApi.md#postmetric) | **POST** /api/v2/metrics/{projectKey} | Create metric
*MetricsBetaApi* | [**CreateMetricGroup**](docs/MetricsBetaApi.md#createmetricgroup) | **POST** /api/v2/projects/{projectKey}/metric-groups | Create metric group
*MetricsBetaApi* | [**DeleteMetricGroup**](docs/MetricsBetaApi.md#deletemetricgroup) | **DELETE** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Delete metric group
*MetricsBetaApi* | [**GetMetricGroup**](docs/MetricsBetaApi.md#getmetricgroup) | **GET** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Get metric group
*MetricsBetaApi* | [**GetMetricGroups**](docs/MetricsBetaApi.md#getmetricgroups) | **GET** /api/v2/projects/{projectKey}/metric-groups | List metric groups
*MetricsBetaApi* | [**PatchMetricGroup**](docs/MetricsBetaApi.md#patchmetricgroup) | **PATCH** /api/v2/projects/{projectKey}/metric-groups/{metricGroupKey} | Patch metric group
*OAuth2ClientsApi* | [**CreateOAuth2Client**](docs/OAuth2ClientsApi.md#createoauth2client) | **POST** /api/v2/oauth/clients | Create a LaunchDarkly OAuth 2.0 client
*OAuth2ClientsApi* | [**DeleteOAuthClient**](docs/OAuth2ClientsApi.md#deleteoauthclient) | **DELETE** /api/v2/oauth/clients/{clientId} | Delete OAuth 2.0 client
*OAuth2ClientsApi* | [**GetOAuthClientById**](docs/OAuth2ClientsApi.md#getoauthclientbyid) | **GET** /api/v2/oauth/clients/{clientId} | Get client by ID
*OAuth2ClientsApi* | [**GetOAuthClients**](docs/OAuth2ClientsApi.md#getoauthclients) | **GET** /api/v2/oauth/clients | Get clients
*OAuth2ClientsApi* | [**PatchOAuthClient**](docs/OAuth2ClientsApi.md#patchoauthclient) | **PATCH** /api/v2/oauth/clients/{clientId} | Patch client by ID
*OtherApi* | [**GetCallerIdentity**](docs/OtherApi.md#getcalleridentity) | **GET** /api/v2/caller-identity | Identify the caller
*OtherApi* | [**GetIps**](docs/OtherApi.md#getips) | **GET** /api/v2/public-ip-list | Gets the public IP list
*OtherApi* | [**GetOpenapiSpec**](docs/OtherApi.md#getopenapispec) | **GET** /api/v2/openapi.json | Gets the OpenAPI spec in json
*OtherApi* | [**GetRoot**](docs/OtherApi.md#getroot) | **GET** /api/v2 | Root resource
*OtherApi* | [**GetVersions**](docs/OtherApi.md#getversions) | **GET** /api/v2/versions | Get version information
*PersistentStoreIntegrationsBetaApi* | [**CreateBigSegmentStoreIntegration**](docs/PersistentStoreIntegrationsBetaApi.md#createbigsegmentstoreintegration) | **POST** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey} | Create big segment store integration
*PersistentStoreIntegrationsBetaApi* | [**DeleteBigSegmentStoreIntegration**](docs/PersistentStoreIntegrationsBetaApi.md#deletebigsegmentstoreintegration) | **DELETE** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Delete big segment store integration
*PersistentStoreIntegrationsBetaApi* | [**GetBigSegmentStoreIntegration**](docs/PersistentStoreIntegrationsBetaApi.md#getbigsegmentstoreintegration) | **GET** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Get big segment store integration by ID
*PersistentStoreIntegrationsBetaApi* | [**GetBigSegmentStoreIntegrations**](docs/PersistentStoreIntegrationsBetaApi.md#getbigsegmentstoreintegrations) | **GET** /api/v2/integration-capabilities/big-segment-store | List all big segment store integrations
*PersistentStoreIntegrationsBetaApi* | [**PatchBigSegmentStoreIntegration**](docs/PersistentStoreIntegrationsBetaApi.md#patchbigsegmentstoreintegration) | **PATCH** /api/v2/integration-capabilities/big-segment-store/{projectKey}/{environmentKey}/{integrationKey}/{integrationId} | Update big segment store integration
*ProjectsApi* | [**DeleteProject**](docs/ProjectsApi.md#deleteproject) | **DELETE** /api/v2/projects/{projectKey} | Delete project
*ProjectsApi* | [**GetFlagDefaultsByProject**](docs/ProjectsApi.md#getflagdefaultsbyproject) | **GET** /api/v2/projects/{projectKey}/flag-defaults | Get flag defaults for project
*ProjectsApi* | [**GetProject**](docs/ProjectsApi.md#getproject) | **GET** /api/v2/projects/{projectKey} | Get project
*ProjectsApi* | [**GetProjects**](docs/ProjectsApi.md#getprojects) | **GET** /api/v2/projects | List projects
*ProjectsApi* | [**PatchFlagDefaultsByProject**](docs/ProjectsApi.md#patchflagdefaultsbyproject) | **PATCH** /api/v2/projects/{projectKey}/flag-defaults | Update flag default for project
*ProjectsApi* | [**PatchProject**](docs/ProjectsApi.md#patchproject) | **PATCH** /api/v2/projects/{projectKey} | Update project
*ProjectsApi* | [**PostProject**](docs/ProjectsApi.md#postproject) | **POST** /api/v2/projects | Create project
*ProjectsApi* | [**PutFlagDefaultsByProject**](docs/ProjectsApi.md#putflagdefaultsbyproject) | **PUT** /api/v2/projects/{projectKey}/flag-defaults | Create or update flag defaults for project
*RelayProxyConfigurationsApi* | [**DeleteRelayAutoConfig**](docs/RelayProxyConfigurationsApi.md#deleterelayautoconfig) | **DELETE** /api/v2/account/relay-auto-configs/{id} | Delete Relay Proxy config by ID
*RelayProxyConfigurationsApi* | [**GetRelayProxyConfig**](docs/RelayProxyConfigurationsApi.md#getrelayproxyconfig) | **GET** /api/v2/account/relay-auto-configs/{id} | Get Relay Proxy config
*RelayProxyConfigurationsApi* | [**GetRelayProxyConfigs**](docs/RelayProxyConfigurationsApi.md#getrelayproxyconfigs) | **GET** /api/v2/account/relay-auto-configs | List Relay Proxy configs
*RelayProxyConfigurationsApi* | [**PatchRelayAutoConfig**](docs/RelayProxyConfigurationsApi.md#patchrelayautoconfig) | **PATCH** /api/v2/account/relay-auto-configs/{id} | Update a Relay Proxy config
*RelayProxyConfigurationsApi* | [**PostRelayAutoConfig**](docs/RelayProxyConfigurationsApi.md#postrelayautoconfig) | **POST** /api/v2/account/relay-auto-configs | Create a new Relay Proxy config
*RelayProxyConfigurationsApi* | [**ResetRelayAutoConfig**](docs/RelayProxyConfigurationsApi.md#resetrelayautoconfig) | **POST** /api/v2/account/relay-auto-configs/{id}/reset | Reset Relay Proxy configuration key
*ReleasePipelinesBetaApi* | [**DeleteReleasePipeline**](docs/ReleasePipelinesBetaApi.md#deletereleasepipeline) | **DELETE** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Delete release pipeline
*ReleasePipelinesBetaApi* | [**GetAllReleasePipelines**](docs/ReleasePipelinesBetaApi.md#getallreleasepipelines) | **GET** /api/v2/projects/{projectKey}/release-pipelines | Get all release pipelines
*ReleasePipelinesBetaApi* | [**GetAllReleaseProgressionsForReleasePipeline**](docs/ReleasePipelinesBetaApi.md#getallreleaseprogressionsforreleasepipeline) | **GET** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey}/releases | Get release progressions for release pipeline
*ReleasePipelinesBetaApi* | [**GetReleasePipelineByKey**](docs/ReleasePipelinesBetaApi.md#getreleasepipelinebykey) | **GET** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Get release pipeline by key
*ReleasePipelinesBetaApi* | [**PostReleasePipeline**](docs/ReleasePipelinesBetaApi.md#postreleasepipeline) | **POST** /api/v2/projects/{projectKey}/release-pipelines | Create a release pipeline
*ReleasePipelinesBetaApi* | [**PutReleasePipeline**](docs/ReleasePipelinesBetaApi.md#putreleasepipeline) | **PUT** /api/v2/projects/{projectKey}/release-pipelines/{pipelineKey} | Update a release pipeline
*ReleasesBetaApi* | [**CreateReleaseForFlag**](docs/ReleasesBetaApi.md#createreleaseforflag) | **PUT** /api/v2/projects/{projectKey}/flags/{flagKey}/release | Create a new release for flag
*ReleasesBetaApi* | [**DeleteReleaseByFlagKey**](docs/ReleasesBetaApi.md#deletereleasebyflagkey) | **DELETE** /api/v2/flags/{projectKey}/{flagKey}/release | Delete a release for flag
*ReleasesBetaApi* | [**GetReleaseByFlagKey**](docs/ReleasesBetaApi.md#getreleasebyflagkey) | **GET** /api/v2/flags/{projectKey}/{flagKey}/release | Get release for flag
*ReleasesBetaApi* | [**PatchReleaseByFlagKey**](docs/ReleasesBetaApi.md#patchreleasebyflagkey) | **PATCH** /api/v2/flags/{projectKey}/{flagKey}/release | Patch release for flag
*ReleasesBetaApi* | [**UpdatePhaseStatus**](docs/ReleasesBetaApi.md#updatephasestatus) | **PUT** /api/v2/projects/{projectKey}/flags/{flagKey}/release/phases/{phaseId} | Update phase status for release
*ScheduledChangesApi* | [**DeleteFlagConfigScheduledChanges**](docs/ScheduledChangesApi.md#deleteflagconfigscheduledchanges) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Delete scheduled changes workflow
*ScheduledChangesApi* | [**GetFeatureFlagScheduledChange**](docs/ScheduledChangesApi.md#getfeatureflagscheduledchange) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Get a scheduled change
*ScheduledChangesApi* | [**GetFlagConfigScheduledChanges**](docs/ScheduledChangesApi.md#getflagconfigscheduledchanges) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes | List scheduled changes
*ScheduledChangesApi* | [**PatchFlagConfigScheduledChange**](docs/ScheduledChangesApi.md#patchflagconfigscheduledchange) | **PATCH** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes/{id} | Update scheduled changes workflow
*ScheduledChangesApi* | [**PostFlagConfigScheduledChanges**](docs/ScheduledChangesApi.md#postflagconfigscheduledchanges) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/scheduled-changes | Create scheduled changes workflow
*SegmentsApi* | [**CreateBigSegmentExport**](docs/SegmentsApi.md#createbigsegmentexport) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports | Create big segment export
*SegmentsApi* | [**CreateBigSegmentImport**](docs/SegmentsApi.md#createbigsegmentimport) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports | Create big segment import
*SegmentsApi* | [**DeleteSegment**](docs/SegmentsApi.md#deletesegment) | **DELETE** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Delete segment
*SegmentsApi* | [**GetBigSegmentExport**](docs/SegmentsApi.md#getbigsegmentexport) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/exports/{exportID} | Get big segment export
*SegmentsApi* | [**GetBigSegmentImport**](docs/SegmentsApi.md#getbigsegmentimport) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/imports/{importID} | Get big segment import
*SegmentsApi* | [**GetContextInstanceSegmentsMembershipByEnv**](docs/SegmentsApi.md#getcontextinstancesegmentsmembershipbyenv) | **POST** /api/v2/projects/{projectKey}/environments/{environmentKey}/segments/evaluate | List segment memberships for context instance
*SegmentsApi* | [**GetExpiringTargetsForSegment**](docs/SegmentsApi.md#getexpiringtargetsforsegment) | **GET** /api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey} | Get expiring targets for segment
*SegmentsApi* | [**GetExpiringUserTargetsForSegment**](docs/SegmentsApi.md#getexpiringusertargetsforsegment) | **GET** /api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey} | Get expiring user targets for segment
*SegmentsApi* | [**GetSegment**](docs/SegmentsApi.md#getsegment) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Get segment
*SegmentsApi* | [**GetSegmentMembershipForContext**](docs/SegmentsApi.md#getsegmentmembershipforcontext) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts/{contextKey} | Get big segment membership for context
*SegmentsApi* | [**GetSegmentMembershipForUser**](docs/SegmentsApi.md#getsegmentmembershipforuser) | **GET** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users/{userKey} | Get big segment membership for user
*SegmentsApi* | [**GetSegments**](docs/SegmentsApi.md#getsegments) | **GET** /api/v2/segments/{projectKey}/{environmentKey} | List segments
*SegmentsApi* | [**PatchExpiringTargetsForSegment**](docs/SegmentsApi.md#patchexpiringtargetsforsegment) | **PATCH** /api/v2/segments/{projectKey}/{segmentKey}/expiring-targets/{environmentKey} | Update expiring targets for segment
*SegmentsApi* | [**PatchExpiringUserTargetsForSegment**](docs/SegmentsApi.md#patchexpiringusertargetsforsegment) | **PATCH** /api/v2/segments/{projectKey}/{segmentKey}/expiring-user-targets/{environmentKey} | Update expiring user targets for segment
*SegmentsApi* | [**PatchSegment**](docs/SegmentsApi.md#patchsegment) | **PATCH** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey} | Patch segment
*SegmentsApi* | [**PostSegment**](docs/SegmentsApi.md#postsegment) | **POST** /api/v2/segments/{projectKey}/{environmentKey} | Create segment
*SegmentsApi* | [**UpdateBigSegmentContextTargets**](docs/SegmentsApi.md#updatebigsegmentcontexttargets) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/contexts | Update context targets on a big segment
*SegmentsApi* | [**UpdateBigSegmentTargets**](docs/SegmentsApi.md#updatebigsegmenttargets) | **POST** /api/v2/segments/{projectKey}/{environmentKey}/{segmentKey}/users | Update user context targets on a big segment
*TagsApi* | [**GetTags**](docs/TagsApi.md#gettags) | **GET** /api/v2/tags | List tags
*TeamsApi* | [**DeleteTeam**](docs/TeamsApi.md#deleteteam) | **DELETE** /api/v2/teams/{teamKey} | Delete team
*TeamsApi* | [**GetTeam**](docs/TeamsApi.md#getteam) | **GET** /api/v2/teams/{teamKey} | Get team
*TeamsApi* | [**GetTeamMaintainers**](docs/TeamsApi.md#getteammaintainers) | **GET** /api/v2/teams/{teamKey}/maintainers | Get team maintainers
*TeamsApi* | [**GetTeamRoles**](docs/TeamsApi.md#getteamroles) | **GET** /api/v2/teams/{teamKey}/roles | Get team custom roles
*TeamsApi* | [**GetTeams**](docs/TeamsApi.md#getteams) | **GET** /api/v2/teams | List teams
*TeamsApi* | [**PatchTeam**](docs/TeamsApi.md#patchteam) | **PATCH** /api/v2/teams/{teamKey} | Update team
*TeamsApi* | [**PostTeam**](docs/TeamsApi.md#postteam) | **POST** /api/v2/teams | Create team
*TeamsApi* | [**PostTeamMembers**](docs/TeamsApi.md#postteammembers) | **POST** /api/v2/teams/{teamKey}/members | Add multiple members to team
*TeamsBetaApi* | [**PatchTeams**](docs/TeamsBetaApi.md#patchteams) | **PATCH** /api/v2/teams | Update teams
*UserSettingsApi* | [**GetExpiringFlagsForUser**](docs/UserSettingsApi.md#getexpiringflagsforuser) | **GET** /api/v2/users/{projectKey}/{userKey}/expiring-user-targets/{environmentKey} | Get expiring dates on flags for user
*UserSettingsApi* | [**GetUserFlagSetting**](docs/UserSettingsApi.md#getuserflagsetting) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags/{featureFlagKey} | Get flag setting for user
*UserSettingsApi* | [**GetUserFlagSettings**](docs/UserSettingsApi.md#getuserflagsettings) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags | List flag settings for user
*UserSettingsApi* | [**PatchExpiringFlagsForUser**](docs/UserSettingsApi.md#patchexpiringflagsforuser) | **PATCH** /api/v2/users/{projectKey}/{userKey}/expiring-user-targets/{environmentKey} | Update expiring user target for flags
*UserSettingsApi* | [**PutFlagSetting**](docs/UserSettingsApi.md#putflagsetting) | **PUT** /api/v2/users/{projectKey}/{environmentKey}/{userKey}/flags/{featureFlagKey} | Update flag settings for user
*UsersApi* | [**DeleteUser**](docs/UsersApi.md#deleteuser) | **DELETE** /api/v2/users/{projectKey}/{environmentKey}/{userKey} | Delete user
*UsersApi* | [**GetSearchUsers**](docs/UsersApi.md#getsearchusers) | **GET** /api/v2/user-search/{projectKey}/{environmentKey} | Find users
*UsersApi* | [**GetUser**](docs/UsersApi.md#getuser) | **GET** /api/v2/users/{projectKey}/{environmentKey}/{userKey} | Get user
*UsersApi* | [**GetUsers**](docs/UsersApi.md#getusers) | **GET** /api/v2/users/{projectKey}/{environmentKey} | List users
*UsersBetaApi* | [**GetUserAttributeNames**](docs/UsersBetaApi.md#getuserattributenames) | **GET** /api/v2/user-attributes/{projectKey}/{environmentKey} | Get user attribute names
*WebhooksApi* | [**DeleteWebhook**](docs/WebhooksApi.md#deletewebhook) | **DELETE** /api/v2/webhooks/{id} | Delete webhook
*WebhooksApi* | [**GetAllWebhooks**](docs/WebhooksApi.md#getallwebhooks) | **GET** /api/v2/webhooks | List webhooks
*WebhooksApi* | [**GetWebhook**](docs/WebhooksApi.md#getwebhook) | **GET** /api/v2/webhooks/{id} | Get webhook
*WebhooksApi* | [**PatchWebhook**](docs/WebhooksApi.md#patchwebhook) | **PATCH** /api/v2/webhooks/{id} | Update webhook
*WebhooksApi* | [**PostWebhook**](docs/WebhooksApi.md#postwebhook) | **POST** /api/v2/webhooks | Creates a webhook
*WorkflowTemplatesApi* | [**CreateWorkflowTemplate**](docs/WorkflowTemplatesApi.md#createworkflowtemplate) | **POST** /api/v2/templates | Create workflow template
*WorkflowTemplatesApi* | [**DeleteWorkflowTemplate**](docs/WorkflowTemplatesApi.md#deleteworkflowtemplate) | **DELETE** /api/v2/templates/{templateKey} | Delete workflow template
*WorkflowTemplatesApi* | [**GetWorkflowTemplates**](docs/WorkflowTemplatesApi.md#getworkflowtemplates) | **GET** /api/v2/templates | Get workflow templates
*WorkflowsApi* | [**DeleteWorkflow**](docs/WorkflowsApi.md#deleteworkflow) | **DELETE** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows/{workflowId} | Delete workflow
*WorkflowsApi* | [**GetCustomWorkflow**](docs/WorkflowsApi.md#getcustomworkflow) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows/{workflowId} | Get custom workflow
*WorkflowsApi* | [**GetWorkflows**](docs/WorkflowsApi.md#getworkflows) | **GET** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows | Get workflows
*WorkflowsApi* | [**PostWorkflow**](docs/WorkflowsApi.md#postworkflow) | **POST** /api/v2/projects/{projectKey}/flags/{featureFlagKey}/environments/{environmentKey}/workflows | Create workflow


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.AIConfig](docs/AIConfig.md)
 - [Model.AIConfigPatch](docs/AIConfigPatch.md)
 - [Model.AIConfigPost](docs/AIConfigPost.md)
 - [Model.AIConfigVariation](docs/AIConfigVariation.md)
 - [Model.AIConfigVariationPatch](docs/AIConfigVariationPatch.md)
 - [Model.AIConfigVariationPost](docs/AIConfigVariationPost.md)
 - [Model.AIConfigVariationsResponse](docs/AIConfigVariationsResponse.md)
 - [Model.AIConfigs](docs/AIConfigs.md)
 - [Model.Access](docs/Access.md)
 - [Model.AccessAllowedReason](docs/AccessAllowedReason.md)
 - [Model.AccessAllowedRep](docs/AccessAllowedRep.md)
 - [Model.AccessDenied](docs/AccessDenied.md)
 - [Model.AccessDeniedReason](docs/AccessDeniedReason.md)
 - [Model.AccessTokenPost](docs/AccessTokenPost.md)
 - [Model.ActionInput](docs/ActionInput.md)
 - [Model.ActionOutput](docs/ActionOutput.md)
 - [Model.AiConfigsAccess](docs/AiConfigsAccess.md)
 - [Model.AiConfigsAccessAllowedReason](docs/AiConfigsAccessAllowedReason.md)
 - [Model.AiConfigsAccessAllowedRep](docs/AiConfigsAccessAllowedRep.md)
 - [Model.AiConfigsAccessDenied](docs/AiConfigsAccessDenied.md)
 - [Model.AiConfigsAccessDeniedReason](docs/AiConfigsAccessDeniedReason.md)
 - [Model.AiConfigsLink](docs/AiConfigsLink.md)
 - [Model.ApplicationCollectionRep](docs/ApplicationCollectionRep.md)
 - [Model.ApplicationFlagCollectionRep](docs/ApplicationFlagCollectionRep.md)
 - [Model.ApplicationRep](docs/ApplicationRep.md)
 - [Model.ApplicationVersionRep](docs/ApplicationVersionRep.md)
 - [Model.ApplicationVersionsCollectionRep](docs/ApplicationVersionsCollectionRep.md)
 - [Model.ApprovalRequestResponse](docs/ApprovalRequestResponse.md)
 - [Model.ApprovalSettings](docs/ApprovalSettings.md)
 - [Model.ApprovalsCapabilityConfig](docs/ApprovalsCapabilityConfig.md)
 - [Model.AssignedToRep](docs/AssignedToRep.md)
 - [Model.Audience](docs/Audience.md)
 - [Model.AudienceConfiguration](docs/AudienceConfiguration.md)
 - [Model.AudiencePost](docs/AudiencePost.md)
 - [Model.AuditLogEntryListingRep](docs/AuditLogEntryListingRep.md)
 - [Model.AuditLogEntryListingRepCollection](docs/AuditLogEntryListingRepCollection.md)
 - [Model.AuditLogEntryRep](docs/AuditLogEntryRep.md)
 - [Model.AuditLogEventsHookCapabilityConfigPost](docs/AuditLogEventsHookCapabilityConfigPost.md)
 - [Model.AuditLogEventsHookCapabilityConfigRep](docs/AuditLogEventsHookCapabilityConfigRep.md)
 - [Model.AuthorizedAppDataRep](docs/AuthorizedAppDataRep.md)
 - [Model.BayesianBetaBinomialStatsRep](docs/BayesianBetaBinomialStatsRep.md)
 - [Model.BayesianNormalStatsRep](docs/BayesianNormalStatsRep.md)
 - [Model.BigSegmentStoreIntegration](docs/BigSegmentStoreIntegration.md)
 - [Model.BigSegmentStoreIntegrationCollection](docs/BigSegmentStoreIntegrationCollection.md)
 - [Model.BigSegmentStoreIntegrationCollectionLinks](docs/BigSegmentStoreIntegrationCollectionLinks.md)
 - [Model.BigSegmentStoreIntegrationLinks](docs/BigSegmentStoreIntegrationLinks.md)
 - [Model.BigSegmentStoreStatus](docs/BigSegmentStoreStatus.md)
 - [Model.BigSegmentTarget](docs/BigSegmentTarget.md)
 - [Model.BooleanDefaults](docs/BooleanDefaults.md)
 - [Model.BooleanFlagDefaults](docs/BooleanFlagDefaults.md)
 - [Model.BranchCollectionRep](docs/BranchCollectionRep.md)
 - [Model.BranchRep](docs/BranchRep.md)
 - [Model.BulkEditMembersRep](docs/BulkEditMembersRep.md)
 - [Model.BulkEditTeamsRep](docs/BulkEditTeamsRep.md)
 - [Model.CallerIdentityRep](docs/CallerIdentityRep.md)
 - [Model.CapabilityConfigPost](docs/CapabilityConfigPost.md)
 - [Model.CapabilityConfigRep](docs/CapabilityConfigRep.md)
 - [Model.Clause](docs/Clause.md)
 - [Model.ClientCollection](docs/ClientCollection.md)
 - [Model.ClientSideAvailability](docs/ClientSideAvailability.md)
 - [Model.ClientSideAvailabilityPost](docs/ClientSideAvailabilityPost.md)
 - [Model.CompletedBy](docs/CompletedBy.md)
 - [Model.ConditionInput](docs/ConditionInput.md)
 - [Model.ConditionOutput](docs/ConditionOutput.md)
 - [Model.Conflict](docs/Conflict.md)
 - [Model.ConflictOutput](docs/ConflictOutput.md)
 - [Model.ContextAttributeName](docs/ContextAttributeName.md)
 - [Model.ContextAttributeNames](docs/ContextAttributeNames.md)
 - [Model.ContextAttributeNamesCollection](docs/ContextAttributeNamesCollection.md)
 - [Model.ContextAttributeValue](docs/ContextAttributeValue.md)
 - [Model.ContextAttributeValues](docs/ContextAttributeValues.md)
 - [Model.ContextAttributeValuesCollection](docs/ContextAttributeValuesCollection.md)
 - [Model.ContextInstanceEvaluation](docs/ContextInstanceEvaluation.md)
 - [Model.ContextInstanceEvaluationReason](docs/ContextInstanceEvaluationReason.md)
 - [Model.ContextInstanceEvaluations](docs/ContextInstanceEvaluations.md)
 - [Model.ContextInstanceRecord](docs/ContextInstanceRecord.md)
 - [Model.ContextInstanceSearch](docs/ContextInstanceSearch.md)
 - [Model.ContextInstanceSegmentMembership](docs/ContextInstanceSegmentMembership.md)
 - [Model.ContextInstanceSegmentMemberships](docs/ContextInstanceSegmentMemberships.md)
 - [Model.ContextInstances](docs/ContextInstances.md)
 - [Model.ContextKindRep](docs/ContextKindRep.md)
 - [Model.ContextKindsCollectionRep](docs/ContextKindsCollectionRep.md)
 - [Model.ContextRecord](docs/ContextRecord.md)
 - [Model.ContextSearch](docs/ContextSearch.md)
 - [Model.Contexts](docs/Contexts.md)
 - [Model.CopiedFromEnv](docs/CopiedFromEnv.md)
 - [Model.CoreLink](docs/CoreLink.md)
 - [Model.CreateApprovalRequestRequest](docs/CreateApprovalRequestRequest.md)
 - [Model.CreateCopyFlagConfigApprovalRequestRequest](docs/CreateCopyFlagConfigApprovalRequestRequest.md)
 - [Model.CreateFlagConfigApprovalRequestRequest](docs/CreateFlagConfigApprovalRequestRequest.md)
 - [Model.CreatePhaseInput](docs/CreatePhaseInput.md)
 - [Model.CreateReleaseInput](docs/CreateReleaseInput.md)
 - [Model.CreateReleasePipelineInput](docs/CreateReleasePipelineInput.md)
 - [Model.CreateWorkflowTemplateInput](docs/CreateWorkflowTemplateInput.md)
 - [Model.CredibleIntervalRep](docs/CredibleIntervalRep.md)
 - [Model.CustomProperty](docs/CustomProperty.md)
 - [Model.CustomRole](docs/CustomRole.md)
 - [Model.CustomRolePost](docs/CustomRolePost.md)
 - [Model.CustomRoles](docs/CustomRoles.md)
 - [Model.CustomWorkflowInput](docs/CustomWorkflowInput.md)
 - [Model.CustomWorkflowMeta](docs/CustomWorkflowMeta.md)
 - [Model.CustomWorkflowOutput](docs/CustomWorkflowOutput.md)
 - [Model.CustomWorkflowStageMeta](docs/CustomWorkflowStageMeta.md)
 - [Model.CustomWorkflowsListingOutput](docs/CustomWorkflowsListingOutput.md)
 - [Model.DefaultClientSideAvailability](docs/DefaultClientSideAvailability.md)
 - [Model.DefaultClientSideAvailabilityPost](docs/DefaultClientSideAvailabilityPost.md)
 - [Model.Defaults](docs/Defaults.md)
 - [Model.DependentExperimentRep](docs/DependentExperimentRep.md)
 - [Model.DependentFlag](docs/DependentFlag.md)
 - [Model.DependentFlagEnvironment](docs/DependentFlagEnvironment.md)
 - [Model.DependentFlagsByEnvironment](docs/DependentFlagsByEnvironment.md)
 - [Model.DependentMetricGroupRep](docs/DependentMetricGroupRep.md)
 - [Model.DependentMetricGroupRepWithMetrics](docs/DependentMetricGroupRepWithMetrics.md)
 - [Model.DependentMetricOrMetricGroupRep](docs/DependentMetricOrMetricGroupRep.md)
 - [Model.DeploymentCollectionRep](docs/DeploymentCollectionRep.md)
 - [Model.DeploymentRep](docs/DeploymentRep.md)
 - [Model.Destination](docs/Destination.md)
 - [Model.DestinationPost](docs/DestinationPost.md)
 - [Model.Destinations](docs/Destinations.md)
 - [Model.Distribution](docs/Distribution.md)
 - [Model.DynamicOptions](docs/DynamicOptions.md)
 - [Model.DynamicOptionsParser](docs/DynamicOptionsParser.md)
 - [Model.Endpoint](docs/Endpoint.md)
 - [Model.EnvironmentPost](docs/EnvironmentPost.md)
 - [Model.EnvironmentSummary](docs/EnvironmentSummary.md)
 - [Model.Environments](docs/Environments.md)
 - [Model.Error](docs/Error.md)
 - [Model.EvaluationReason](docs/EvaluationReason.md)
 - [Model.EvaluationsSummary](docs/EvaluationsSummary.md)
 - [Model.ExecutionOutput](docs/ExecutionOutput.md)
 - [Model.ExpandableApprovalRequestResponse](docs/ExpandableApprovalRequestResponse.md)
 - [Model.ExpandableApprovalRequestsResponse](docs/ExpandableApprovalRequestsResponse.md)
 - [Model.ExpandedFlagRep](docs/ExpandedFlagRep.md)
 - [Model.ExpandedResourceRep](docs/ExpandedResourceRep.md)
 - [Model.Experiment](docs/Experiment.md)
 - [Model.ExperimentAllocationRep](docs/ExperimentAllocationRep.md)
 - [Model.ExperimentBayesianResultsRep](docs/ExperimentBayesianResultsRep.md)
 - [Model.ExperimentCollectionRep](docs/ExperimentCollectionRep.md)
 - [Model.ExperimentEnabledPeriodRep](docs/ExperimentEnabledPeriodRep.md)
 - [Model.ExperimentEnvironmentSettingRep](docs/ExperimentEnvironmentSettingRep.md)
 - [Model.ExperimentInfoRep](docs/ExperimentInfoRep.md)
 - [Model.ExperimentPatchInput](docs/ExperimentPatchInput.md)
 - [Model.ExperimentPost](docs/ExperimentPost.md)
 - [Model.ExpiringTarget](docs/ExpiringTarget.md)
 - [Model.ExpiringTargetError](docs/ExpiringTargetError.md)
 - [Model.ExpiringTargetGetResponse](docs/ExpiringTargetGetResponse.md)
 - [Model.ExpiringTargetPatchResponse](docs/ExpiringTargetPatchResponse.md)
 - [Model.ExpiringUserTargetGetResponse](docs/ExpiringUserTargetGetResponse.md)
 - [Model.ExpiringUserTargetItem](docs/ExpiringUserTargetItem.md)
 - [Model.ExpiringUserTargetPatchResponse](docs/ExpiringUserTargetPatchResponse.md)
 - [Model.Export](docs/Export.md)
 - [Model.Extinction](docs/Extinction.md)
 - [Model.ExtinctionCollectionRep](docs/ExtinctionCollectionRep.md)
 - [Model.FailureReasonRep](docs/FailureReasonRep.md)
 - [Model.FeatureFlag](docs/FeatureFlag.md)
 - [Model.FeatureFlagBody](docs/FeatureFlagBody.md)
 - [Model.FeatureFlagConfig](docs/FeatureFlagConfig.md)
 - [Model.FeatureFlagScheduledChange](docs/FeatureFlagScheduledChange.md)
 - [Model.FeatureFlagScheduledChanges](docs/FeatureFlagScheduledChanges.md)
 - [Model.FeatureFlagStatus](docs/FeatureFlagStatus.md)
 - [Model.FeatureFlagStatusAcrossEnvironments](docs/FeatureFlagStatusAcrossEnvironments.md)
 - [Model.FeatureFlagStatuses](docs/FeatureFlagStatuses.md)
 - [Model.FeatureFlags](docs/FeatureFlags.md)
 - [Model.FileRep](docs/FileRep.md)
 - [Model.FlagConfigApprovalRequestResponse](docs/FlagConfigApprovalRequestResponse.md)
 - [Model.FlagConfigApprovalRequestsResponse](docs/FlagConfigApprovalRequestsResponse.md)
 - [Model.FlagConfigEvaluation](docs/FlagConfigEvaluation.md)
 - [Model.FlagConfigMigrationSettingsRep](docs/FlagConfigMigrationSettingsRep.md)
 - [Model.FlagCopyConfigEnvironment](docs/FlagCopyConfigEnvironment.md)
 - [Model.FlagCopyConfigPost](docs/FlagCopyConfigPost.md)
 - [Model.FlagDefaultsRep](docs/FlagDefaultsRep.md)
 - [Model.FlagEventCollectionRep](docs/FlagEventCollectionRep.md)
 - [Model.FlagEventExperiment](docs/FlagEventExperiment.md)
 - [Model.FlagEventExperimentCollection](docs/FlagEventExperimentCollection.md)
 - [Model.FlagEventExperimentIteration](docs/FlagEventExperimentIteration.md)
 - [Model.FlagEventImpactRep](docs/FlagEventImpactRep.md)
 - [Model.FlagEventMemberRep](docs/FlagEventMemberRep.md)
 - [Model.FlagEventRep](docs/FlagEventRep.md)
 - [Model.FlagFollowersByProjEnvGetRep](docs/FlagFollowersByProjEnvGetRep.md)
 - [Model.FlagFollowersGetRep](docs/FlagFollowersGetRep.md)
 - [Model.FlagImportConfigurationPost](docs/FlagImportConfigurationPost.md)
 - [Model.FlagImportIntegration](docs/FlagImportIntegration.md)
 - [Model.FlagImportIntegrationCollection](docs/FlagImportIntegrationCollection.md)
 - [Model.FlagImportIntegrationCollectionLinks](docs/FlagImportIntegrationCollectionLinks.md)
 - [Model.FlagImportIntegrationLinks](docs/FlagImportIntegrationLinks.md)
 - [Model.FlagImportStatus](docs/FlagImportStatus.md)
 - [Model.FlagInput](docs/FlagInput.md)
 - [Model.FlagLinkCollectionRep](docs/FlagLinkCollectionRep.md)
 - [Model.FlagLinkMember](docs/FlagLinkMember.md)
 - [Model.FlagLinkPost](docs/FlagLinkPost.md)
 - [Model.FlagLinkRep](docs/FlagLinkRep.md)
 - [Model.FlagListingRep](docs/FlagListingRep.md)
 - [Model.FlagMigrationSettingsRep](docs/FlagMigrationSettingsRep.md)
 - [Model.FlagPrerequisitePost](docs/FlagPrerequisitePost.md)
 - [Model.FlagReferenceCollectionRep](docs/FlagReferenceCollectionRep.md)
 - [Model.FlagReferenceRep](docs/FlagReferenceRep.md)
 - [Model.FlagRep](docs/FlagRep.md)
 - [Model.FlagScheduledChangesInput](docs/FlagScheduledChangesInput.md)
 - [Model.FlagSempatch](docs/FlagSempatch.md)
 - [Model.FlagStatusRep](docs/FlagStatusRep.md)
 - [Model.FlagSummary](docs/FlagSummary.md)
 - [Model.FlagTriggerInput](docs/FlagTriggerInput.md)
 - [Model.FollowFlagMember](docs/FollowFlagMember.md)
 - [Model.FollowersPerFlag](docs/FollowersPerFlag.md)
 - [Model.ForbiddenErrorRep](docs/ForbiddenErrorRep.md)
 - [Model.FormVariable](docs/FormVariable.md)
 - [Model.HMACSignature](docs/HMACSignature.md)
 - [Model.HeaderItems](docs/HeaderItems.md)
 - [Model.HoldoutDetailRep](docs/HoldoutDetailRep.md)
 - [Model.HoldoutPatchInput](docs/HoldoutPatchInput.md)
 - [Model.HoldoutPostRequest](docs/HoldoutPostRequest.md)
 - [Model.HoldoutRep](docs/HoldoutRep.md)
 - [Model.HoldoutsCollectionRep](docs/HoldoutsCollectionRep.md)
 - [Model.HunkRep](docs/HunkRep.md)
 - [Model.Import](docs/Import.md)
 - [Model.InitiatorRep](docs/InitiatorRep.md)
 - [Model.InsightGroup](docs/InsightGroup.md)
 - [Model.InsightGroupCollection](docs/InsightGroupCollection.md)
 - [Model.InsightGroupCollectionMetadata](docs/InsightGroupCollectionMetadata.md)
 - [Model.InsightGroupCollectionScoreMetadata](docs/InsightGroupCollectionScoreMetadata.md)
 - [Model.InsightGroupScores](docs/InsightGroupScores.md)
 - [Model.InsightGroupsCountByIndicator](docs/InsightGroupsCountByIndicator.md)
 - [Model.InsightPeriod](docs/InsightPeriod.md)
 - [Model.InsightScores](docs/InsightScores.md)
 - [Model.InsightsChart](docs/InsightsChart.md)
 - [Model.InsightsChartBounds](docs/InsightsChartBounds.md)
 - [Model.InsightsChartMetadata](docs/InsightsChartMetadata.md)
 - [Model.InsightsChartMetric](docs/InsightsChartMetric.md)
 - [Model.InsightsChartSeries](docs/InsightsChartSeries.md)
 - [Model.InsightsChartSeriesDataPoint](docs/InsightsChartSeriesDataPoint.md)
 - [Model.InsightsChartSeriesMetadata](docs/InsightsChartSeriesMetadata.md)
 - [Model.InsightsChartSeriesMetadataAxis](docs/InsightsChartSeriesMetadataAxis.md)
 - [Model.InsightsMetricIndicatorRange](docs/InsightsMetricIndicatorRange.md)
 - [Model.InsightsMetricScore](docs/InsightsMetricScore.md)
 - [Model.InsightsMetricTierDefinition](docs/InsightsMetricTierDefinition.md)
 - [Model.InsightsRepository](docs/InsightsRepository.md)
 - [Model.InsightsRepositoryCollection](docs/InsightsRepositoryCollection.md)
 - [Model.InsightsRepositoryProject](docs/InsightsRepositoryProject.md)
 - [Model.InsightsRepositoryProjectCollection](docs/InsightsRepositoryProjectCollection.md)
 - [Model.InsightsRepositoryProjectMappings](docs/InsightsRepositoryProjectMappings.md)
 - [Model.InstructionUserRequest](docs/InstructionUserRequest.md)
 - [Model.Integration](docs/Integration.md)
 - [Model.IntegrationConfigurationCollectionRep](docs/IntegrationConfigurationCollectionRep.md)
 - [Model.IntegrationConfigurationPost](docs/IntegrationConfigurationPost.md)
 - [Model.IntegrationConfigurationsRep](docs/IntegrationConfigurationsRep.md)
 - [Model.IntegrationDeliveryConfiguration](docs/IntegrationDeliveryConfiguration.md)
 - [Model.IntegrationDeliveryConfigurationCollection](docs/IntegrationDeliveryConfigurationCollection.md)
 - [Model.IntegrationDeliveryConfigurationCollectionLinks](docs/IntegrationDeliveryConfigurationCollectionLinks.md)
 - [Model.IntegrationDeliveryConfigurationLinks](docs/IntegrationDeliveryConfigurationLinks.md)
 - [Model.IntegrationDeliveryConfigurationPost](docs/IntegrationDeliveryConfigurationPost.md)
 - [Model.IntegrationDeliveryConfigurationResponse](docs/IntegrationDeliveryConfigurationResponse.md)
 - [Model.IntegrationMetadata](docs/IntegrationMetadata.md)
 - [Model.IntegrationStatus](docs/IntegrationStatus.md)
 - [Model.IntegrationStatusRep](docs/IntegrationStatusRep.md)
 - [Model.IntegrationSubscriptionStatusRep](docs/IntegrationSubscriptionStatusRep.md)
 - [Model.Integrations](docs/Integrations.md)
 - [Model.InvalidRequestErrorRep](docs/InvalidRequestErrorRep.md)
 - [Model.IpList](docs/IpList.md)
 - [Model.IterationInput](docs/IterationInput.md)
 - [Model.IterationRep](docs/IterationRep.md)
 - [Model.LastSeenMetadata](docs/LastSeenMetadata.md)
 - [Model.LayerCollectionRep](docs/LayerCollectionRep.md)
 - [Model.LayerConfigurationRep](docs/LayerConfigurationRep.md)
 - [Model.LayerPatchInput](docs/LayerPatchInput.md)
 - [Model.LayerPost](docs/LayerPost.md)
 - [Model.LayerRep](docs/LayerRep.md)
 - [Model.LayerReservationRep](docs/LayerReservationRep.md)
 - [Model.LayerSnapshotRep](docs/LayerSnapshotRep.md)
 - [Model.LeadTimeStagesRep](docs/LeadTimeStagesRep.md)
 - [Model.LegacyExperimentRep](docs/LegacyExperimentRep.md)
 - [Model.Link](docs/Link.md)
 - [Model.MaintainerRep](docs/MaintainerRep.md)
 - [Model.MaintainerTeam](docs/MaintainerTeam.md)
 - [Model.Member](docs/Member.md)
 - [Model.MemberDataRep](docs/MemberDataRep.md)
 - [Model.MemberImportItem](docs/MemberImportItem.md)
 - [Model.MemberPermissionGrantSummaryRep](docs/MemberPermissionGrantSummaryRep.md)
 - [Model.MemberSummary](docs/MemberSummary.md)
 - [Model.MemberTeamSummaryRep](docs/MemberTeamSummaryRep.md)
 - [Model.MemberTeamsPostInput](docs/MemberTeamsPostInput.md)
 - [Model.Members](docs/Members.md)
 - [Model.MembersPatchInput](docs/MembersPatchInput.md)
 - [Model.Message](docs/Message.md)
 - [Model.MethodNotAllowedErrorRep](docs/MethodNotAllowedErrorRep.md)
 - [Model.MetricByVariation](docs/MetricByVariation.md)
 - [Model.MetricCollectionRep](docs/MetricCollectionRep.md)
 - [Model.MetricEventDefaultRep](docs/MetricEventDefaultRep.md)
 - [Model.MetricGroupCollectionRep](docs/MetricGroupCollectionRep.md)
 - [Model.MetricGroupPost](docs/MetricGroupPost.md)
 - [Model.MetricGroupRep](docs/MetricGroupRep.md)
 - [Model.MetricGroupResultsRep](docs/MetricGroupResultsRep.md)
 - [Model.MetricInGroupRep](docs/MetricInGroupRep.md)
 - [Model.MetricInGroupResultsRep](docs/MetricInGroupResultsRep.md)
 - [Model.MetricInMetricGroupInput](docs/MetricInMetricGroupInput.md)
 - [Model.MetricInput](docs/MetricInput.md)
 - [Model.MetricListingRep](docs/MetricListingRep.md)
 - [Model.MetricPost](docs/MetricPost.md)
 - [Model.MetricRep](docs/MetricRep.md)
 - [Model.MetricSeen](docs/MetricSeen.md)
 - [Model.MetricV2Rep](docs/MetricV2Rep.md)
 - [Model.Metrics](docs/Metrics.md)
 - [Model.MigrationSafetyIssueRep](docs/MigrationSafetyIssueRep.md)
 - [Model.MigrationSettingsPost](docs/MigrationSettingsPost.md)
 - [Model.ModelClient](docs/ModelClient.md)
 - [Model.ModelConfig](docs/ModelConfig.md)
 - [Model.ModelConfigPost](docs/ModelConfigPost.md)
 - [Model.ModelEnvironment](docs/ModelEnvironment.md)
 - [Model.Modification](docs/Modification.md)
 - [Model.MultiEnvironmentDependentFlag](docs/MultiEnvironmentDependentFlag.md)
 - [Model.MultiEnvironmentDependentFlags](docs/MultiEnvironmentDependentFlags.md)
 - [Model.NamingConvention](docs/NamingConvention.md)
 - [Model.NewMemberForm](docs/NewMemberForm.md)
 - [Model.NotFoundErrorRep](docs/NotFoundErrorRep.md)
 - [Model.OauthClientPost](docs/OauthClientPost.md)
 - [Model.OptionsArray](docs/OptionsArray.md)
 - [Model.PaginatedLinks](docs/PaginatedLinks.md)
 - [Model.ParameterDefault](docs/ParameterDefault.md)
 - [Model.ParameterRep](docs/ParameterRep.md)
 - [Model.ParentAndSelfLinks](docs/ParentAndSelfLinks.md)
 - [Model.ParentLink](docs/ParentLink.md)
 - [Model.ParentResourceRep](docs/ParentResourceRep.md)
 - [Model.PatchFailedErrorRep](docs/PatchFailedErrorRep.md)
 - [Model.PatchFlagsRequest](docs/PatchFlagsRequest.md)
 - [Model.PatchOperation](docs/PatchOperation.md)
 - [Model.PatchSegmentExpiringTargetInputRep](docs/PatchSegmentExpiringTargetInputRep.md)
 - [Model.PatchSegmentExpiringTargetInstruction](docs/PatchSegmentExpiringTargetInstruction.md)
 - [Model.PatchSegmentInstruction](docs/PatchSegmentInstruction.md)
 - [Model.PatchSegmentRequest](docs/PatchSegmentRequest.md)
 - [Model.PatchUsersRequest](docs/PatchUsersRequest.md)
 - [Model.PatchWithComment](docs/PatchWithComment.md)
 - [Model.PermissionGrantInput](docs/PermissionGrantInput.md)
 - [Model.Phase](docs/Phase.md)
 - [Model.PhaseInfo](docs/PhaseInfo.md)
 - [Model.PostApprovalRequestApplyRequest](docs/PostApprovalRequestApplyRequest.md)
 - [Model.PostApprovalRequestReviewRequest](docs/PostApprovalRequestReviewRequest.md)
 - [Model.PostDeploymentEventInput](docs/PostDeploymentEventInput.md)
 - [Model.PostFlagScheduledChangesInput](docs/PostFlagScheduledChangesInput.md)
 - [Model.PostInsightGroupParams](docs/PostInsightGroupParams.md)
 - [Model.Prerequisite](docs/Prerequisite.md)
 - [Model.Project](docs/Project.md)
 - [Model.ProjectPost](docs/ProjectPost.md)
 - [Model.ProjectRep](docs/ProjectRep.md)
 - [Model.ProjectSummary](docs/ProjectSummary.md)
 - [Model.ProjectSummaryCollection](docs/ProjectSummaryCollection.md)
 - [Model.Projects](docs/Projects.md)
 - [Model.PullRequestCollectionRep](docs/PullRequestCollectionRep.md)
 - [Model.PullRequestLeadTimeRep](docs/PullRequestLeadTimeRep.md)
 - [Model.PullRequestRep](docs/PullRequestRep.md)
 - [Model.PutBranch](docs/PutBranch.md)
 - [Model.RandomizationSettingsPut](docs/RandomizationSettingsPut.md)
 - [Model.RandomizationSettingsRep](docs/RandomizationSettingsRep.md)
 - [Model.RandomizationUnitInput](docs/RandomizationUnitInput.md)
 - [Model.RandomizationUnitRep](docs/RandomizationUnitRep.md)
 - [Model.RateLimitedErrorRep](docs/RateLimitedErrorRep.md)
 - [Model.RecentTriggerBody](docs/RecentTriggerBody.md)
 - [Model.ReferenceRep](docs/ReferenceRep.md)
 - [Model.RelatedExperimentRep](docs/RelatedExperimentRep.md)
 - [Model.RelativeDifferenceRep](docs/RelativeDifferenceRep.md)
 - [Model.RelayAutoConfigCollectionRep](docs/RelayAutoConfigCollectionRep.md)
 - [Model.RelayAutoConfigPost](docs/RelayAutoConfigPost.md)
 - [Model.RelayAutoConfigRep](docs/RelayAutoConfigRep.md)
 - [Model.Release](docs/Release.md)
 - [Model.ReleaseAudience](docs/ReleaseAudience.md)
 - [Model.ReleaseGuardianConfiguration](docs/ReleaseGuardianConfiguration.md)
 - [Model.ReleaseGuardianConfigurationInput](docs/ReleaseGuardianConfigurationInput.md)
 - [Model.ReleasePhase](docs/ReleasePhase.md)
 - [Model.ReleasePipeline](docs/ReleasePipeline.md)
 - [Model.ReleasePipelineCollection](docs/ReleasePipelineCollection.md)
 - [Model.ReleaseProgression](docs/ReleaseProgression.md)
 - [Model.ReleaseProgressionCollection](docs/ReleaseProgressionCollection.md)
 - [Model.ReleaserAudienceConfigInput](docs/ReleaserAudienceConfigInput.md)
 - [Model.RepositoryCollectionRep](docs/RepositoryCollectionRep.md)
 - [Model.RepositoryPost](docs/RepositoryPost.md)
 - [Model.RepositoryRep](docs/RepositoryRep.md)
 - [Model.ResourceAccess](docs/ResourceAccess.md)
 - [Model.ResourceIDResponse](docs/ResourceIDResponse.md)
 - [Model.ResourceId](docs/ResourceId.md)
 - [Model.ReviewOutput](docs/ReviewOutput.md)
 - [Model.ReviewResponse](docs/ReviewResponse.md)
 - [Model.Rollout](docs/Rollout.md)
 - [Model.RootResponse](docs/RootResponse.md)
 - [Model.Rule](docs/Rule.md)
 - [Model.RuleClause](docs/RuleClause.md)
 - [Model.SdkListRep](docs/SdkListRep.md)
 - [Model.SdkVersionListRep](docs/SdkVersionListRep.md)
 - [Model.SdkVersionRep](docs/SdkVersionRep.md)
 - [Model.SegmentBody](docs/SegmentBody.md)
 - [Model.SegmentMetadata](docs/SegmentMetadata.md)
 - [Model.SegmentTarget](docs/SegmentTarget.md)
 - [Model.SegmentUserList](docs/SegmentUserList.md)
 - [Model.SegmentUserState](docs/SegmentUserState.md)
 - [Model.Series](docs/Series.md)
 - [Model.SeriesIntervalsRep](docs/SeriesIntervalsRep.md)
 - [Model.SeriesListRep](docs/SeriesListRep.md)
 - [Model.SimpleHoldoutRep](docs/SimpleHoldoutRep.md)
 - [Model.SlicedResultsRep](docs/SlicedResultsRep.md)
 - [Model.SourceEnv](docs/SourceEnv.md)
 - [Model.SourceFlag](docs/SourceFlag.md)
 - [Model.StageInput](docs/StageInput.md)
 - [Model.StageOutput](docs/StageOutput.md)
 - [Model.Statement](docs/Statement.md)
 - [Model.StatementPost](docs/StatementPost.md)
 - [Model.StatisticCollectionRep](docs/StatisticCollectionRep.md)
 - [Model.StatisticRep](docs/StatisticRep.md)
 - [Model.StatisticsRoot](docs/StatisticsRoot.md)
 - [Model.StatusConflictErrorRep](docs/StatusConflictErrorRep.md)
 - [Model.StatusResponse](docs/StatusResponse.md)
 - [Model.StatusServiceUnavailable](docs/StatusServiceUnavailable.md)
 - [Model.StoreIntegrationError](docs/StoreIntegrationError.md)
 - [Model.SubjectDataRep](docs/SubjectDataRep.md)
 - [Model.SubscriptionPost](docs/SubscriptionPost.md)
 - [Model.TagsCollection](docs/TagsCollection.md)
 - [Model.TagsLink](docs/TagsLink.md)
 - [Model.Target](docs/Target.md)
 - [Model.TargetResourceRep](docs/TargetResourceRep.md)
 - [Model.Team](docs/Team.md)
 - [Model.TeamCustomRole](docs/TeamCustomRole.md)
 - [Model.TeamCustomRoles](docs/TeamCustomRoles.md)
 - [Model.TeamImportsRep](docs/TeamImportsRep.md)
 - [Model.TeamMaintainers](docs/TeamMaintainers.md)
 - [Model.TeamMembers](docs/TeamMembers.md)
 - [Model.TeamPatchInput](docs/TeamPatchInput.md)
 - [Model.TeamPostInput](docs/TeamPostInput.md)
 - [Model.TeamProjects](docs/TeamProjects.md)
 - [Model.Teams](docs/Teams.md)
 - [Model.TeamsPatchInput](docs/TeamsPatchInput.md)
 - [Model.TimestampRep](docs/TimestampRep.md)
 - [Model.Token](docs/Token.md)
 - [Model.TokenSummary](docs/TokenSummary.md)
 - [Model.Tokens](docs/Tokens.md)
 - [Model.TreatmentInput](docs/TreatmentInput.md)
 - [Model.TreatmentParameterInput](docs/TreatmentParameterInput.md)
 - [Model.TreatmentRep](docs/TreatmentRep.md)
 - [Model.TreatmentResultRep](docs/TreatmentResultRep.md)
 - [Model.TriggerPost](docs/TriggerPost.md)
 - [Model.TriggerWorkflowCollectionRep](docs/TriggerWorkflowCollectionRep.md)
 - [Model.TriggerWorkflowRep](docs/TriggerWorkflowRep.md)
 - [Model.UnauthorizedErrorRep](docs/UnauthorizedErrorRep.md)
 - [Model.UpdatePhaseStatusInput](docs/UpdatePhaseStatusInput.md)
 - [Model.UpdateReleasePipelineInput](docs/UpdateReleasePipelineInput.md)
 - [Model.UpsertContextKindPayload](docs/UpsertContextKindPayload.md)
 - [Model.UpsertFlagDefaultsPayload](docs/UpsertFlagDefaultsPayload.md)
 - [Model.UpsertPayloadRep](docs/UpsertPayloadRep.md)
 - [Model.UpsertResponseRep](docs/UpsertResponseRep.md)
 - [Model.UrlPost](docs/UrlPost.md)
 - [Model.User](docs/User.md)
 - [Model.UserAttributeNamesRep](docs/UserAttributeNamesRep.md)
 - [Model.UserFlagSetting](docs/UserFlagSetting.md)
 - [Model.UserFlagSettings](docs/UserFlagSettings.md)
 - [Model.UserRecord](docs/UserRecord.md)
 - [Model.UserSegment](docs/UserSegment.md)
 - [Model.UserSegmentRule](docs/UserSegmentRule.md)
 - [Model.UserSegments](docs/UserSegments.md)
 - [Model.Users](docs/Users.md)
 - [Model.UsersRep](docs/UsersRep.md)
 - [Model.ValidationFailedErrorRep](docs/ValidationFailedErrorRep.md)
 - [Model.ValuePut](docs/ValuePut.md)
 - [Model.Variation](docs/Variation.md)
 - [Model.VariationEvalSummary](docs/VariationEvalSummary.md)
 - [Model.VariationOrRolloutRep](docs/VariationOrRolloutRep.md)
 - [Model.VariationSummary](docs/VariationSummary.md)
 - [Model.VersionsRep](docs/VersionsRep.md)
 - [Model.Webhook](docs/Webhook.md)
 - [Model.WebhookPost](docs/WebhookPost.md)
 - [Model.Webhooks](docs/Webhooks.md)
 - [Model.WeightedVariation](docs/WeightedVariation.md)
 - [Model.WorkflowTemplateMetadata](docs/WorkflowTemplateMetadata.md)
 - [Model.WorkflowTemplateOutput](docs/WorkflowTemplateOutput.md)
 - [Model.WorkflowTemplateParameter](docs/WorkflowTemplateParameter.md)
 - [Model.WorkflowTemplatesListingOutputRep](docs/WorkflowTemplatesListingOutputRep.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization


Authentication schemes defined for the API:
<a id="ApiKey"></a>
### ApiKey

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

