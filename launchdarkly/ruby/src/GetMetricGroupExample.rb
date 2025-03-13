require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::MetricsBetaApi.new.get_metric_group(
        "projectKey_string", # project_key
        "metricGroupKey_string", # metric_group_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBetaApi#get_metric_group: #{e}"
end
