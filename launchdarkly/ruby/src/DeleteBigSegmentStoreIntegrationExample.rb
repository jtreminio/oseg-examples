require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::PersistentStoreIntegrationsBetaApi.new.delete_big_segment_store_integration(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "integrationKey_string", # integration_key
        "integrationId_string", # integration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling PersistentStoreIntegrationsBetaApi#delete_big_segment_store_integration: #{e}"
end
