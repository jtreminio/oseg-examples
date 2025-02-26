require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsDeploymentsBetaApi.new.get_deployment(
        nil, # deployment_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsDeploymentsBetaApi#get_deployment: #{e}"
end
