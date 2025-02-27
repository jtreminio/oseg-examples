require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::MetricsBetaApi.new.get_metric_group(
        nil, # project_key
        nil, # metric_group_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBetaApi#get_metric_group: #{e}"
end
