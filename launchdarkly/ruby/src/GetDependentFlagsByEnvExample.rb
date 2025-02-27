require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FeatureFlagsBetaApi.new.get_dependent_flags_by_env(
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsBetaApi#get_dependent_flags_by_env: #{e}"
end
