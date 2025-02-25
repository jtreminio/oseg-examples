require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::SegmentsApi.new.get_context_instance_segments_membership_by_env(
        nil, # project_key
        nil, # environment_key
        JSON.parse(<<-EOD
            {
                "address": {
                    "city": "Springfield",
                    "street": "123 Main Street"
                },
                "jobFunction": "doctor",
                "key": "context-key-123abc",
                "kind": "user",
                "name": "Sandy"
            }
            EOD
        ), # request_body
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Segments#get_context_instance_segments_membership_by_env: #{e}"
end
