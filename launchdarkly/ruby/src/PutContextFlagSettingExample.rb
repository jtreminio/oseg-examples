require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

value_put = LaunchDarklyClient::ValuePut.new
value_put.comment = "make sure this context experiences a specific variation"

begin
    LaunchDarklyClient::ContextSettingsApi.new.put_context_flag_setting(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "contextKind_string", # context_kind
        "contextKey_string", # context_key
        "featureFlagKey_string", # feature_flag_key
        value_put,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextSettingsApi#put_context_flag_setting: #{e}"
end
