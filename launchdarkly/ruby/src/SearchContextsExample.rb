require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

context_search = LaunchDarklyClient::ContextSearch.new
context_search.filter = "*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]"
context_search.sort = "-ts"
context_search.limit = 10
context_search.continuation_token = "QAGFKH1313KUGI2351"

begin
    response = LaunchDarklyClient::ContextsApi.new.search_contexts(
        nil, # project_key
        nil, # environment_key
        context_search,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#search_contexts: #{e}"
end
