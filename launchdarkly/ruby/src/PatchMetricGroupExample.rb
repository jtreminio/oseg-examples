require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/name"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::MetricsBetaApi.new.patch_metric_group(
        nil, # project_key
        nil, # metric_group_key
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling MetricsBeta#patch_metric_group: #{e}"
end
