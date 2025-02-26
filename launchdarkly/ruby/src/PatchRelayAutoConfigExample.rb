require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_1 = LaunchDarklyClient::PatchOperation.new
patch_1.op = "replace"
patch_1.path = "/policy/0"

patch = [
    patch_1,
]

patch_with_comment = LaunchDarklyClient::PatchWithComment.new
patch_with_comment.patch = patch

begin
    response = LaunchDarklyClient::RelayProxyConfigurationsApi.new.patch_relay_auto_config(
        nil, # id
        patch_with_comment,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurationsApi#patch_relay_auto_config: #{e}"
end
