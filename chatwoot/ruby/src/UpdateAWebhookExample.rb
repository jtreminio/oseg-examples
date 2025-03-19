require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

webhook_create_update_payload = ChatwootClient::WebhookCreateUpdatePayload.new
webhook_create_update_payload.subscriptions = [
]

begin
    response = ChatwootClient::WebhooksApi.new.update_a_webhook(
        0, # account_id
        0, # webhook_id
        webhook_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling WebhooksApi#update_a_webhook: #{e}"
end
