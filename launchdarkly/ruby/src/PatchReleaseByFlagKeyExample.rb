require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/phases/0/complete"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::ReleasesBetaApi.new.patch_release_by_flag_key(
        "projectKey_string", # project_key
        "flagKey_string", # flag_key
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ReleasesBetaApi#patch_release_by_flag_key: #{e}"
end
