require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::MetricsApi.new.delete_metric(
        nil, # project_key
        nil, # metric_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsApi#delete_metric: #{e}"
end
