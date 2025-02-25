require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::MetricsBetaApi.new.delete_metric_group(
        nil, # project_key
        nil, # metric_group_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBeta#delete_metric_group: #{e}"
end
