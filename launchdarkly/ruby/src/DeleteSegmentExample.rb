require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::SegmentsApi.new.delete_segment(
        nil, # project_key
        nil, # environment_key
        nil, # segment_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#delete_segment: #{e}"
end
