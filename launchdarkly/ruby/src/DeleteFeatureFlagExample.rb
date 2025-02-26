require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FeatureFlagsApi.new.delete_feature_flag(
        nil, # project_key
        nil, # feature_flag_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#delete_feature_flag: #{e}"
end
