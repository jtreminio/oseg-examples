require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::SegmentsApi.new.create_big_segment_import(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "segmentKey_string", # segment_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling SegmentsApi#create_big_segment_import: #{e}"
end
