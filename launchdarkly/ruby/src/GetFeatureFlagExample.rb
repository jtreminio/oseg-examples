require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.get_feature_flag(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#get_feature_flag: #{e}"
end
