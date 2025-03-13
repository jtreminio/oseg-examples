require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::PersistentStoreIntegrationsBetaApi.new.delete_big_segment_store_integration(
        nil, # project_key
        nil, # environment_key
        nil, # integration_key
        nil, # integration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling PersistentStoreIntegrationsBetaApi#delete_big_segment_store_integration: #{e}"
end
