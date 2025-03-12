require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

update_conversation_request = ChatwootClient::UpdateConversationRequest.new
update_conversation_request.priority = nil
update_conversation_request.sla_policy_id = nil

begin
    ChatwootClient::ConversationsApi.new.update_conversation(
        nil, # account_id
        nil, # conversation_id
        update_conversation_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#update_conversation: #{e}"
end
