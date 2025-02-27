require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

metric_post = LaunchDarklyClient::MetricPost.new
metric_post.key = "metric-key-123abc"
metric_post.kind = "custom"
metric_post.is_active = true
metric_post.is_numeric = false
metric_post.event_key = "trackedClick"

begin
    response = LaunchDarklyClient::MetricsApi.new.post_metric(
        nil, # project_key
        metric_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsApi#post_metric: #{e}"
end
