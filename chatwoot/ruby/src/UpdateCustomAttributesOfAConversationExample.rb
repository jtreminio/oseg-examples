require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

update_custom_attributes_of_a_conversation_request = ChatwootClient::UpdateCustomAttributesOfAConversationRequest.new
update_custom_attributes_of_a_conversation_request.custom_attributes = JSON.parse(<<-EOD
    {
        "order_id": "12345",
        "previous_conversation": "67890"
    }
    EOD
)

begin
    response = ChatwootClient::ConversationsApi.new.update_custom_attributes_of_a_conversation(
        0, # account_id
        0, # conversation_id
        update_custom_attributes_of_a_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#update_custom_attributes_of_a_conversation: #{e}"
end
