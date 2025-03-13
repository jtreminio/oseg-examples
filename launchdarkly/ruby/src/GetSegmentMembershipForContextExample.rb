require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::SegmentsApi.new.get_segment_membership_for_context(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "segmentKey_string", # segment_key
        "contextKey_string", # context_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#get_segment_membership_for_context: #{e}"
end
