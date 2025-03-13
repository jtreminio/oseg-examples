require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ContextsApi.new.get_contexts(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "kind_string", # kind
        "key_string", # key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#get_contexts: #{e}"
end
