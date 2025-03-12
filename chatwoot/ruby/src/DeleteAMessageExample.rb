require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::MessagesApi.new.delete_a_message(
        nil, # account_id
        nil, # conversation_id
        nil, # message_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesApi#delete_a_message: #{e}"
end
