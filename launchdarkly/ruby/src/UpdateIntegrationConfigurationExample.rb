require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/on"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::IntegrationsBetaApi.new.update_integration_configuration(
        nil, # integration_configuration_id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBetaApi#update_integration_configuration: #{e}"
end
