require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.get_subscription_by_id(
        nil, # integration_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptionsApi#get_subscription_by_id: #{e}"
end
