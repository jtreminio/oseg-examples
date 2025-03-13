require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::MetricsApi.new.get_metric(
        nil, # project_key
        nil, # metric_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsApi#get_metric: #{e}"
end
