require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::WebhooksApi.new.delete_a_webhook(
        0, # account_id
        0, # webhook_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling WebhooksApi#delete_a_webhook: #{e}"
end
