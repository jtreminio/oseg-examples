require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.get_expiring_user_targets(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "featureFlagKey_string", # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#get_expiring_user_targets: #{e}"
end
