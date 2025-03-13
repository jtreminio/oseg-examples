require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

metrics_1 = LaunchDarklyClient::MetricInMetricGroupInput.new
metrics_1.key = "metric-key-123abc"
metrics_1.name_in_group = "Step 1"

metrics = [
    metrics_1,
]

metric_group_post = LaunchDarklyClient::MetricGroupPost.new
metric_group_post.key = "metric-group-key-123abc"
metric_group_post.name = "My metric group"
metric_group_post.kind = "funnel"
metric_group_post.maintainer_id = "569fdeadbeef1644facecafe"
metric_group_post.tags = [
    "ops",
]
metric_group_post.description = "Description of the metric group"
metric_group_post.metrics = metrics

begin
    response = LaunchDarklyClient::MetricsBetaApi.new.create_metric_group(
        nil, # project_key
        metric_group_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBetaApi#create_metric_group: #{e}"
end
