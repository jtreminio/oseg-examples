require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

instructions_1 = LaunchDarklyClient::PatchSegmentExpiringTargetInstruction.new
instructions_1.kind = "updateExpiringTarget"
instructions_1.context_key = "user@email.com"
instructions_1.context_kind = "user"
instructions_1.target_type = "included"
instructions_1.value = 1587582000000
instructions_1.version = 0

instructions = [
    instructions_1,
]

patch_segment_expiring_target_input_rep = LaunchDarklyClient::PatchSegmentExpiringTargetInputRep.new
patch_segment_expiring_target_input_rep.comment = "optional comment"
patch_segment_expiring_target_input_rep.instructions = instructions

begin
    response = LaunchDarklyClient::SegmentsApi.new.patch_expiring_targets_for_segment(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "segmentKey_string", # segment_key
        patch_segment_expiring_target_input_rep,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#patch_expiring_targets_for_segment: #{e}"
end
