require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ContextsApi.new.get_context_attribute_values(
        nil, # project_key
        nil, # environment_key
        nil, # attribute_name
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Contexts#get_context_attribute_values: #{e}"
end
