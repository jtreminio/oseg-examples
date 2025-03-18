require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_evaluations_usage(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "featureFlagKey_string", # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBetaApi#get_evaluations_usage: #{e}"
end
