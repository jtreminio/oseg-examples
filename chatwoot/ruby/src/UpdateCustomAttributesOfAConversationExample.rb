require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

update_custom_attributes_of_a_conversation_request = ChatwootClient::UpdateCustomAttributesOfAConversationRequest.new

begin
    response = ChatwootClient::ConversationsApi.new.update_custom_attributes_of_a_conversation(
        nil, # account_id
        nil, # conversation_id
        update_custom_attributes_of_a_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#update_custom_attributes_of_a_conversation: #{e}"
end
