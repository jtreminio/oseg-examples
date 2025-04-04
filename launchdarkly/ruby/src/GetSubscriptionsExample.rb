require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.get_subscriptions(
        "integrationKey_string", # integration_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptionsApi#get_subscriptions: #{e}"
end
