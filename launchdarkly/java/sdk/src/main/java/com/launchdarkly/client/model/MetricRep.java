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
import com.launchdarkly.client.model.Access;
import com.launchdarkly.client.model.DependentExperimentRep;
import com.launchdarkly.client.model.DependentMetricGroupRep;
import com.launchdarkly.client.model.FlagListingRep;
import com.launchdarkly.client.model.Link;
import com.launchdarkly.client.model.MemberSummary;
import com.launchdarkly.client.model.MetricEventDefaultRep;
import com.launchdarkly.client.model.Modification;
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
 * MetricRep
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class MetricRep {
  public static final String SERIALIZED_NAME_EXPERIMENT_COUNT = "experimentCount";
  @SerializedName(SERIALIZED_NAME_EXPERIMENT_COUNT)
  @javax.annotation.Nullable
  private Integer experimentCount;

  public static final String SERIALIZED_NAME_METRIC_GROUP_COUNT = "metricGroupCount";
  @SerializedName(SERIALIZED_NAME_METRIC_GROUP_COUNT)
  @javax.annotation.Nullable
  private Integer metricGroupCount;

  public static final String SERIALIZED_NAME_ID = "_id";
  @SerializedName(SERIALIZED_NAME_ID)
  @javax.annotation.Nonnull
  private String id;

  public static final String SERIALIZED_NAME_VERSION_ID = "_versionId";
  @SerializedName(SERIALIZED_NAME_VERSION_ID)
  @javax.annotation.Nonnull
  private String versionId;

  public static final String SERIALIZED_NAME_KEY = "key";
  @SerializedName(SERIALIZED_NAME_KEY)
  @javax.annotation.Nonnull
  private String key;

  public static final String SERIALIZED_NAME_NAME = "name";
  @SerializedName(SERIALIZED_NAME_NAME)
  @javax.annotation.Nonnull
  private String name;

  /**
   * The kind of event the metric tracks
   */
  @JsonAdapter(KindEnum.Adapter.class)
  public enum KindEnum {
    PAGEVIEW("pageview"),
    
    CLICK("click"),
    
    CUSTOM("custom");

    private String value;

    KindEnum(String value) {
      this.value = value;
    }

    public String getValue() {
      return value;
    }

    @Override
    public String toString() {
      return String.valueOf(value);
    }

    public static KindEnum fromValue(String value) {
      for (KindEnum b : KindEnum.values()) {
        if (b.value.equals(value)) {
          return b;
        }
      }
      throw new IllegalArgumentException("Unexpected value '" + value + "'");
    }

    public static class Adapter extends TypeAdapter<KindEnum> {
      @Override
      public void write(final JsonWriter jsonWriter, final KindEnum enumeration) throws IOException {
        jsonWriter.value(enumeration.getValue());
      }

      @Override
      public KindEnum read(final JsonReader jsonReader) throws IOException {
        String value =  jsonReader.nextString();
        return KindEnum.fromValue(value);
      }
    }

    public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      String value = jsonElement.getAsString();
      KindEnum.fromValue(value);
    }
  }

  public static final String SERIALIZED_NAME_KIND = "kind";
  @SerializedName(SERIALIZED_NAME_KIND)
  @javax.annotation.Nonnull
  private KindEnum kind;

  public static final String SERIALIZED_NAME_ATTACHED_FLAG_COUNT = "_attachedFlagCount";
  @SerializedName(SERIALIZED_NAME_ATTACHED_FLAG_COUNT)
  @javax.annotation.Nullable
  private Integer attachedFlagCount;

  public static final String SERIALIZED_NAME_LINKS = "_links";
  @SerializedName(SERIALIZED_NAME_LINKS)
  @javax.annotation.Nonnull
  private Map<String, Link> links = new HashMap<>();

  public static final String SERIALIZED_NAME_SITE = "_site";
  @SerializedName(SERIALIZED_NAME_SITE)
  @javax.annotation.Nullable
  private Link site;

  public static final String SERIALIZED_NAME_ACCESS = "_access";
  @SerializedName(SERIALIZED_NAME_ACCESS)
  @javax.annotation.Nullable
  private Access access;

  public static final String SERIALIZED_NAME_TAGS = "tags";
  @SerializedName(SERIALIZED_NAME_TAGS)
  @javax.annotation.Nonnull
  private List<String> tags = new ArrayList<>();

  public static final String SERIALIZED_NAME_CREATION_DATE = "_creationDate";
  @SerializedName(SERIALIZED_NAME_CREATION_DATE)
  @javax.annotation.Nonnull
  private Long creationDate;

  public static final String SERIALIZED_NAME_LAST_MODIFIED = "lastModified";
  @SerializedName(SERIALIZED_NAME_LAST_MODIFIED)
  @javax.annotation.Nullable
  private Modification lastModified;

  public static final String SERIALIZED_NAME_MAINTAINER_ID = "maintainerId";
  @SerializedName(SERIALIZED_NAME_MAINTAINER_ID)
  @javax.annotation.Nullable
  private String maintainerId;

  public static final String SERIALIZED_NAME_MAINTAINER = "_maintainer";
  @SerializedName(SERIALIZED_NAME_MAINTAINER)
  @javax.annotation.Nullable
  private MemberSummary maintainer;

  public static final String SERIALIZED_NAME_DESCRIPTION = "description";
  @SerializedName(SERIALIZED_NAME_DESCRIPTION)
  @javax.annotation.Nullable
  private String description;

  public static final String SERIALIZED_NAME_IS_NUMERIC = "isNumeric";
  @SerializedName(SERIALIZED_NAME_IS_NUMERIC)
  @javax.annotation.Nullable
  private Boolean isNumeric;

  /**
   * For custom metrics, the success criteria
   */
  @JsonAdapter(SuccessCriteriaEnum.Adapter.class)
  public enum SuccessCriteriaEnum {
    HIGHER_THAN_BASELINE("HigherThanBaseline"),
    
    LOWER_THAN_BASELINE("LowerThanBaseline");

    private String value;

    SuccessCriteriaEnum(String value) {
      this.value = value;
    }

    public String getValue() {
      return value;
    }

    @Override
    public String toString() {
      return String.valueOf(value);
    }

    public static SuccessCriteriaEnum fromValue(String value) {
      for (SuccessCriteriaEnum b : SuccessCriteriaEnum.values()) {
        if (b.value.equals(value)) {
          return b;
        }
      }
      throw new IllegalArgumentException("Unexpected value '" + value + "'");
    }

    public static class Adapter extends TypeAdapter<SuccessCriteriaEnum> {
      @Override
      public void write(final JsonWriter jsonWriter, final SuccessCriteriaEnum enumeration) throws IOException {
        jsonWriter.value(enumeration.getValue());
      }

      @Override
      public SuccessCriteriaEnum read(final JsonReader jsonReader) throws IOException {
        String value =  jsonReader.nextString();
        return SuccessCriteriaEnum.fromValue(value);
      }
    }

    public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      String value = jsonElement.getAsString();
      SuccessCriteriaEnum.fromValue(value);
    }
  }

  public static final String SERIALIZED_NAME_SUCCESS_CRITERIA = "successCriteria";
  @SerializedName(SERIALIZED_NAME_SUCCESS_CRITERIA)
  @javax.annotation.Nullable
  private SuccessCriteriaEnum successCriteria;

  public static final String SERIALIZED_NAME_UNIT = "unit";
  @SerializedName(SERIALIZED_NAME_UNIT)
  @javax.annotation.Nullable
  private String unit;

  public static final String SERIALIZED_NAME_EVENT_KEY = "eventKey";
  @SerializedName(SERIALIZED_NAME_EVENT_KEY)
  @javax.annotation.Nullable
  private String eventKey;

  public static final String SERIALIZED_NAME_RANDOMIZATION_UNITS = "randomizationUnits";
  @SerializedName(SERIALIZED_NAME_RANDOMIZATION_UNITS)
  @javax.annotation.Nullable
  private List<String> randomizationUnits = new ArrayList<>();

  /**
   * The method by which multiple unit event values are aggregated
   */
  @JsonAdapter(UnitAggregationTypeEnum.Adapter.class)
  public enum UnitAggregationTypeEnum {
    AVERAGE("average"),
    
    SUM("sum");

    private String value;

    UnitAggregationTypeEnum(String value) {
      this.value = value;
    }

    public String getValue() {
      return value;
    }

    @Override
    public String toString() {
      return String.valueOf(value);
    }

    public static UnitAggregationTypeEnum fromValue(String value) {
      for (UnitAggregationTypeEnum b : UnitAggregationTypeEnum.values()) {
        if (b.value.equals(value)) {
          return b;
        }
      }
      throw new IllegalArgumentException("Unexpected value '" + value + "'");
    }

    public static class Adapter extends TypeAdapter<UnitAggregationTypeEnum> {
      @Override
      public void write(final JsonWriter jsonWriter, final UnitAggregationTypeEnum enumeration) throws IOException {
        jsonWriter.value(enumeration.getValue());
      }

      @Override
      public UnitAggregationTypeEnum read(final JsonReader jsonReader) throws IOException {
        String value =  jsonReader.nextString();
        return UnitAggregationTypeEnum.fromValue(value);
      }
    }

    public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      String value = jsonElement.getAsString();
      UnitAggregationTypeEnum.fromValue(value);
    }
  }

  public static final String SERIALIZED_NAME_UNIT_AGGREGATION_TYPE = "unitAggregationType";
  @SerializedName(SERIALIZED_NAME_UNIT_AGGREGATION_TYPE)
  @javax.annotation.Nullable
  private UnitAggregationTypeEnum unitAggregationType;

  /**
   * The method for analyzing metric events
   */
  @JsonAdapter(AnalysisTypeEnum.Adapter.class)
  public enum AnalysisTypeEnum {
    MEAN("mean"),
    
    PERCENTILE("percentile");

    private String value;

    AnalysisTypeEnum(String value) {
      this.value = value;
    }

    public String getValue() {
      return value;
    }

    @Override
    public String toString() {
      return String.valueOf(value);
    }

    public static AnalysisTypeEnum fromValue(String value) {
      for (AnalysisTypeEnum b : AnalysisTypeEnum.values()) {
        if (b.value.equals(value)) {
          return b;
        }
      }
      throw new IllegalArgumentException("Unexpected value '" + value + "'");
    }

    public static class Adapter extends TypeAdapter<AnalysisTypeEnum> {
      @Override
      public void write(final JsonWriter jsonWriter, final AnalysisTypeEnum enumeration) throws IOException {
        jsonWriter.value(enumeration.getValue());
      }

      @Override
      public AnalysisTypeEnum read(final JsonReader jsonReader) throws IOException {
        String value =  jsonReader.nextString();
        return AnalysisTypeEnum.fromValue(value);
      }
    }

    public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      String value = jsonElement.getAsString();
      AnalysisTypeEnum.fromValue(value);
    }
  }

  public static final String SERIALIZED_NAME_ANALYSIS_TYPE = "analysisType";
  @SerializedName(SERIALIZED_NAME_ANALYSIS_TYPE)
  @javax.annotation.Nullable
  private AnalysisTypeEnum analysisType;

  public static final String SERIALIZED_NAME_PERCENTILE_VALUE = "percentileValue";
  @SerializedName(SERIALIZED_NAME_PERCENTILE_VALUE)
  @javax.annotation.Nullable
  private Integer percentileValue;

  public static final String SERIALIZED_NAME_EVENT_DEFAULT = "eventDefault";
  @SerializedName(SERIALIZED_NAME_EVENT_DEFAULT)
  @javax.annotation.Nullable
  private MetricEventDefaultRep eventDefault;

  public static final String SERIALIZED_NAME_EXPERIMENTS = "experiments";
  @SerializedName(SERIALIZED_NAME_EXPERIMENTS)
  @javax.annotation.Nullable
  private List<DependentExperimentRep> experiments = new ArrayList<>();

  public static final String SERIALIZED_NAME_METRIC_GROUPS = "metricGroups";
  @SerializedName(SERIALIZED_NAME_METRIC_GROUPS)
  @javax.annotation.Nullable
  private List<DependentMetricGroupRep> metricGroups = new ArrayList<>();

  public static final String SERIALIZED_NAME_IS_ACTIVE = "isActive";
  @SerializedName(SERIALIZED_NAME_IS_ACTIVE)
  @javax.annotation.Nullable
  private Boolean isActive;

  public static final String SERIALIZED_NAME_ATTACHED_FEATURES = "_attachedFeatures";
  @SerializedName(SERIALIZED_NAME_ATTACHED_FEATURES)
  @javax.annotation.Nullable
  private List<FlagListingRep> attachedFeatures = new ArrayList<>();

  public static final String SERIALIZED_NAME_VERSION = "_version";
  @SerializedName(SERIALIZED_NAME_VERSION)
  @javax.annotation.Nullable
  private Integer version;

  public static final String SERIALIZED_NAME_SELECTOR = "selector";
  @SerializedName(SERIALIZED_NAME_SELECTOR)
  @javax.annotation.Nullable
  private String selector;

  public static final String SERIALIZED_NAME_URLS = "urls";
  @SerializedName(SERIALIZED_NAME_URLS)
  @javax.annotation.Nullable
  private List<Map<String, Object>> urls = new ArrayList<>();

  public MetricRep() {
  }

  public MetricRep experimentCount(@javax.annotation.Nullable Integer experimentCount) {
    this.experimentCount = experimentCount;
    return this;
  }

  /**
   * The number of experiments using this metric
   * @return experimentCount
   */
  @javax.annotation.Nullable
  public Integer getExperimentCount() {
    return experimentCount;
  }

  public void setExperimentCount(@javax.annotation.Nullable Integer experimentCount) {
    this.experimentCount = experimentCount;
  }


  public MetricRep metricGroupCount(@javax.annotation.Nullable Integer metricGroupCount) {
    this.metricGroupCount = metricGroupCount;
    return this;
  }

  /**
   * The number of metric groups using this metric
   * @return metricGroupCount
   */
  @javax.annotation.Nullable
  public Integer getMetricGroupCount() {
    return metricGroupCount;
  }

  public void setMetricGroupCount(@javax.annotation.Nullable Integer metricGroupCount) {
    this.metricGroupCount = metricGroupCount;
  }


  public MetricRep id(@javax.annotation.Nonnull String id) {
    this.id = id;
    return this;
  }

  /**
   * The ID of this metric
   * @return id
   */
  @javax.annotation.Nonnull
  public String getId() {
    return id;
  }

  public void setId(@javax.annotation.Nonnull String id) {
    this.id = id;
  }


  public MetricRep versionId(@javax.annotation.Nonnull String versionId) {
    this.versionId = versionId;
    return this;
  }

  /**
   * The version ID of the metric
   * @return versionId
   */
  @javax.annotation.Nonnull
  public String getVersionId() {
    return versionId;
  }

  public void setVersionId(@javax.annotation.Nonnull String versionId) {
    this.versionId = versionId;
  }


  public MetricRep key(@javax.annotation.Nonnull String key) {
    this.key = key;
    return this;
  }

  /**
   * A unique key to reference the metric
   * @return key
   */
  @javax.annotation.Nonnull
  public String getKey() {
    return key;
  }

  public void setKey(@javax.annotation.Nonnull String key) {
    this.key = key;
  }


  public MetricRep name(@javax.annotation.Nonnull String name) {
    this.name = name;
    return this;
  }

  /**
   * A human-friendly name for the metric
   * @return name
   */
  @javax.annotation.Nonnull
  public String getName() {
    return name;
  }

  public void setName(@javax.annotation.Nonnull String name) {
    this.name = name;
  }


  public MetricRep kind(@javax.annotation.Nonnull KindEnum kind) {
    this.kind = kind;
    return this;
  }

  /**
   * The kind of event the metric tracks
   * @return kind
   */
  @javax.annotation.Nonnull
  public KindEnum getKind() {
    return kind;
  }

  public void setKind(@javax.annotation.Nonnull KindEnum kind) {
    this.kind = kind;
  }


  public MetricRep attachedFlagCount(@javax.annotation.Nullable Integer attachedFlagCount) {
    this.attachedFlagCount = attachedFlagCount;
    return this;
  }

  /**
   * The number of feature flags currently attached to this metric
   * @return attachedFlagCount
   */
  @javax.annotation.Nullable
  public Integer getAttachedFlagCount() {
    return attachedFlagCount;
  }

  public void setAttachedFlagCount(@javax.annotation.Nullable Integer attachedFlagCount) {
    this.attachedFlagCount = attachedFlagCount;
  }


  public MetricRep links(@javax.annotation.Nonnull Map<String, Link> links) {
    this.links = links;
    return this;
  }

  public MetricRep putLinksItem(String key, Link linksItem) {
    if (this.links == null) {
      this.links = new HashMap<>();
    }
    this.links.put(key, linksItem);
    return this;
  }

  /**
   * The location and content type of related resources
   * @return links
   */
  @javax.annotation.Nonnull
  public Map<String, Link> getLinks() {
    return links;
  }

  public void setLinks(@javax.annotation.Nonnull Map<String, Link> links) {
    this.links = links;
  }


  public MetricRep site(@javax.annotation.Nullable Link site) {
    this.site = site;
    return this;
  }

  /**
   * Get site
   * @return site
   */
  @javax.annotation.Nullable
  public Link getSite() {
    return site;
  }

  public void setSite(@javax.annotation.Nullable Link site) {
    this.site = site;
  }


  public MetricRep access(@javax.annotation.Nullable Access access) {
    this.access = access;
    return this;
  }

  /**
   * Get access
   * @return access
   */
  @javax.annotation.Nullable
  public Access getAccess() {
    return access;
  }

  public void setAccess(@javax.annotation.Nullable Access access) {
    this.access = access;
  }


  public MetricRep tags(@javax.annotation.Nonnull List<String> tags) {
    this.tags = tags;
    return this;
  }

  public MetricRep addTagsItem(String tagsItem) {
    if (this.tags == null) {
      this.tags = new ArrayList<>();
    }
    this.tags.add(tagsItem);
    return this;
  }

  /**
   * Tags for the metric
   * @return tags
   */
  @javax.annotation.Nonnull
  public List<String> getTags() {
    return tags;
  }

  public void setTags(@javax.annotation.Nonnull List<String> tags) {
    this.tags = tags;
  }


  public MetricRep creationDate(@javax.annotation.Nonnull Long creationDate) {
    this.creationDate = creationDate;
    return this;
  }

  /**
   * Get creationDate
   * @return creationDate
   */
  @javax.annotation.Nonnull
  public Long getCreationDate() {
    return creationDate;
  }

  public void setCreationDate(@javax.annotation.Nonnull Long creationDate) {
    this.creationDate = creationDate;
  }


  public MetricRep lastModified(@javax.annotation.Nullable Modification lastModified) {
    this.lastModified = lastModified;
    return this;
  }

  /**
   * Get lastModified
   * @return lastModified
   */
  @javax.annotation.Nullable
  public Modification getLastModified() {
    return lastModified;
  }

  public void setLastModified(@javax.annotation.Nullable Modification lastModified) {
    this.lastModified = lastModified;
  }


  public MetricRep maintainerId(@javax.annotation.Nullable String maintainerId) {
    this.maintainerId = maintainerId;
    return this;
  }

  /**
   * The ID of the member who maintains this metric
   * @return maintainerId
   */
  @javax.annotation.Nullable
  public String getMaintainerId() {
    return maintainerId;
  }

  public void setMaintainerId(@javax.annotation.Nullable String maintainerId) {
    this.maintainerId = maintainerId;
  }


  public MetricRep maintainer(@javax.annotation.Nullable MemberSummary maintainer) {
    this.maintainer = maintainer;
    return this;
  }

  /**
   * Get maintainer
   * @return maintainer
   */
  @javax.annotation.Nullable
  public MemberSummary getMaintainer() {
    return maintainer;
  }

  public void setMaintainer(@javax.annotation.Nullable MemberSummary maintainer) {
    this.maintainer = maintainer;
  }


  public MetricRep description(@javax.annotation.Nullable String description) {
    this.description = description;
    return this;
  }

  /**
   * Description of the metric
   * @return description
   */
  @javax.annotation.Nullable
  public String getDescription() {
    return description;
  }

  public void setDescription(@javax.annotation.Nullable String description) {
    this.description = description;
  }


  public MetricRep isNumeric(@javax.annotation.Nullable Boolean isNumeric) {
    this.isNumeric = isNumeric;
    return this;
  }

  /**
   * For custom metrics, whether to track numeric changes in value against a baseline (&lt;code&gt;true&lt;/code&gt;) or to track a conversion when an end user takes an action (&lt;code&gt;false&lt;/code&gt;).
   * @return isNumeric
   */
  @javax.annotation.Nullable
  public Boolean getIsNumeric() {
    return isNumeric;
  }

  public void setIsNumeric(@javax.annotation.Nullable Boolean isNumeric) {
    this.isNumeric = isNumeric;
  }


  public MetricRep successCriteria(@javax.annotation.Nullable SuccessCriteriaEnum successCriteria) {
    this.successCriteria = successCriteria;
    return this;
  }

  /**
   * For custom metrics, the success criteria
   * @return successCriteria
   */
  @javax.annotation.Nullable
  public SuccessCriteriaEnum getSuccessCriteria() {
    return successCriteria;
  }

  public void setSuccessCriteria(@javax.annotation.Nullable SuccessCriteriaEnum successCriteria) {
    this.successCriteria = successCriteria;
  }


  public MetricRep unit(@javax.annotation.Nullable String unit) {
    this.unit = unit;
    return this;
  }

  /**
   * For numeric custom metrics, the unit of measure
   * @return unit
   */
  @javax.annotation.Nullable
  public String getUnit() {
    return unit;
  }

  public void setUnit(@javax.annotation.Nullable String unit) {
    this.unit = unit;
  }


  public MetricRep eventKey(@javax.annotation.Nullable String eventKey) {
    this.eventKey = eventKey;
    return this;
  }

  /**
   * For custom metrics, the event key to use in your code
   * @return eventKey
   */
  @javax.annotation.Nullable
  public String getEventKey() {
    return eventKey;
  }

  public void setEventKey(@javax.annotation.Nullable String eventKey) {
    this.eventKey = eventKey;
  }


  public MetricRep randomizationUnits(@javax.annotation.Nullable List<String> randomizationUnits) {
    this.randomizationUnits = randomizationUnits;
    return this;
  }

  public MetricRep addRandomizationUnitsItem(String randomizationUnitsItem) {
    if (this.randomizationUnits == null) {
      this.randomizationUnits = new ArrayList<>();
    }
    this.randomizationUnits.add(randomizationUnitsItem);
    return this;
  }

  /**
   * An array of randomization units allowed for this metric
   * @return randomizationUnits
   */
  @javax.annotation.Nullable
  public List<String> getRandomizationUnits() {
    return randomizationUnits;
  }

  public void setRandomizationUnits(@javax.annotation.Nullable List<String> randomizationUnits) {
    this.randomizationUnits = randomizationUnits;
  }


  public MetricRep unitAggregationType(@javax.annotation.Nullable UnitAggregationTypeEnum unitAggregationType) {
    this.unitAggregationType = unitAggregationType;
    return this;
  }

  /**
   * The method by which multiple unit event values are aggregated
   * @return unitAggregationType
   */
  @javax.annotation.Nullable
  public UnitAggregationTypeEnum getUnitAggregationType() {
    return unitAggregationType;
  }

  public void setUnitAggregationType(@javax.annotation.Nullable UnitAggregationTypeEnum unitAggregationType) {
    this.unitAggregationType = unitAggregationType;
  }


  public MetricRep analysisType(@javax.annotation.Nullable AnalysisTypeEnum analysisType) {
    this.analysisType = analysisType;
    return this;
  }

  /**
   * The method for analyzing metric events
   * @return analysisType
   */
  @javax.annotation.Nullable
  public AnalysisTypeEnum getAnalysisType() {
    return analysisType;
  }

  public void setAnalysisType(@javax.annotation.Nullable AnalysisTypeEnum analysisType) {
    this.analysisType = analysisType;
  }


  public MetricRep percentileValue(@javax.annotation.Nullable Integer percentileValue) {
    this.percentileValue = percentileValue;
    return this;
  }

  /**
   * The percentile for the analysis method. An integer denoting the target percentile between 0 and 100. Required when &lt;code&gt;analysisType&lt;/code&gt; is &lt;code&gt;percentile&lt;/code&gt;.
   * @return percentileValue
   */
  @javax.annotation.Nullable
  public Integer getPercentileValue() {
    return percentileValue;
  }

  public void setPercentileValue(@javax.annotation.Nullable Integer percentileValue) {
    this.percentileValue = percentileValue;
  }


  public MetricRep eventDefault(@javax.annotation.Nullable MetricEventDefaultRep eventDefault) {
    this.eventDefault = eventDefault;
    return this;
  }

  /**
   * Get eventDefault
   * @return eventDefault
   */
  @javax.annotation.Nullable
  public MetricEventDefaultRep getEventDefault() {
    return eventDefault;
  }

  public void setEventDefault(@javax.annotation.Nullable MetricEventDefaultRep eventDefault) {
    this.eventDefault = eventDefault;
  }


  public MetricRep experiments(@javax.annotation.Nullable List<DependentExperimentRep> experiments) {
    this.experiments = experiments;
    return this;
  }

  public MetricRep addExperimentsItem(DependentExperimentRep experimentsItem) {
    if (this.experiments == null) {
      this.experiments = new ArrayList<>();
    }
    this.experiments.add(experimentsItem);
    return this;
  }

  /**
   * Get experiments
   * @return experiments
   */
  @javax.annotation.Nullable
  public List<DependentExperimentRep> getExperiments() {
    return experiments;
  }

  public void setExperiments(@javax.annotation.Nullable List<DependentExperimentRep> experiments) {
    this.experiments = experiments;
  }


  public MetricRep metricGroups(@javax.annotation.Nullable List<DependentMetricGroupRep> metricGroups) {
    this.metricGroups = metricGroups;
    return this;
  }

  public MetricRep addMetricGroupsItem(DependentMetricGroupRep metricGroupsItem) {
    if (this.metricGroups == null) {
      this.metricGroups = new ArrayList<>();
    }
    this.metricGroups.add(metricGroupsItem);
    return this;
  }

  /**
   * Metric groups that use this metric
   * @return metricGroups
   */
  @javax.annotation.Nullable
  public List<DependentMetricGroupRep> getMetricGroups() {
    return metricGroups;
  }

  public void setMetricGroups(@javax.annotation.Nullable List<DependentMetricGroupRep> metricGroups) {
    this.metricGroups = metricGroups;
  }


  public MetricRep isActive(@javax.annotation.Nullable Boolean isActive) {
    this.isActive = isActive;
    return this;
  }

  /**
   * Whether the metric is active
   * @return isActive
   */
  @javax.annotation.Nullable
  public Boolean getIsActive() {
    return isActive;
  }

  public void setIsActive(@javax.annotation.Nullable Boolean isActive) {
    this.isActive = isActive;
  }


  public MetricRep attachedFeatures(@javax.annotation.Nullable List<FlagListingRep> attachedFeatures) {
    this.attachedFeatures = attachedFeatures;
    return this;
  }

  public MetricRep addAttachedFeaturesItem(FlagListingRep attachedFeaturesItem) {
    if (this.attachedFeatures == null) {
      this.attachedFeatures = new ArrayList<>();
    }
    this.attachedFeatures.add(attachedFeaturesItem);
    return this;
  }

  /**
   * Details on the flags attached to this metric
   * @return attachedFeatures
   */
  @javax.annotation.Nullable
  public List<FlagListingRep> getAttachedFeatures() {
    return attachedFeatures;
  }

  public void setAttachedFeatures(@javax.annotation.Nullable List<FlagListingRep> attachedFeatures) {
    this.attachedFeatures = attachedFeatures;
  }


  public MetricRep version(@javax.annotation.Nullable Integer version) {
    this.version = version;
    return this;
  }

  /**
   * Version of the metric
   * @return version
   */
  @javax.annotation.Nullable
  public Integer getVersion() {
    return version;
  }

  public void setVersion(@javax.annotation.Nullable Integer version) {
    this.version = version;
  }


  public MetricRep selector(@javax.annotation.Nullable String selector) {
    this.selector = selector;
    return this;
  }

  /**
   * For click metrics, the CSS selectors
   * @return selector
   */
  @javax.annotation.Nullable
  public String getSelector() {
    return selector;
  }

  public void setSelector(@javax.annotation.Nullable String selector) {
    this.selector = selector;
  }


  public MetricRep urls(@javax.annotation.Nullable List<Map<String, Object>> urls) {
    this.urls = urls;
    return this;
  }

  public MetricRep addUrlsItem(Map<String, Object> urlsItem) {
    if (this.urls == null) {
      this.urls = new ArrayList<>();
    }
    this.urls.add(urlsItem);
    return this;
  }

  /**
   * Get urls
   * @return urls
   */
  @javax.annotation.Nullable
  public List<Map<String, Object>> getUrls() {
    return urls;
  }

  public void setUrls(@javax.annotation.Nullable List<Map<String, Object>> urls) {
    this.urls = urls;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    MetricRep metricRep = (MetricRep) o;
    return Objects.equals(this.experimentCount, metricRep.experimentCount) &&
        Objects.equals(this.metricGroupCount, metricRep.metricGroupCount) &&
        Objects.equals(this.id, metricRep.id) &&
        Objects.equals(this.versionId, metricRep.versionId) &&
        Objects.equals(this.key, metricRep.key) &&
        Objects.equals(this.name, metricRep.name) &&
        Objects.equals(this.kind, metricRep.kind) &&
        Objects.equals(this.attachedFlagCount, metricRep.attachedFlagCount) &&
        Objects.equals(this.links, metricRep.links) &&
        Objects.equals(this.site, metricRep.site) &&
        Objects.equals(this.access, metricRep.access) &&
        Objects.equals(this.tags, metricRep.tags) &&
        Objects.equals(this.creationDate, metricRep.creationDate) &&
        Objects.equals(this.lastModified, metricRep.lastModified) &&
        Objects.equals(this.maintainerId, metricRep.maintainerId) &&
        Objects.equals(this.maintainer, metricRep.maintainer) &&
        Objects.equals(this.description, metricRep.description) &&
        Objects.equals(this.isNumeric, metricRep.isNumeric) &&
        Objects.equals(this.successCriteria, metricRep.successCriteria) &&
        Objects.equals(this.unit, metricRep.unit) &&
        Objects.equals(this.eventKey, metricRep.eventKey) &&
        Objects.equals(this.randomizationUnits, metricRep.randomizationUnits) &&
        Objects.equals(this.unitAggregationType, metricRep.unitAggregationType) &&
        Objects.equals(this.analysisType, metricRep.analysisType) &&
        Objects.equals(this.percentileValue, metricRep.percentileValue) &&
        Objects.equals(this.eventDefault, metricRep.eventDefault) &&
        Objects.equals(this.experiments, metricRep.experiments) &&
        Objects.equals(this.metricGroups, metricRep.metricGroups) &&
        Objects.equals(this.isActive, metricRep.isActive) &&
        Objects.equals(this.attachedFeatures, metricRep.attachedFeatures) &&
        Objects.equals(this.version, metricRep.version) &&
        Objects.equals(this.selector, metricRep.selector) &&
        Objects.equals(this.urls, metricRep.urls);
  }

  @Override
  public int hashCode() {
    return Objects.hash(experimentCount, metricGroupCount, id, versionId, key, name, kind, attachedFlagCount, links, site, access, tags, creationDate, lastModified, maintainerId, maintainer, description, isNumeric, successCriteria, unit, eventKey, randomizationUnits, unitAggregationType, analysisType, percentileValue, eventDefault, experiments, metricGroups, isActive, attachedFeatures, version, selector, urls);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class MetricRep {\n");
    sb.append("    experimentCount: ").append(toIndentedString(experimentCount)).append("\n");
    sb.append("    metricGroupCount: ").append(toIndentedString(metricGroupCount)).append("\n");
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    versionId: ").append(toIndentedString(versionId)).append("\n");
    sb.append("    key: ").append(toIndentedString(key)).append("\n");
    sb.append("    name: ").append(toIndentedString(name)).append("\n");
    sb.append("    kind: ").append(toIndentedString(kind)).append("\n");
    sb.append("    attachedFlagCount: ").append(toIndentedString(attachedFlagCount)).append("\n");
    sb.append("    links: ").append(toIndentedString(links)).append("\n");
    sb.append("    site: ").append(toIndentedString(site)).append("\n");
    sb.append("    access: ").append(toIndentedString(access)).append("\n");
    sb.append("    tags: ").append(toIndentedString(tags)).append("\n");
    sb.append("    creationDate: ").append(toIndentedString(creationDate)).append("\n");
    sb.append("    lastModified: ").append(toIndentedString(lastModified)).append("\n");
    sb.append("    maintainerId: ").append(toIndentedString(maintainerId)).append("\n");
    sb.append("    maintainer: ").append(toIndentedString(maintainer)).append("\n");
    sb.append("    description: ").append(toIndentedString(description)).append("\n");
    sb.append("    isNumeric: ").append(toIndentedString(isNumeric)).append("\n");
    sb.append("    successCriteria: ").append(toIndentedString(successCriteria)).append("\n");
    sb.append("    unit: ").append(toIndentedString(unit)).append("\n");
    sb.append("    eventKey: ").append(toIndentedString(eventKey)).append("\n");
    sb.append("    randomizationUnits: ").append(toIndentedString(randomizationUnits)).append("\n");
    sb.append("    unitAggregationType: ").append(toIndentedString(unitAggregationType)).append("\n");
    sb.append("    analysisType: ").append(toIndentedString(analysisType)).append("\n");
    sb.append("    percentileValue: ").append(toIndentedString(percentileValue)).append("\n");
    sb.append("    eventDefault: ").append(toIndentedString(eventDefault)).append("\n");
    sb.append("    experiments: ").append(toIndentedString(experiments)).append("\n");
    sb.append("    metricGroups: ").append(toIndentedString(metricGroups)).append("\n");
    sb.append("    isActive: ").append(toIndentedString(isActive)).append("\n");
    sb.append("    attachedFeatures: ").append(toIndentedString(attachedFeatures)).append("\n");
    sb.append("    version: ").append(toIndentedString(version)).append("\n");
    sb.append("    selector: ").append(toIndentedString(selector)).append("\n");
    sb.append("    urls: ").append(toIndentedString(urls)).append("\n");
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
    openapiFields.add("experimentCount");
    openapiFields.add("metricGroupCount");
    openapiFields.add("_id");
    openapiFields.add("_versionId");
    openapiFields.add("key");
    openapiFields.add("name");
    openapiFields.add("kind");
    openapiFields.add("_attachedFlagCount");
    openapiFields.add("_links");
    openapiFields.add("_site");
    openapiFields.add("_access");
    openapiFields.add("tags");
    openapiFields.add("_creationDate");
    openapiFields.add("lastModified");
    openapiFields.add("maintainerId");
    openapiFields.add("_maintainer");
    openapiFields.add("description");
    openapiFields.add("isNumeric");
    openapiFields.add("successCriteria");
    openapiFields.add("unit");
    openapiFields.add("eventKey");
    openapiFields.add("randomizationUnits");
    openapiFields.add("unitAggregationType");
    openapiFields.add("analysisType");
    openapiFields.add("percentileValue");
    openapiFields.add("eventDefault");
    openapiFields.add("experiments");
    openapiFields.add("metricGroups");
    openapiFields.add("isActive");
    openapiFields.add("_attachedFeatures");
    openapiFields.add("_version");
    openapiFields.add("selector");
    openapiFields.add("urls");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
    openapiRequiredFields.add("_id");
    openapiRequiredFields.add("_versionId");
    openapiRequiredFields.add("key");
    openapiRequiredFields.add("name");
    openapiRequiredFields.add("kind");
    openapiRequiredFields.add("_links");
    openapiRequiredFields.add("tags");
    openapiRequiredFields.add("_creationDate");
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to MetricRep
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!MetricRep.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in MetricRep is not found in the empty JSON string", MetricRep.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!MetricRep.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `MetricRep` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }

      // check to make sure all required properties/fields are present in the JSON string
      for (String requiredField : MetricRep.openapiRequiredFields) {
        if (jsonElement.getAsJsonObject().get(requiredField) == null) {
          throw new IllegalArgumentException(String.format("The required field `%s` is not found in the JSON string: %s", requiredField, jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if (!jsonObj.get("_id").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `_id` to be a primitive type in the JSON string but got `%s`", jsonObj.get("_id").toString()));
      }
      if (!jsonObj.get("_versionId").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `_versionId` to be a primitive type in the JSON string but got `%s`", jsonObj.get("_versionId").toString()));
      }
      if (!jsonObj.get("key").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `key` to be a primitive type in the JSON string but got `%s`", jsonObj.get("key").toString()));
      }
      if (!jsonObj.get("name").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `name` to be a primitive type in the JSON string but got `%s`", jsonObj.get("name").toString()));
      }
      if (!jsonObj.get("kind").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `kind` to be a primitive type in the JSON string but got `%s`", jsonObj.get("kind").toString()));
      }
      // validate the required field `kind`
      KindEnum.validateJsonElement(jsonObj.get("kind"));
      // validate the optional field `_site`
      if (jsonObj.get("_site") != null && !jsonObj.get("_site").isJsonNull()) {
        Link.validateJsonElement(jsonObj.get("_site"));
      }
      // validate the optional field `_access`
      if (jsonObj.get("_access") != null && !jsonObj.get("_access").isJsonNull()) {
        Access.validateJsonElement(jsonObj.get("_access"));
      }
      // ensure the required json array is present
      if (jsonObj.get("tags") == null) {
        throw new IllegalArgumentException("Expected the field `linkedContent` to be an array in the JSON string but got `null`");
      } else if (!jsonObj.get("tags").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `tags` to be an array in the JSON string but got `%s`", jsonObj.get("tags").toString()));
      }
      // validate the optional field `lastModified`
      if (jsonObj.get("lastModified") != null && !jsonObj.get("lastModified").isJsonNull()) {
        Modification.validateJsonElement(jsonObj.get("lastModified"));
      }
      if ((jsonObj.get("maintainerId") != null && !jsonObj.get("maintainerId").isJsonNull()) && !jsonObj.get("maintainerId").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `maintainerId` to be a primitive type in the JSON string but got `%s`", jsonObj.get("maintainerId").toString()));
      }
      // validate the optional field `_maintainer`
      if (jsonObj.get("_maintainer") != null && !jsonObj.get("_maintainer").isJsonNull()) {
        MemberSummary.validateJsonElement(jsonObj.get("_maintainer"));
      }
      if ((jsonObj.get("description") != null && !jsonObj.get("description").isJsonNull()) && !jsonObj.get("description").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `description` to be a primitive type in the JSON string but got `%s`", jsonObj.get("description").toString()));
      }
      if ((jsonObj.get("successCriteria") != null && !jsonObj.get("successCriteria").isJsonNull()) && !jsonObj.get("successCriteria").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `successCriteria` to be a primitive type in the JSON string but got `%s`", jsonObj.get("successCriteria").toString()));
      }
      // validate the optional field `successCriteria`
      if (jsonObj.get("successCriteria") != null && !jsonObj.get("successCriteria").isJsonNull()) {
        SuccessCriteriaEnum.validateJsonElement(jsonObj.get("successCriteria"));
      }
      if ((jsonObj.get("unit") != null && !jsonObj.get("unit").isJsonNull()) && !jsonObj.get("unit").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `unit` to be a primitive type in the JSON string but got `%s`", jsonObj.get("unit").toString()));
      }
      if ((jsonObj.get("eventKey") != null && !jsonObj.get("eventKey").isJsonNull()) && !jsonObj.get("eventKey").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `eventKey` to be a primitive type in the JSON string but got `%s`", jsonObj.get("eventKey").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("randomizationUnits") != null && !jsonObj.get("randomizationUnits").isJsonNull() && !jsonObj.get("randomizationUnits").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `randomizationUnits` to be an array in the JSON string but got `%s`", jsonObj.get("randomizationUnits").toString()));
      }
      if ((jsonObj.get("unitAggregationType") != null && !jsonObj.get("unitAggregationType").isJsonNull()) && !jsonObj.get("unitAggregationType").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `unitAggregationType` to be a primitive type in the JSON string but got `%s`", jsonObj.get("unitAggregationType").toString()));
      }
      // validate the optional field `unitAggregationType`
      if (jsonObj.get("unitAggregationType") != null && !jsonObj.get("unitAggregationType").isJsonNull()) {
        UnitAggregationTypeEnum.validateJsonElement(jsonObj.get("unitAggregationType"));
      }
      if ((jsonObj.get("analysisType") != null && !jsonObj.get("analysisType").isJsonNull()) && !jsonObj.get("analysisType").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `analysisType` to be a primitive type in the JSON string but got `%s`", jsonObj.get("analysisType").toString()));
      }
      // validate the optional field `analysisType`
      if (jsonObj.get("analysisType") != null && !jsonObj.get("analysisType").isJsonNull()) {
        AnalysisTypeEnum.validateJsonElement(jsonObj.get("analysisType"));
      }
      // validate the optional field `eventDefault`
      if (jsonObj.get("eventDefault") != null && !jsonObj.get("eventDefault").isJsonNull()) {
        MetricEventDefaultRep.validateJsonElement(jsonObj.get("eventDefault"));
      }
      if (jsonObj.get("experiments") != null && !jsonObj.get("experiments").isJsonNull()) {
        JsonArray jsonArrayexperiments = jsonObj.getAsJsonArray("experiments");
        if (jsonArrayexperiments != null) {
          // ensure the json data is an array
          if (!jsonObj.get("experiments").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `experiments` to be an array in the JSON string but got `%s`", jsonObj.get("experiments").toString()));
          }

          // validate the optional field `experiments` (array)
          for (int i = 0; i < jsonArrayexperiments.size(); i++) {
            DependentExperimentRep.validateJsonElement(jsonArrayexperiments.get(i));
          };
        }
      }
      if (jsonObj.get("metricGroups") != null && !jsonObj.get("metricGroups").isJsonNull()) {
        JsonArray jsonArraymetricGroups = jsonObj.getAsJsonArray("metricGroups");
        if (jsonArraymetricGroups != null) {
          // ensure the json data is an array
          if (!jsonObj.get("metricGroups").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `metricGroups` to be an array in the JSON string but got `%s`", jsonObj.get("metricGroups").toString()));
          }

          // validate the optional field `metricGroups` (array)
          for (int i = 0; i < jsonArraymetricGroups.size(); i++) {
            DependentMetricGroupRep.validateJsonElement(jsonArraymetricGroups.get(i));
          };
        }
      }
      if (jsonObj.get("_attachedFeatures") != null && !jsonObj.get("_attachedFeatures").isJsonNull()) {
        JsonArray jsonArrayattachedFeatures = jsonObj.getAsJsonArray("_attachedFeatures");
        if (jsonArrayattachedFeatures != null) {
          // ensure the json data is an array
          if (!jsonObj.get("_attachedFeatures").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `_attachedFeatures` to be an array in the JSON string but got `%s`", jsonObj.get("_attachedFeatures").toString()));
          }

          // validate the optional field `_attachedFeatures` (array)
          for (int i = 0; i < jsonArrayattachedFeatures.size(); i++) {
            FlagListingRep.validateJsonElement(jsonArrayattachedFeatures.get(i));
          };
        }
      }
      if ((jsonObj.get("selector") != null && !jsonObj.get("selector").isJsonNull()) && !jsonObj.get("selector").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `selector` to be a primitive type in the JSON string but got `%s`", jsonObj.get("selector").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("urls") != null && !jsonObj.get("urls").isJsonNull() && !jsonObj.get("urls").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `urls` to be an array in the JSON string but got `%s`", jsonObj.get("urls").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!MetricRep.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'MetricRep' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<MetricRep> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(MetricRep.class));

       return (TypeAdapter<T>) new TypeAdapter<MetricRep>() {
           @Override
           public void write(JsonWriter out, MetricRep value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public MetricRep read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of MetricRep given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of MetricRep
   * @throws IOException if the JSON string is invalid with respect to MetricRep
   */
  public static MetricRep fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, MetricRep.class);
  }

  /**
   * Convert an instance of MetricRep to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

