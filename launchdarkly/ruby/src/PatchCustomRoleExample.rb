require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_1 = LaunchDarklyClient::PatchOperation.new
patch_1.op = "add"
patch_1.path = "/policy/0"

patch = [
    patch_1,
]

patch_with_comment = LaunchDarklyClient::PatchWithComment.new
patch_with_comment.patch = patch

begin
    response = LaunchDarklyClient::CustomRolesApi.new.patch_custom_role(
        "customRoleKey_string", # custom_role_key
        patch_with_comment,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRolesApi#patch_custom_role: #{e}"
end
