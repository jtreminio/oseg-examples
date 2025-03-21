require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/name"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::MetricsApi.new.patch_metric(
        "projectKey_string", # project_key
        "metricKey_string", # metric_key
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsApi#patch_metric: #{e}"
end
