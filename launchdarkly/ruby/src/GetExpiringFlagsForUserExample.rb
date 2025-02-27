require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::UserSettingsApi.new.get_expiring_flags_for_user(
        nil, # project_key
        nil, # user_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UserSettingsApi#get_expiring_flags_for_user: #{e}"
end
