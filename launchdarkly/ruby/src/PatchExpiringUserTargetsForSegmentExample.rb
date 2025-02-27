require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

instructions_1 = LaunchDarklyClient::PatchSegmentInstruction.new
instructions_1.kind = "addExpireUserTargetDate"
instructions_1.user_key = "sample-user-key"
instructions_1.target_type = "included"
instructions_1.value = 16534692
instructions_1.version = 0

instructions = [
    instructions_1,
]

patch_segment_request = LaunchDarklyClient::PatchSegmentRequest.new
patch_segment_request.comment = "optional comment"
patch_segment_request.instructions = instructions

begin
    response = LaunchDarklyClient::SegmentsApi.new.patch_expiring_user_targets_for_segment(
        "the-project-key", # project_key
        "the-environment-key", # environment_key
        "the-segment-key", # segment_key
        patch_segment_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#patch_expiring_user_targets_for_segment: #{e}"
end
