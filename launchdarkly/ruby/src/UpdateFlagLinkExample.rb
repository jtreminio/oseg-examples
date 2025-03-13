require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/title"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::FlagLinksBetaApi.new.update_flag_link(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "id_string", # id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagLinksBetaApi#update_flag_link: #{e}"
end
