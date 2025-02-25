require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::SegmentsApi.new.get_segment_membership_for_context(
        nil, # project_key
        nil, # environment_key
        nil, # segment_key
        nil, # context_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Segments#get_segment_membership_for_context: #{e}"
end
