require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsChartsBetaApi.new.get_lead_time_chart(
        "projectKey_string", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsChartsBetaApi#get_lead_time_chart: #{e}"
end
