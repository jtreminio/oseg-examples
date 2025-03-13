require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::UserSettingsApi.new.get_expiring_flags_for_user(
        "projectKey_string", # project_key
        "userKey_string", # user_key
        "environmentKey_string", # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettingsApi#get_expiring_flags_for_user: #{e}"
end
