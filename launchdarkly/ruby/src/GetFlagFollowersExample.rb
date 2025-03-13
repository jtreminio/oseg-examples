require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FollowFlagsApi.new.get_flag_followers(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FollowFlagsApi#get_flag_followers: #{e}"
end
