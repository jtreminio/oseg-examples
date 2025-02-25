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
    response = LaunchDarklyClient::OAuth2ClientsApi.new.patch_o_auth_client(
        nil, # client_id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2Clients#patch_o_auth_client: #{e}"
end
