require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FollowFlagsApi.new.put_flag_follower(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # member_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FollowFlags#put_flag_follower: #{e}"
end
