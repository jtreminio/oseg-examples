require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_1 = LaunchDarklyClient::PatchOperation.new
patch_1.op = "replace"
patch_1.path = "/description"

patch_2 = LaunchDarklyClient::PatchOperation.new
patch_2.op = "add"
patch_2.path = "/tags/0"

patch = [
    patch_1,
    patch_2,
]

patch_with_comment = LaunchDarklyClient::PatchWithComment.new
patch_with_comment.patch = patch

begin
    response = LaunchDarklyClient::SegmentsApi.new.patch_segment(
        nil, # project_key
        nil, # environment_key
        nil, # segment_key
        patch_with_comment,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#patch_segment: #{e}"
end
