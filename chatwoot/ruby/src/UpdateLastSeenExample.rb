require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::ConversationsAPIApi.new.update_last_seen(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#update_last_seen: #{e}"
end
