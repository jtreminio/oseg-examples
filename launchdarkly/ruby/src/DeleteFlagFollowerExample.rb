require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FollowFlagsApi.new.delete_flag_follower(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        "memberId_string", # member_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FollowFlagsApi#delete_flag_follower: #{e}"
end
