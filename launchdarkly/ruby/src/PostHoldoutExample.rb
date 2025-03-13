require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

metrics_1 = LaunchDarklyClient::MetricInput.new
metrics_1.key = "metric-key-123abc"
metrics_1.is_group = true
metrics_1.primary = true

metrics = [
    metrics_1,
]

holdout_post_request = LaunchDarklyClient::HoldoutPostRequest.new
holdout_post_request.name = "holdout-one-name"
holdout_post_request.key = "holdout-key"
holdout_post_request.description = "My holdout-one description"
holdout_post_request.randomizationunit = "user"
holdout_post_request.holdoutamount = "10"
holdout_post_request.primarymetrickey = "metric-key-123abc"
holdout_post_request.prerequisiteflagkey = "flag-key-123abc"
holdout_post_request.attributes = [
    "country",
    "device",
    "os",
]
holdout_post_request.metrics = metrics

begin
    response = LaunchDarklyClient::HoldoutsBetaApi.new.post_holdout(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        holdout_post_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling HoldoutsBetaApi#post_holdout: #{e}"
end
