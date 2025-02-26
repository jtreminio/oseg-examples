require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/status"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::InsightsDeploymentsBetaApi.new.update_deployment(
        nil, # deployment_id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsDeploymentsBetaApi#update_deployment: #{e}"
end
