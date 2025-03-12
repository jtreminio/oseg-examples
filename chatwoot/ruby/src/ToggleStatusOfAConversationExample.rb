require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

toggle_status_of_a_conversation_request = ChatwootClient::ToggleStatusOfAConversationRequest.new
toggle_status_of_a_conversation_request.status = nil

begin
    response = ChatwootClient::ConversationsApi.new.toggle_status_of_a_conversation(
        nil, # account_id
        nil, # conversation_id
        toggle_status_of_a_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#toggle_status_of_a_conversation: #{e}"
end
