require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::ConversationsAPIApi.new.toggle_typing_status(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
        nil, # typing_status
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#toggle_typing_status: #{e}"
end
