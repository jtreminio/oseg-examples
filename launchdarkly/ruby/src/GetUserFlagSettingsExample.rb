require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::UserSettingsApi.new.get_user_flag_settings(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "userKey_string", # user_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettingsApi#get_user_flag_settings: #{e}"
end
