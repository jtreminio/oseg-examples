require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ContextsApi.new.delete_context_instances(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#delete_context_instances: #{e}"
end
