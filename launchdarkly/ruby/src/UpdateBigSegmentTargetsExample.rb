require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

included = LaunchDarklyClient::SegmentUserList.new
included.add = [
]
included.remove = [
]

excluded = LaunchDarklyClient::SegmentUserList.new
excluded.add = [
]
excluded.remove = [
]

segment_user_state = LaunchDarklyClient::SegmentUserState.new
segment_user_state.included = included
segment_user_state.excluded = excluded

begin
    LaunchDarklyClient::SegmentsApi.new.update_big_segment_targets(
        nil, # project_key
        nil, # environment_key
        nil, # segment_key
        segment_user_state,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#update_big_segment_targets: #{e}"
end
