require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.get_feature_flag_statuses(
        nil, # project_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlags#get_feature_flag_statuses: #{e}"
end
