require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

update_conversation_request = ChatwootClient::UpdateConversationRequest.new

begin
    ChatwootClient::ConversationsApi.new.update_conversation(
        0, # account_id
        0, # conversation_id
        update_conversation_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#update_conversation: #{e}"
end
