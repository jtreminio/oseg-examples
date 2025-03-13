require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

value_put = LaunchDarklyClient::ValuePut.new
value_put.comment = "make sure this context experiences a specific variation"

begin
    LaunchDarklyClient::UserSettingsApi.new.put_flag_setting(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "userKey_string", # user_key
        "featureFlagKey_string", # feature_flag_key
        value_put,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettingsApi#put_flag_setting: #{e}"
end
