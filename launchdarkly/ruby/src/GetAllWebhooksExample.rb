require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WebhooksApi.new.get_all_webhooks

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Webhooks#get_all_webhooks: #{e}"
end
