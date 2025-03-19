require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

message_template_params = ChatwootClient::NewConversationRequestMessageTemplateParams.new
message_template_params.name = "sample_issue_resolution"
message_template_params.category = "UTILITY"
message_template_params.language = "en_US"
message_template_params.processed_params = JSON.parse(<<-EOD
    {
        "1": "Chatwoot"
    }
    EOD
)

message = ChatwootClient::NewConversationRequestMessage.new
message.content = "content_string"
message.template_params = message_template_params

new_conversation_request = ChatwootClient::NewConversationRequest.new
new_conversation_request.inbox_id = "inbox_id_string"
new_conversation_request.source_id = "source_id_string"
new_conversation_request.custom_attributes = JSON.parse(<<-EOD
    {
        "attribute_key": "attribute_value",
        "priority_conversation_number": 3
    }
    EOD
)
new_conversation_request.message = message

begin
    response = ChatwootClient::ConversationsApi.new.new_conversation(
        0, # account_id
        new_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#new_conversation: #{e}"
end
