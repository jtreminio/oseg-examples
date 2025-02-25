/*
 * LaunchDarkly REST API
 * # Overview  ## Authentication  LaunchDarkly's REST API uses the HTTPS protocol with a minimum TLS version of 1.2.  All REST API resources are authenticated with either [personal or service access tokens](https://docs.launchdarkly.com/home/account/api), or session cookies. Other authentication mechanisms are not supported. You can manage personal access tokens on your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page in the LaunchDarkly UI.  LaunchDarkly also has SDK keys, mobile keys, and client-side IDs that are used by our server-side SDKs, mobile SDKs, and JavaScript-based SDKs, respectively. **These keys cannot be used to access our REST API**. These keys are environment-specific, and can only perform read-only operations such as fetching feature flag settings.  | Auth mechanism                                                                                  | Allowed resources                                                                                     | Use cases                                          | | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------- | -------------------------------------------------- | | [Personal or service access tokens](https://docs.launchdarkly.com/home/account/api) | Can be customized on a per-token basis                                                                | Building scripts, custom integrations, data export. | | SDK keys                                                                                        | Can only access read-only resources specific to server-side SDKs. Restricted to a single environment. | Server-side SDKs                     | | Mobile keys                                                                                     | Can only access read-only resources specific to mobile SDKs, and only for flags marked available to mobile keys. Restricted to a single environment.           | Mobile SDKs                                        | | Client-side ID                                                                                  | Can only access read-only resources specific to JavaScript-based client-side SDKs, and only for flags marked available to client-side. Restricted to a single environment.           | Client-side JavaScript                             |  > #### Keep your access tokens and SDK keys private > > Access tokens should _never_ be exposed in untrusted contexts. Never put an access token in client-side JavaScript, or embed it in a mobile application. LaunchDarkly has special mobile keys that you can embed in mobile apps. If you accidentally expose an access token or SDK key, you can reset it from your [**Authorization**](https://app.launchdarkly.com/settings/authorization) page. > > The client-side ID is safe to embed in untrusted contexts. It's designed for use in client-side JavaScript.  ### Authentication using request header  The preferred way to authenticate with the API is by adding an `Authorization` header containing your access token to your requests. The value of the `Authorization` header must be your access token.  Manage personal access tokens from the [**Authorization**](https://app.launchdarkly.com/settings/authorization) page.  ### Authentication using session cookie  For testing purposes, you can make API calls directly from your web browser. If you are logged in to the LaunchDarkly application, the API will use your existing session to authenticate calls.  If you have a [role](https://docs.launchdarkly.com/home/account/built-in-roles) other than Admin, or have a [custom role](https://docs.launchdarkly.com/home/account/custom-roles) defined, you may not have permission to perform some API calls. You will receive a `401` response code in that case.  > ### Modifying the Origin header causes an error > > LaunchDarkly validates that the Origin header for any API request authenticated by a session cookie matches the expected Origin header. The expected Origin header is `https://app.launchdarkly.com`. > > If the Origin header does not match what's expected, LaunchDarkly returns an error. This error can prevent the LaunchDarkly app from working correctly. > > Any browser extension that intentionally changes the Origin header can cause this problem. For example, the `Allow-Control-Allow-Origin: *` Chrome extension changes the Origin header to `http://evil.com` and causes the app to fail. > > To prevent this error, do not modify your Origin header. > > LaunchDarkly does not require origin matching when authenticating with an access token, so this issue does not affect normal API usage.  ## Representations  All resources expect and return JSON response bodies. Error responses also send a JSON body. To learn more about the error format of the API, read [Errors](/#section/Overview/Errors).  In practice this means that you always get a response with a `Content-Type` header set to `application/json`.  In addition, request bodies for `PATCH`, `POST`, and `PUT` requests must be encoded as JSON with a `Content-Type` header set to `application/json`.  ### Summary and detailed representations  When you fetch a list of resources, the response includes only the most important attributes of each resource. This is a _summary representation_ of the resource. When you fetch an individual resource, such as a single feature flag, you receive a _detailed representation_ of the resource.  The best way to find a detailed representation is to follow links. Every summary representation includes a link to its detailed representation.  ### Expanding responses  Sometimes the detailed representation of a resource does not include all of the attributes of the resource by default. If this is the case, the request method will clearly document this and describe which attributes you can include in an expanded response.  To include the additional attributes, append the `expand` request parameter to your request and add a comma-separated list of the attributes to include. For example, when you append `?expand=members,maintainers` to the [Get team](/tag/Teams#operation/getTeam) endpoint, the expanded response includes both of these attributes.  ### Links and addressability  The best way to navigate the API is by following links. These are attributes in representations that link to other resources. The API always uses the same format for links:  - Links to other resources within the API are encapsulated in a `_links` object - If the resource has a corresponding link to HTML content on the site, it is stored in a special `_site` link  Each link has two attributes:  - An `href`, which contains the URL - A `type`, which describes the content type  For example, a feature resource might return the following:  ```json {   \"_links\": {     \"parent\": {       \"href\": \"/api/features\",       \"type\": \"application/json\"     },     \"self\": {       \"href\": \"/api/features/sort.order\",       \"type\": \"application/json\"     }   },   \"_site\": {     \"href\": \"/features/sort.order\",     \"type\": \"text/html\"   } } ```  From this, you can navigate to the parent collection of features by following the `parent` link, or navigate to the site page for the feature by following the `_site` link.  Collections are always represented as a JSON object with an `items` attribute containing an array of representations. Like all other representations, collections have `_links` defined at the top level.  Paginated collections include `first`, `last`, `next`, and `prev` links containing a URL with the respective set of elements in the collection.  ## Updates  Resources that accept partial updates use the `PATCH` verb. Most resources support the [JSON patch](/reference#updates-using-json-patch) format. Some resources also support the [JSON merge patch](/reference#updates-using-json-merge-patch) format, and some resources support the [semantic patch](/reference#updates-using-semantic-patch) format, which is a way to specify the modifications to perform as a set of executable instructions. Each resource supports optional [comments](/reference#updates-with-comments) that you can submit with updates. Comments appear in outgoing webhooks, the audit log, and other integrations.  When a resource supports both JSON patch and semantic patch, we document both in the request method. However, the specific request body fields and descriptions included in our documentation only match one type of patch or the other.  ### Updates using JSON patch  [JSON patch](https://datatracker.ietf.org/doc/html/rfc6902) is a way to specify the modifications to perform on a resource. JSON patch uses paths and a limited set of operations to describe how to transform the current state of the resource into a new state. JSON patch documents are always arrays, where each element contains an operation, a path to the field to update, and the new value.  For example, in this feature flag representation:  ```json {     \"name\": \"New recommendations engine\",     \"key\": \"engine.enable\",     \"description\": \"This is the description\",     ... } ``` You can change the feature flag's description with the following patch document:  ```json [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"This is the new description\" }] ```  You can specify multiple modifications to perform in a single request. You can also test that certain preconditions are met before applying the patch:  ```json [   { \"op\": \"test\", \"path\": \"/version\", \"value\": 10 },   { \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" } ] ```  The above patch request tests whether the feature flag's `version` is `10`, and if so, changes the feature flag's description.  Attributes that are not editable, such as a resource's `_links`, have names that start with an underscore.  ### Updates using JSON merge patch  [JSON merge patch](https://datatracker.ietf.org/doc/html/rfc7386) is another format for specifying the modifications to perform on a resource. JSON merge patch is less expressive than JSON patch. However, in many cases it is simpler to construct a merge patch document. For example, you can change a feature flag's description with the following merge patch document:  ```json {   \"description\": \"New flag description\" } ```  ### Updates using semantic patch  Some resources support the semantic patch format. A semantic patch is a way to specify the modifications to perform on a resource as a set of executable instructions.  Semantic patch allows you to be explicit about intent using precise, custom instructions. In many cases, you can define semantic patch instructions independently of the current state of the resource. This can be useful when defining a change that may be applied at a future date.  To make a semantic patch request, you must append `domain-model=launchdarkly.semanticpatch` to your `Content-Type` header.  Here's how:  ``` Content-Type: application/json; domain-model=launchdarkly.semanticpatch ```  If you call a semantic patch resource without this header, you will receive a `400` response because your semantic patch will be interpreted as a JSON patch.  The body of a semantic patch request takes the following properties:  * `comment` (string): (Optional) A description of the update. * `environmentKey` (string): (Required for some resources only) The environment key. * `instructions` (array): (Required) A list of actions the update should perform. Each action in the list must be an object with a `kind` property that indicates the instruction. If the instruction requires parameters, you must include those parameters as additional fields in the object. The documentation for each resource that supports semantic patch includes the available instructions and any additional parameters.  For example:  ```json {   \"comment\": \"optional comment\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  Semantic patches are not applied partially; either all of the instructions are applied or none of them are. If **any** instruction is invalid, the endpoint returns an error and will not change the resource. If all instructions are valid, the request succeeds and the resources are updated if necessary, or left unchanged if they are already in the state you request.  ### Updates with comments  You can submit optional comments with `PATCH` changes.  To submit a comment along with a JSON patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"patch\": [{ \"op\": \"replace\", \"path\": \"/description\", \"value\": \"The new description\" }] } ```  To submit a comment along with a JSON merge patch document, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"merge\": { \"description\": \"New flag description\" } } ```  To submit a comment along with a semantic patch, use the following format:  ```json {   \"comment\": \"This is a comment string\",   \"instructions\": [ {\"kind\": \"turnFlagOn\"} ] } ```  ## Errors  The API always returns errors in a common format. Here's an example:  ```json {   \"code\": \"invalid_request\",   \"message\": \"A feature with that key already exists\",   \"id\": \"30ce6058-87da-11e4-b116-123b93f75cba\" } ```  The `code` indicates the general class of error. The `message` is a human-readable explanation of what went wrong. The `id` is a unique identifier. Use it when you're working with LaunchDarkly Support to debug a problem with a specific API call.  ### HTTP status error response codes  | Code | Definition        | Description                                                                                       | Possible Solution                                                | | ---- | ----------------- | ------------------------------------------------------------------------------------------- | ---------------------------------------------------------------- | | 400  | Invalid request       | The request cannot be understood.                                    | Ensure JSON syntax in request body is correct.                   | | 401  | Invalid access token      | Requestor is unauthorized or does not have permission for this API call.                                                | Ensure your API access token is valid and has the appropriate permissions.                                     | | 403  | Forbidden         | Requestor does not have access to this resource.                                                | Ensure that the account member or access token has proper permissions set. | | 404  | Invalid resource identifier | The requested resource is not valid. | Ensure that the resource is correctly identified by ID or key. | | 405  | Method not allowed | The request method is not allowed on this resource. | Ensure that the HTTP verb is correct. | | 409  | Conflict          | The API request can not be completed because it conflicts with a concurrent API request. | Retry your request.                                              | | 422  | Unprocessable entity | The API request can not be completed because the update description can not be understood. | Ensure that the request body is correct for the type of patch you are using, either JSON patch or semantic patch. | 429  | Too many requests | Read [Rate limiting](/#section/Overview/Rate-limiting).                                               | Wait and try again later.                                        |  ## CORS  The LaunchDarkly API supports Cross Origin Resource Sharing (CORS) for AJAX requests from any origin. If an `Origin` header is given in a request, it will be echoed as an explicitly allowed origin. Otherwise the request returns a wildcard, `Access-Control-Allow-Origin: *`. For more information on CORS, read the [CORS W3C Recommendation](http://www.w3.org/TR/cors). Example CORS headers might look like:  ```http Access-Control-Allow-Headers: Accept, Content-Type, Content-Length, Accept-Encoding, Authorization Access-Control-Allow-Methods: OPTIONS, GET, DELETE, PATCH Access-Control-Allow-Origin: * Access-Control-Max-Age: 300 ```  You can make authenticated CORS calls just as you would make same-origin calls, using either [token or session-based authentication](/#section/Overview/Authentication). If you are using session authentication, you should set the `withCredentials` property for your `xhr` request to `true`. You should never expose your access tokens to untrusted entities.  ## Rate limiting  We use several rate limiting strategies to ensure the availability of our APIs. Rate-limited calls to our APIs return a `429` status code. Calls to our APIs include headers indicating the current rate limit status. The specific headers returned depend on the API route being called. The limits differ based on the route, authentication mechanism, and other factors. Routes that are not rate limited may not contain any of the headers described below.  > ### Rate limiting and SDKs > > LaunchDarkly SDKs are never rate limited and do not use the API endpoints defined here. LaunchDarkly uses a different set of approaches, including streaming/server-sent events and a global CDN, to ensure availability to the routes used by LaunchDarkly SDKs.  ### Global rate limits  Authenticated requests are subject to a global limit. This is the maximum number of calls that your account can make to the API per ten seconds. All service and personal access tokens on the account share this limit, so exceeding the limit with one access token will impact other tokens. Calls that are subject to global rate limits may return the headers below:  | Header name                    | Description                                                                      | | ------------------------------ | -------------------------------------------------------------------------------- | | `X-Ratelimit-Global-Remaining` | The maximum number of requests the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`            | The time at which the current rate limit window resets in epoch milliseconds.    |  We do not publicly document the specific number of calls that can be made globally. This limit may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limit.  ### Route-level rate limits  Some authenticated routes have custom rate limits. These also reset every ten seconds. Any service or personal access tokens hitting the same route share this limit, so exceeding the limit with one access token may impact other tokens. Calls that are subject to route-level rate limits return the headers below:  | Header name                   | Description                                                                                           | | ----------------------------- | ----------------------------------------------------------------------------------------------------- | | `X-Ratelimit-Route-Remaining` | The maximum number of requests to the current route the account is permitted to make per ten seconds. | | `X-Ratelimit-Reset`           | The time at which the current rate limit window resets in epoch milliseconds.                         |  A _route_ represents a specific URL pattern and verb. For example, the [Delete environment](/tag/Environments#operation/deleteEnvironment) endpoint is considered a single route, and each call to delete an environment counts against your route-level rate limit for that route.  We do not publicly document the specific number of calls that an account can make to each endpoint per ten seconds. These limits may change, and we encourage clients to program against the specification, relying on the two headers defined above, rather than hardcoding to the current limits.  ### IP-based rate limiting  We also employ IP-based rate limiting on some API routes. If you hit an IP-based rate limit, your API response will include a `Retry-After` header indicating how long to wait before re-trying the call. Clients must wait at least `Retry-After` seconds before making additional calls to our API, and should employ jitter and backoff strategies to avoid triggering rate limits again.  ## OpenAPI (Swagger) and client libraries  We have a [complete OpenAPI (Swagger) specification](https://app.launchdarkly.com/api/v2/openapi.json) for our API.  We auto-generate multiple client libraries based on our OpenAPI specification. To learn more, visit the [collection of client libraries on GitHub](https://github.com/search?q=topic%3Alaunchdarkly-api+org%3Alaunchdarkly&type=Repositories). You can also use this specification to generate client libraries to interact with our REST API in your language of choice.  Our OpenAPI specification is supported by several API-based tools such as Postman and Insomnia. In many cases, you can directly import our specification to explore our APIs.  ## Method overriding  Some firewalls and HTTP clients restrict the use of verbs other than `GET` and `POST`. In those environments, our API endpoints that use `DELETE`, `PATCH`, and `PUT` verbs are inaccessible.  To avoid this issue, our API supports the `X-HTTP-Method-Override` header, allowing clients to \"tunnel\" `DELETE`, `PATCH`, and `PUT` requests using a `POST` request.  For example, to call a `PATCH` endpoint using a `POST` request, you can include `X-HTTP-Method-Override:PATCH` as a header.  ## Beta resources  We sometimes release new API resources in **beta** status before we release them with general availability.  Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  We try to promote resources into general availability as quickly as possible. This happens after sufficient testing and when we're satisfied that we no longer need to make backwards-incompatible changes.  We mark beta resources with a \"Beta\" callout in our documentation, pictured below:  > ### This feature is in beta > > To use this feature, pass in a header including the `LD-API-Version` key with value set to `beta`. Use this header with each call. To learn more, read [Beta resources](/#section/Overview/Beta-resources). > > Resources that are in beta are still undergoing testing and development. They may change without notice, including becoming backwards incompatible.  ### Using beta resources  To use a beta resource, you must include a header in the request. If you call a beta resource without this header, you receive a `403` response.  Use this header:  ``` LD-API-Version: beta ```  ## Federal environments  The version of LaunchDarkly that is available on domains controlled by the United States government is different from the version of LaunchDarkly available to the general public. If you are an employee or contractor for a United States federal agency and use LaunchDarkly in your work, you likely use the federal instance of LaunchDarkly.  If you are working in the federal instance of LaunchDarkly, the base URI for each request is `https://app.launchdarkly.us`. In the \"Try it\" sandbox for each request, click the request path to view the complete resource path for the federal environment.  To learn more, read [LaunchDarkly in federal environments](https://docs.launchdarkly.com/home/infrastructure/federal).  ## Versioning  We try hard to keep our REST API backwards compatible, but we occasionally have to make backwards-incompatible changes in the process of shipping new features. These breaking changes can cause unexpected behavior if you don't prepare for them accordingly.  Updates to our REST API include support for the latest features in LaunchDarkly. We also release a new version of our REST API every time we make a breaking change. We provide simultaneous support for multiple API versions so you can migrate from your current API version to a new version at your own pace.  ### Setting the API version per request  You can set the API version on a specific request by sending an `LD-API-Version` header, as shown in the example below:  ``` LD-API-Version: 20240415 ```  The header value is the version number of the API version you would like to request. The number for each version corresponds to the date the version was released in `yyyymmdd` format. In the example above the version `20240415` corresponds to April 15, 2024.  ### Setting the API version per access token  When you create an access token, you must specify a specific version of the API to use. This ensures that integrations using this token cannot be broken by version changes.  Tokens created before versioning was released have their version set to `20160426`, which is the version of the API that existed before the current versioning scheme, so that they continue working the same way they did before versioning.  If you would like to upgrade your integration to use a new API version, you can explicitly set the header described above.  > ### Best practice: Set the header for every client or integration > > We recommend that you set the API version header explicitly in any client or integration you build. > > Only rely on the access token API version during manual testing.  ### API version changelog  |<div style=\"width:75px\">Version</div> | Changes | End of life (EOL) |---|---|---| | `20240415` | <ul><li>Changed several endpoints from unpaginated to paginated. Use the `limit` and `offset` query parameters to page through the results.</li> <li>Changed the [list access tokens](/tag/Access-tokens#operation/getTokens) endpoint: <ul><li>Response is now paginated with a default limit of `25`</li></ul></li> <li>Changed the [list account members](/tag/Account-members#operation/getMembers) endpoint: <ul><li>The `accessCheck` filter is no longer available</li></ul></li> <li>Changed the [list custom roles](/tag/Custom-roles#operation/getCustomRoles) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list feature flags](/tag/Feature-flags#operation/getFeatureFlags) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `environments` field is now only returned if the request is filtered by environment, using the `filterEnv` query parameter</li><li>The `filterEnv` query parameter supports a maximum of three environments</li><li>The `followerId`, `hasDataExport`, `status`, `contextKindTargeted`, and `segmentTargeted` filters are no longer available</li></ul></li> <li>Changed the [list segments](/tag/Segments#operation/getSegments) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li></ul></li> <li>Changed the [list teams](/tag/Teams#operation/getTeams) endpoint: <ul><li>The `expand` parameter no longer supports including `projects` or `roles`</li><li>In paginated results, the maximum page size is now 100</li></ul></li> <li>Changed the [get workflows](/tag/Workflows#operation/getWorkflows) endpoint: <ul><li>Response is now paginated with a default limit of `20`</li><li>The `_conflicts` field in the response is no longer available</li></ul></li> </ul>  | Current | | `20220603` | <ul><li>Changed the [list projects](/tag/Projects#operation/getProjects) return value:<ul><li>Response is now paginated with a default limit of `20`.</li><li>Added support for filter and sort.</li><li>The project `environments` field is now expandable. This field is omitted by default.</li></ul></li><li>Changed the [get project](/tag/Projects#operation/getProject) return value:<ul><li>The `environments` field is now expandable. This field is omitted by default.</li></ul></li></ul> | 2025-04-15 | | `20210729` | <ul><li>Changed the [create approval request](/tag/Approvals#operation/postApprovalRequest) return value. It now returns HTTP Status Code `201` instead of `200`.</li><li> Changed the [get users](/tag/Users#operation/getUser) return value. It now returns a user record, not a user. </li><li>Added additional optional fields to environment, segments, flags, members, and segments, including the ability to create big segments. </li><li> Added default values for flag variations when new environments are created. </li><li>Added filtering and pagination for getting flags and members, including `limit`, `number`, `filter`, and `sort` query parameters. </li><li>Added endpoints for expiring user targets for flags and segments, scheduled changes, access tokens, Relay Proxy configuration, integrations and subscriptions, and approvals. </li></ul> | 2023-06-03 | | `20191212` | <ul><li>[List feature flags](/tag/Feature-flags#operation/getFeatureFlags) now defaults to sending summaries of feature flag configurations, equivalent to setting the query parameter `summary=true`. Summaries omit flag targeting rules and individual user targets from the payload. </li><li> Added endpoints for flags, flag status, projects, environments, audit logs, members, users, custom roles, segments, usage, streams, events, and data export. </li></ul> | 2022-07-29 | | `20160426` | <ul><li>Initial versioning of API. Tokens created before versioning have their version set to this.</li></ul> | 2020-12-12 |  To learn more about how EOL is determined, read LaunchDarkly's [End of Life (EOL) Policy](https://launchdarkly.com/policies/end-of-life-policy/). 
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@launchdarkly.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package com.launchdarkly.client.model;

import java.util.Objects;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import com.launchdarkly.client.model.DependentMetricGroupRepWithMetrics;
import com.launchdarkly.client.model.DependentMetricOrMetricGroupRep;
import com.launchdarkly.client.model.FlagRep;
import com.launchdarkly.client.model.LayerSnapshotRep;
import com.launchdarkly.client.model.MetricV2Rep;
import com.launchdarkly.client.model.TreatmentRep;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.launchdarkly.client.JSON;

/**
 * IterationRep
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class IterationRep {
  public static final String SERIALIZED_NAME_ID = "_id";
  @SerializedName(SERIALIZED_NAME_ID)
  @javax.annotation.Nullable
  private String id;

  public static final String SERIALIZED_NAME_HYPOTHESIS = "hypothesis";
  @SerializedName(SERIALIZED_NAME_HYPOTHESIS)
  @javax.annotation.Nonnull
  private String hypothesis;

  public static final String SERIALIZED_NAME_STATUS = "status";
  @SerializedName(SERIALIZED_NAME_STATUS)
  @javax.annotation.Nonnull
  private String status;

  public static final String SERIALIZED_NAME_CREATED_AT = "createdAt";
  @SerializedName(SERIALIZED_NAME_CREATED_AT)
  @javax.annotation.Nonnull
  private Long createdAt;

  public static final String SERIALIZED_NAME_STARTED_AT = "startedAt";
  @SerializedName(SERIALIZED_NAME_STARTED_AT)
  @javax.annotation.Nullable
  private Long startedAt;

  public static final String SERIALIZED_NAME_ENDED_AT = "endedAt";
  @SerializedName(SERIALIZED_NAME_ENDED_AT)
  @javax.annotation.Nullable
  private Long endedAt;

  public static final String SERIALIZED_NAME_WINNING_TREATMENT_ID = "winningTreatmentId";
  @SerializedName(SERIALIZED_NAME_WINNING_TREATMENT_ID)
  @javax.annotation.Nullable
  private String winningTreatmentId;

  public static final String SERIALIZED_NAME_WINNING_REASON = "winningReason";
  @SerializedName(SERIALIZED_NAME_WINNING_REASON)
  @javax.annotation.Nullable
  private String winningReason;

  public static final String SERIALIZED_NAME_CAN_RESHUFFLE_TRAFFIC = "canReshuffleTraffic";
  @SerializedName(SERIALIZED_NAME_CAN_RESHUFFLE_TRAFFIC)
  @javax.annotation.Nullable
  private Boolean canReshuffleTraffic;

  public static final String SERIALIZED_NAME_FLAGS = "flags";
  @SerializedName(SERIALIZED_NAME_FLAGS)
  @javax.annotation.Nullable
  private Map<String, FlagRep> flags = new HashMap<>();

  public static final String SERIALIZED_NAME_PRIMARY_METRIC = "primaryMetric";
  @SerializedName(SERIALIZED_NAME_PRIMARY_METRIC)
  @javax.annotation.Nullable
  private DependentMetricOrMetricGroupRep primaryMetric;

  public static final String SERIALIZED_NAME_PRIMARY_SINGLE_METRIC = "primarySingleMetric";
  @SerializedName(SERIALIZED_NAME_PRIMARY_SINGLE_METRIC)
  @javax.annotation.Nullable
  private MetricV2Rep primarySingleMetric;

  public static final String SERIALIZED_NAME_PRIMARY_FUNNEL = "primaryFunnel";
  @SerializedName(SERIALIZED_NAME_PRIMARY_FUNNEL)
  @javax.annotation.Nullable
  private DependentMetricGroupRepWithMetrics primaryFunnel;

  public static final String SERIALIZED_NAME_RANDOMIZATION_UNIT = "randomizationUnit";
  @SerializedName(SERIALIZED_NAME_RANDOMIZATION_UNIT)
  @javax.annotation.Nullable
  private String randomizationUnit;

  public static final String SERIALIZED_NAME_ATTRIBUTES = "attributes";
  @SerializedName(SERIALIZED_NAME_ATTRIBUTES)
  @javax.annotation.Nullable
  private List<String> attributes = new ArrayList<>();

  public static final String SERIALIZED_NAME_TREATMENTS = "treatments";
  @SerializedName(SERIALIZED_NAME_TREATMENTS)
  @javax.annotation.Nullable
  private List<TreatmentRep> treatments = new ArrayList<>();

  public static final String SERIALIZED_NAME_SECONDARY_METRICS = "secondaryMetrics";
  @Deprecated
  @SerializedName(SERIALIZED_NAME_SECONDARY_METRICS)
  @javax.annotation.Nullable
  private List<MetricV2Rep> secondaryMetrics = new ArrayList<>();

  public static final String SERIALIZED_NAME_METRICS = "metrics";
  @SerializedName(SERIALIZED_NAME_METRICS)
  @javax.annotation.Nullable
  private List<DependentMetricOrMetricGroupRep> metrics = new ArrayList<>();

  public static final String SERIALIZED_NAME_LAYER_SNAPSHOT = "layerSnapshot";
  @SerializedName(SERIALIZED_NAME_LAYER_SNAPSHOT)
  @javax.annotation.Nullable
  private LayerSnapshotRep layerSnapshot;

  public IterationRep() {
  }

  public IterationRep id(@javax.annotation.Nullable String id) {
    this.id = id;
    return this;
  }

  /**
   * The iteration ID
   * @return id
   */
  @javax.annotation.Nullable
  public String getId() {
    return id;
  }

  public void setId(@javax.annotation.Nullable String id) {
    this.id = id;
  }


  public IterationRep hypothesis(@javax.annotation.Nonnull String hypothesis) {
    this.hypothesis = hypothesis;
    return this;
  }

  /**
   * The expected outcome of this experiment
   * @return hypothesis
   */
  @javax.annotation.Nonnull
  public String getHypothesis() {
    return hypothesis;
  }

  public void setHypothesis(@javax.annotation.Nonnull String hypothesis) {
    this.hypothesis = hypothesis;
  }


  public IterationRep status(@javax.annotation.Nonnull String status) {
    this.status = status;
    return this;
  }

  /**
   * The status of the iteration: &lt;code&gt;not_started&lt;/code&gt;, &lt;code&gt;running&lt;/code&gt;, &lt;code&gt;stopped&lt;/code&gt;
   * @return status
   */
  @javax.annotation.Nonnull
  public String getStatus() {
    return status;
  }

  public void setStatus(@javax.annotation.Nonnull String status) {
    this.status = status;
  }


  public IterationRep createdAt(@javax.annotation.Nonnull Long createdAt) {
    this.createdAt = createdAt;
    return this;
  }

  /**
   * Get createdAt
   * @return createdAt
   */
  @javax.annotation.Nonnull
  public Long getCreatedAt() {
    return createdAt;
  }

  public void setCreatedAt(@javax.annotation.Nonnull Long createdAt) {
    this.createdAt = createdAt;
  }


  public IterationRep startedAt(@javax.annotation.Nullable Long startedAt) {
    this.startedAt = startedAt;
    return this;
  }

  /**
   * Get startedAt
   * @return startedAt
   */
  @javax.annotation.Nullable
  public Long getStartedAt() {
    return startedAt;
  }

  public void setStartedAt(@javax.annotation.Nullable Long startedAt) {
    this.startedAt = startedAt;
  }


  public IterationRep endedAt(@javax.annotation.Nullable Long endedAt) {
    this.endedAt = endedAt;
    return this;
  }

  /**
   * Get endedAt
   * @return endedAt
   */
  @javax.annotation.Nullable
  public Long getEndedAt() {
    return endedAt;
  }

  public void setEndedAt(@javax.annotation.Nullable Long endedAt) {
    this.endedAt = endedAt;
  }


  public IterationRep winningTreatmentId(@javax.annotation.Nullable String winningTreatmentId) {
    this.winningTreatmentId = winningTreatmentId;
    return this;
  }

  /**
   * The ID of the treatment chosen when the experiment stopped
   * @return winningTreatmentId
   */
  @javax.annotation.Nullable
  public String getWinningTreatmentId() {
    return winningTreatmentId;
  }

  public void setWinningTreatmentId(@javax.annotation.Nullable String winningTreatmentId) {
    this.winningTreatmentId = winningTreatmentId;
  }


  public IterationRep winningReason(@javax.annotation.Nullable String winningReason) {
    this.winningReason = winningReason;
    return this;
  }

  /**
   * The reason you stopped the experiment
   * @return winningReason
   */
  @javax.annotation.Nullable
  public String getWinningReason() {
    return winningReason;
  }

  public void setWinningReason(@javax.annotation.Nullable String winningReason) {
    this.winningReason = winningReason;
  }


  public IterationRep canReshuffleTraffic(@javax.annotation.Nullable Boolean canReshuffleTraffic) {
    this.canReshuffleTraffic = canReshuffleTraffic;
    return this;
  }

  /**
   * Whether the experiment may reassign traffic to different variations when the experiment audience changes (true) or must keep all traffic assigned to its initial variation (false).
   * @return canReshuffleTraffic
   */
  @javax.annotation.Nullable
  public Boolean getCanReshuffleTraffic() {
    return canReshuffleTraffic;
  }

  public void setCanReshuffleTraffic(@javax.annotation.Nullable Boolean canReshuffleTraffic) {
    this.canReshuffleTraffic = canReshuffleTraffic;
  }


  public IterationRep flags(@javax.annotation.Nullable Map<String, FlagRep> flags) {
    this.flags = flags;
    return this;
  }

  public IterationRep putFlagsItem(String key, FlagRep flagsItem) {
    if (this.flags == null) {
      this.flags = new HashMap<>();
    }
    this.flags.put(key, flagsItem);
    return this;
  }

  /**
   * Details on the flag used in this experiment
   * @return flags
   */
  @javax.annotation.Nullable
  public Map<String, FlagRep> getFlags() {
    return flags;
  }

  public void setFlags(@javax.annotation.Nullable Map<String, FlagRep> flags) {
    this.flags = flags;
  }


  public IterationRep primaryMetric(@javax.annotation.Nullable DependentMetricOrMetricGroupRep primaryMetric) {
    this.primaryMetric = primaryMetric;
    return this;
  }

  /**
   * Get primaryMetric
   * @return primaryMetric
   */
  @javax.annotation.Nullable
  public DependentMetricOrMetricGroupRep getPrimaryMetric() {
    return primaryMetric;
  }

  public void setPrimaryMetric(@javax.annotation.Nullable DependentMetricOrMetricGroupRep primaryMetric) {
    this.primaryMetric = primaryMetric;
  }


  public IterationRep primarySingleMetric(@javax.annotation.Nullable MetricV2Rep primarySingleMetric) {
    this.primarySingleMetric = primarySingleMetric;
    return this;
  }

  /**
   * Get primarySingleMetric
   * @return primarySingleMetric
   */
  @javax.annotation.Nullable
  public MetricV2Rep getPrimarySingleMetric() {
    return primarySingleMetric;
  }

  public void setPrimarySingleMetric(@javax.annotation.Nullable MetricV2Rep primarySingleMetric) {
    this.primarySingleMetric = primarySingleMetric;
  }


  public IterationRep primaryFunnel(@javax.annotation.Nullable DependentMetricGroupRepWithMetrics primaryFunnel) {
    this.primaryFunnel = primaryFunnel;
    return this;
  }

  /**
   * Get primaryFunnel
   * @return primaryFunnel
   */
  @javax.annotation.Nullable
  public DependentMetricGroupRepWithMetrics getPrimaryFunnel() {
    return primaryFunnel;
  }

  public void setPrimaryFunnel(@javax.annotation.Nullable DependentMetricGroupRepWithMetrics primaryFunnel) {
    this.primaryFunnel = primaryFunnel;
  }


  public IterationRep randomizationUnit(@javax.annotation.Nullable String randomizationUnit) {
    this.randomizationUnit = randomizationUnit;
    return this;
  }

  /**
   * The unit of randomization for this iteration
   * @return randomizationUnit
   */
  @javax.annotation.Nullable
  public String getRandomizationUnit() {
    return randomizationUnit;
  }

  public void setRandomizationUnit(@javax.annotation.Nullable String randomizationUnit) {
    this.randomizationUnit = randomizationUnit;
  }


  public IterationRep attributes(@javax.annotation.Nullable List<String> attributes) {
    this.attributes = attributes;
    return this;
  }

  public IterationRep addAttributesItem(String attributesItem) {
    if (this.attributes == null) {
      this.attributes = new ArrayList<>();
    }
    this.attributes.add(attributesItem);
    return this;
  }

  /**
   * The available attribute filters for this iteration
   * @return attributes
   */
  @javax.annotation.Nullable
  public List<String> getAttributes() {
    return attributes;
  }

  public void setAttributes(@javax.annotation.Nullable List<String> attributes) {
    this.attributes = attributes;
  }


  public IterationRep treatments(@javax.annotation.Nullable List<TreatmentRep> treatments) {
    this.treatments = treatments;
    return this;
  }

  public IterationRep addTreatmentsItem(TreatmentRep treatmentsItem) {
    if (this.treatments == null) {
      this.treatments = new ArrayList<>();
    }
    this.treatments.add(treatmentsItem);
    return this;
  }

  /**
   * Details on the variations you are testing in the experiment
   * @return treatments
   */
  @javax.annotation.Nullable
  public List<TreatmentRep> getTreatments() {
    return treatments;
  }

  public void setTreatments(@javax.annotation.Nullable List<TreatmentRep> treatments) {
    this.treatments = treatments;
  }


  @Deprecated
  public IterationRep secondaryMetrics(@javax.annotation.Nullable List<MetricV2Rep> secondaryMetrics) {
    this.secondaryMetrics = secondaryMetrics;
    return this;
  }

  public IterationRep addSecondaryMetricsItem(MetricV2Rep secondaryMetricsItem) {
    if (this.secondaryMetrics == null) {
      this.secondaryMetrics = new ArrayList<>();
    }
    this.secondaryMetrics.add(secondaryMetricsItem);
    return this;
  }

  /**
   * Deprecated, use &lt;code&gt;metrics&lt;/code&gt; instead. Details on the secondary metrics for this experiment.
   * @return secondaryMetrics
   * @deprecated
   */
  @Deprecated
  @javax.annotation.Nullable
  public List<MetricV2Rep> getSecondaryMetrics() {
    return secondaryMetrics;
  }

  @Deprecated
  public void setSecondaryMetrics(@javax.annotation.Nullable List<MetricV2Rep> secondaryMetrics) {
    this.secondaryMetrics = secondaryMetrics;
  }


  public IterationRep metrics(@javax.annotation.Nullable List<DependentMetricOrMetricGroupRep> metrics) {
    this.metrics = metrics;
    return this;
  }

  public IterationRep addMetricsItem(DependentMetricOrMetricGroupRep metricsItem) {
    if (this.metrics == null) {
      this.metrics = new ArrayList<>();
    }
    this.metrics.add(metricsItem);
    return this;
  }

  /**
   * Details on the metrics for this experiment
   * @return metrics
   */
  @javax.annotation.Nullable
  public List<DependentMetricOrMetricGroupRep> getMetrics() {
    return metrics;
  }

  public void setMetrics(@javax.annotation.Nullable List<DependentMetricOrMetricGroupRep> metrics) {
    this.metrics = metrics;
  }


  public IterationRep layerSnapshot(@javax.annotation.Nullable LayerSnapshotRep layerSnapshot) {
    this.layerSnapshot = layerSnapshot;
    return this;
  }

  /**
   * Get layerSnapshot
   * @return layerSnapshot
   */
  @javax.annotation.Nullable
  public LayerSnapshotRep getLayerSnapshot() {
    return layerSnapshot;
  }

  public void setLayerSnapshot(@javax.annotation.Nullable LayerSnapshotRep layerSnapshot) {
    this.layerSnapshot = layerSnapshot;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    IterationRep iterationRep = (IterationRep) o;
    return Objects.equals(this.id, iterationRep.id) &&
        Objects.equals(this.hypothesis, iterationRep.hypothesis) &&
        Objects.equals(this.status, iterationRep.status) &&
        Objects.equals(this.createdAt, iterationRep.createdAt) &&
        Objects.equals(this.startedAt, iterationRep.startedAt) &&
        Objects.equals(this.endedAt, iterationRep.endedAt) &&
        Objects.equals(this.winningTreatmentId, iterationRep.winningTreatmentId) &&
        Objects.equals(this.winningReason, iterationRep.winningReason) &&
        Objects.equals(this.canReshuffleTraffic, iterationRep.canReshuffleTraffic) &&
        Objects.equals(this.flags, iterationRep.flags) &&
        Objects.equals(this.primaryMetric, iterationRep.primaryMetric) &&
        Objects.equals(this.primarySingleMetric, iterationRep.primarySingleMetric) &&
        Objects.equals(this.primaryFunnel, iterationRep.primaryFunnel) &&
        Objects.equals(this.randomizationUnit, iterationRep.randomizationUnit) &&
        Objects.equals(this.attributes, iterationRep.attributes) &&
        Objects.equals(this.treatments, iterationRep.treatments) &&
        Objects.equals(this.secondaryMetrics, iterationRep.secondaryMetrics) &&
        Objects.equals(this.metrics, iterationRep.metrics) &&
        Objects.equals(this.layerSnapshot, iterationRep.layerSnapshot);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, hypothesis, status, createdAt, startedAt, endedAt, winningTreatmentId, winningReason, canReshuffleTraffic, flags, primaryMetric, primarySingleMetric, primaryFunnel, randomizationUnit, attributes, treatments, secondaryMetrics, metrics, layerSnapshot);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class IterationRep {\n");
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    hypothesis: ").append(toIndentedString(hypothesis)).append("\n");
    sb.append("    status: ").append(toIndentedString(status)).append("\n");
    sb.append("    createdAt: ").append(toIndentedString(createdAt)).append("\n");
    sb.append("    startedAt: ").append(toIndentedString(startedAt)).append("\n");
    sb.append("    endedAt: ").append(toIndentedString(endedAt)).append("\n");
    sb.append("    winningTreatmentId: ").append(toIndentedString(winningTreatmentId)).append("\n");
    sb.append("    winningReason: ").append(toIndentedString(winningReason)).append("\n");
    sb.append("    canReshuffleTraffic: ").append(toIndentedString(canReshuffleTraffic)).append("\n");
    sb.append("    flags: ").append(toIndentedString(flags)).append("\n");
    sb.append("    primaryMetric: ").append(toIndentedString(primaryMetric)).append("\n");
    sb.append("    primarySingleMetric: ").append(toIndentedString(primarySingleMetric)).append("\n");
    sb.append("    primaryFunnel: ").append(toIndentedString(primaryFunnel)).append("\n");
    sb.append("    randomizationUnit: ").append(toIndentedString(randomizationUnit)).append("\n");
    sb.append("    attributes: ").append(toIndentedString(attributes)).append("\n");
    sb.append("    treatments: ").append(toIndentedString(treatments)).append("\n");
    sb.append("    secondaryMetrics: ").append(toIndentedString(secondaryMetrics)).append("\n");
    sb.append("    metrics: ").append(toIndentedString(metrics)).append("\n");
    sb.append("    layerSnapshot: ").append(toIndentedString(layerSnapshot)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("_id");
    openapiFields.add("hypothesis");
    openapiFields.add("status");
    openapiFields.add("createdAt");
    openapiFields.add("startedAt");
    openapiFields.add("endedAt");
    openapiFields.add("winningTreatmentId");
    openapiFields.add("winningReason");
    openapiFields.add("canReshuffleTraffic");
    openapiFields.add("flags");
    openapiFields.add("primaryMetric");
    openapiFields.add("primarySingleMetric");
    openapiFields.add("primaryFunnel");
    openapiFields.add("randomizationUnit");
    openapiFields.add("attributes");
    openapiFields.add("treatments");
    openapiFields.add("secondaryMetrics");
    openapiFields.add("metrics");
    openapiFields.add("layerSnapshot");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
    openapiRequiredFields.add("hypothesis");
    openapiRequiredFields.add("status");
    openapiRequiredFields.add("createdAt");
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to IterationRep
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!IterationRep.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in IterationRep is not found in the empty JSON string", IterationRep.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!IterationRep.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `IterationRep` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }

      // check to make sure all required properties/fields are present in the JSON string
      for (String requiredField : IterationRep.openapiRequiredFields) {
        if (jsonElement.getAsJsonObject().get(requiredField) == null) {
          throw new IllegalArgumentException(String.format("The required field `%s` is not found in the JSON string: %s", requiredField, jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if ((jsonObj.get("_id") != null && !jsonObj.get("_id").isJsonNull()) && !jsonObj.get("_id").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `_id` to be a primitive type in the JSON string but got `%s`", jsonObj.get("_id").toString()));
      }
      if (!jsonObj.get("hypothesis").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `hypothesis` to be a primitive type in the JSON string but got `%s`", jsonObj.get("hypothesis").toString()));
      }
      if (!jsonObj.get("status").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `status` to be a primitive type in the JSON string but got `%s`", jsonObj.get("status").toString()));
      }
      if ((jsonObj.get("winningTreatmentId") != null && !jsonObj.get("winningTreatmentId").isJsonNull()) && !jsonObj.get("winningTreatmentId").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `winningTreatmentId` to be a primitive type in the JSON string but got `%s`", jsonObj.get("winningTreatmentId").toString()));
      }
      if ((jsonObj.get("winningReason") != null && !jsonObj.get("winningReason").isJsonNull()) && !jsonObj.get("winningReason").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `winningReason` to be a primitive type in the JSON string but got `%s`", jsonObj.get("winningReason").toString()));
      }
      // validate the optional field `primaryMetric`
      if (jsonObj.get("primaryMetric") != null && !jsonObj.get("primaryMetric").isJsonNull()) {
        DependentMetricOrMetricGroupRep.validateJsonElement(jsonObj.get("primaryMetric"));
      }
      // validate the optional field `primarySingleMetric`
      if (jsonObj.get("primarySingleMetric") != null && !jsonObj.get("primarySingleMetric").isJsonNull()) {
        MetricV2Rep.validateJsonElement(jsonObj.get("primarySingleMetric"));
      }
      // validate the optional field `primaryFunnel`
      if (jsonObj.get("primaryFunnel") != null && !jsonObj.get("primaryFunnel").isJsonNull()) {
        DependentMetricGroupRepWithMetrics.validateJsonElement(jsonObj.get("primaryFunnel"));
      }
      if ((jsonObj.get("randomizationUnit") != null && !jsonObj.get("randomizationUnit").isJsonNull()) && !jsonObj.get("randomizationUnit").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `randomizationUnit` to be a primitive type in the JSON string but got `%s`", jsonObj.get("randomizationUnit").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("attributes") != null && !jsonObj.get("attributes").isJsonNull() && !jsonObj.get("attributes").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `attributes` to be an array in the JSON string but got `%s`", jsonObj.get("attributes").toString()));
      }
      if (jsonObj.get("treatments") != null && !jsonObj.get("treatments").isJsonNull()) {
        JsonArray jsonArraytreatments = jsonObj.getAsJsonArray("treatments");
        if (jsonArraytreatments != null) {
          // ensure the json data is an array
          if (!jsonObj.get("treatments").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `treatments` to be an array in the JSON string but got `%s`", jsonObj.get("treatments").toString()));
          }

          // validate the optional field `treatments` (array)
          for (int i = 0; i < jsonArraytreatments.size(); i++) {
            TreatmentRep.validateJsonElement(jsonArraytreatments.get(i));
          };
        }
      }
      if (jsonObj.get("secondaryMetrics") != null && !jsonObj.get("secondaryMetrics").isJsonNull()) {
        JsonArray jsonArraysecondaryMetrics = jsonObj.getAsJsonArray("secondaryMetrics");
        if (jsonArraysecondaryMetrics != null) {
          // ensure the json data is an array
          if (!jsonObj.get("secondaryMetrics").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `secondaryMetrics` to be an array in the JSON string but got `%s`", jsonObj.get("secondaryMetrics").toString()));
          }

          // validate the optional field `secondaryMetrics` (array)
          for (int i = 0; i < jsonArraysecondaryMetrics.size(); i++) {
            MetricV2Rep.validateJsonElement(jsonArraysecondaryMetrics.get(i));
          };
        }
      }
      if (jsonObj.get("metrics") != null && !jsonObj.get("metrics").isJsonNull()) {
        JsonArray jsonArraymetrics = jsonObj.getAsJsonArray("metrics");
        if (jsonArraymetrics != null) {
          // ensure the json data is an array
          if (!jsonObj.get("metrics").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `metrics` to be an array in the JSON string but got `%s`", jsonObj.get("metrics").toString()));
          }

          // validate the optional field `metrics` (array)
          for (int i = 0; i < jsonArraymetrics.size(); i++) {
            DependentMetricOrMetricGroupRep.validateJsonElement(jsonArraymetrics.get(i));
          };
        }
      }
      // validate the optional field `layerSnapshot`
      if (jsonObj.get("layerSnapshot") != null && !jsonObj.get("layerSnapshot").isJsonNull()) {
        LayerSnapshotRep.validateJsonElement(jsonObj.get("layerSnapshot"));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!IterationRep.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'IterationRep' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<IterationRep> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(IterationRep.class));

       return (TypeAdapter<T>) new TypeAdapter<IterationRep>() {
           @Override
           public void write(JsonWriter out, IterationRep value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public IterationRep read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of IterationRep given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of IterationRep
   * @throws IOException if the JSON string is invalid with respect to IterationRep
   */
  public static IterationRep fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, IterationRep.class);
  }

  /**
   * Convert an instance of IterationRep to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

