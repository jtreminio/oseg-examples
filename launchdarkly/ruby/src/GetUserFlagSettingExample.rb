require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::UserSettingsApi.new.get_user_flag_setting(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "userKey_string", # user_key
        "featureFlagKey_string", # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettingsApi#get_user_flag_setting: #{e}"
end
