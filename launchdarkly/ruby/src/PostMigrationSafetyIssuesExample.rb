require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_sempatch = LaunchDarklyClient::FlagSempatch.new
flag_sempatch.instructions = []

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.post_migration_safety_issues(
        "projectKey_string", # project_key
        "flagKey_string", # flag_key
        "environmentKey_string", # environment_key
        flag_sempatch,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#post_migration_safety_issues: #{e}"
end
