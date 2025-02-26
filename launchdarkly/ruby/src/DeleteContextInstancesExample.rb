require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ContextsApi.new.delete_context_instances(
        nil, # project_key
        nil, # environment_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#delete_context_instances: #{e}"
end
