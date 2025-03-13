require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_1 = LaunchDarklyClient::PatchOperation.new
patch_1.op = "replace"
patch_1.path = "/description"

patch = [
    patch_1,
]

patch_with_comment = LaunchDarklyClient::PatchWithComment.new
patch_with_comment.patch = patch

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.patch_feature_flag(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        patch_with_comment,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#patch_feature_flag: #{e}"
end
