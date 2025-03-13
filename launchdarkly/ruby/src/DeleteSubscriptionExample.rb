require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.delete_subscription(
        "integrationKey_string", # integration_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptionsApi#delete_subscription: #{e}"
end
