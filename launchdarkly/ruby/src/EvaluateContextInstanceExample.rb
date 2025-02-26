require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ContextsApi.new.evaluate_context_instance(
        nil, # project_key
        nil, # environment_key
        JSON.parse(<<-EOD
            {
                "key": "user-key-123abc",
                "kind": "user",
                "otherAttribute": "other attribute value"
            }
            EOD
        ), # request_body
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#evaluate_context_instance: #{e}"
end
