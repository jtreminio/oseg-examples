require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::WebhooksApi.new.get_webhook(
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Webhooks#get_webhook: #{e}"
end
