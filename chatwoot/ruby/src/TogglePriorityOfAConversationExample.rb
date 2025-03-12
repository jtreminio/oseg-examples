require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

toggle_priority_of_a_conversation_request = ChatwootClient::TogglePriorityOfAConversationRequest.new
toggle_priority_of_a_conversation_request.priority = nil

begin
    ChatwootClient::ConversationsApi.new.toggle_priority_of_a_conversation(
        nil, # account_id
        nil, # conversation_id
        toggle_priority_of_a_conversation_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#toggle_priority_of_a_conversation: #{e}"
end
