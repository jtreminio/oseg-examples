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
    response = LaunchDarklyClient::WebhooksApi.new.patch_webhook(
        nil, # id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WebhooksApi#patch_webhook: #{e}"
end
