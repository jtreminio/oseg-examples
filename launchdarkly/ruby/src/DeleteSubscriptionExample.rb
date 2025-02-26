require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.delete_subscription(
        nil, # integration_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptionsApi#delete_subscription: #{e}"
end
