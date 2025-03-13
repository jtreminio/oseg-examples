require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::MetricsBetaApi.new.delete_metric_group(
        nil, # project_key
        nil, # metric_group_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBetaApi#delete_metric_group: #{e}"
end
