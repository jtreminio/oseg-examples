require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::PersistentStoreIntegrationsBetaApi.new.get_big_segment_store_integration(
        nil, # project_key
        nil, # environment_key
        nil, # integration_key
        nil, # integration_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling PersistentStoreIntegrationsBetaApi#get_big_segment_store_integration: #{e}"
end
