require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.get_subscription_by_id(
        nil, # integration_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptions#get_subscription_by_id: #{e}"
end
