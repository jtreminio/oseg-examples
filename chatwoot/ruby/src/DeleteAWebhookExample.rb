require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::WebhooksApi.new.delete_a_webhook(
        nil, # account_id
        nil, # webhook_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling WebhooksApi#delete_a_webhook: #{e}"
end
