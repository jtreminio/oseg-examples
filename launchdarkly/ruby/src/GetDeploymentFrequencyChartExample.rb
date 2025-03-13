require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsChartsBetaApi.new.get_deployment_frequency_chart

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsChartsBetaApi#get_deployment_frequency_chart: #{e}"
end
