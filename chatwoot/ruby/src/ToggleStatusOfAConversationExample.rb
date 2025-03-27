require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

toggle_status_of_a_conversation_request = ChatwootClient::ToggleStatusOfAConversationRequest.new
toggle_status_of_a_conversation_request.status = "open"

begin
    response = ChatwootClient::ConversationsApi.new.toggle_status_of_a_conversation(
        0, # account_id
        0, # conversation_id
        toggle_status_of_a_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#toggle_status_of_a_conversation: #{e}"
end
