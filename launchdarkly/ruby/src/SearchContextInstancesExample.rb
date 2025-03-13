require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

context_instance_search = LaunchDarklyClient::ContextInstanceSearch.new
context_instance_search.filter = "{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}"
context_instance_search.sort = "-ts"
context_instance_search.limit = 10
context_instance_search.continuation_token = "QAGFKH1313KUGI2351"

begin
    response = LaunchDarklyClient::ContextsApi.new.search_context_instances(
        nil, # project_key
        nil, # environment_key
        context_instance_search,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ContextsApi#search_context_instances: #{e}"
end
