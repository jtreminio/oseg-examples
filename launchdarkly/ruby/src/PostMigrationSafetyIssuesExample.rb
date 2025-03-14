require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_sempatch = LaunchDarklyClient::FlagSempatch.new
flag_sempatch.instructions = []
flag_sempatch.comment = nil

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.post_migration_safety_issues(
        nil, # project_key
        nil, # flag_key
        nil, # environment_key
        flag_sempatch,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#post_migration_safety_issues: #{e}"
end
