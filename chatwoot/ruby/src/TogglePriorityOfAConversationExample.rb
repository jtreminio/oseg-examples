require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

toggle_priority_of_a_conversation_request = ChatwootClient::TogglePriorityOfAConversationRequest.new
toggle_priority_of_a_conversation_request.priority = "urgent"

begin
    ChatwootClient::ConversationsApi.new.toggle_priority_of_a_conversation(
        0, # account_id
        0, # conversation_id
        toggle_priority_of_a_conversation_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#toggle_priority_of_a_conversation: #{e}"
end
