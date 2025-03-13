require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::WebhooksApi.new.delete_webhook(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WebhooksApi#delete_webhook: #{e}"
end
