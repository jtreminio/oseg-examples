require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::MetricsBetaApi.new.get_metric_groups(
        nil, # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBeta#get_metric_groups: #{e}"
end
