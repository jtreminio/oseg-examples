require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ContextsApi.new.get_context_attribute_values(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "attributeName_string", # attribute_name
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#get_context_attribute_values: #{e}"
end
