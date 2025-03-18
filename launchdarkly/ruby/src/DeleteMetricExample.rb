require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::MetricsApi.new.delete_metric(
        "projectKey_string", # project_key
        "metricKey_string", # metric_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsApi#delete_metric: #{e}"
end
