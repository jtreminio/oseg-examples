require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::SegmentsApi.new.get_expiring_targets_for_segment(
        nil, # project_key
        nil, # environment_key
        nil, # segment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Segments#get_expiring_targets_for_segment: #{e}"
end
