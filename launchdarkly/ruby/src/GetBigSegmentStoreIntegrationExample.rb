require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::PersistentStoreIntegrationsBetaApi.new.get_big_segment_store_integration(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "integrationKey_string", # integration_key
        "integrationId_string", # integration_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling PersistentStoreIntegrationsBetaApi#get_big_segment_store_integration: #{e}"
end
