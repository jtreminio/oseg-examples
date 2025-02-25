require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsChartsBetaApi.new.get_stale_flags_chart(
        nil, # project_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsChartsBeta#get_stale_flags_chart: #{e}"
end
