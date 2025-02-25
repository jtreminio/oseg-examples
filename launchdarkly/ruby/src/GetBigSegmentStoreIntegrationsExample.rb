require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::PersistentStoreIntegrationsBetaApi.new.get_big_segment_store_integrations

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling PersistentStoreIntegrationsBeta#get_big_segment_store_integrations: #{e}"
end
