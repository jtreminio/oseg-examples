require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

segment_body = LaunchDarklyClient::SegmentBody.new
segment_body.name = "Example segment"
segment_body.key = "segment-key-123abc"
segment_body.description = "Bundle our sample customers together"
segment_body.unbounded = false
segment_body.unbounded_context_kind = "device"
segment_body.tags = [
    "testing",
]

begin
    response = LaunchDarklyClient::SegmentsApi.new.post_segment(
        nil, # project_key
        nil, # environment_key
        segment_body,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Segments#post_segment: #{e}"
end
