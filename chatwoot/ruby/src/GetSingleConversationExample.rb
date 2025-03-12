require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsAPIApi.new.get_single_conversation(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#get_single_conversation: #{e}"
end
