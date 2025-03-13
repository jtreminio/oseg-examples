require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "add"
patch_operation_1.path = "/role"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::AccountMembersApi.new.patch_member(
        "id_string", # id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#patch_member: #{e}"
end
