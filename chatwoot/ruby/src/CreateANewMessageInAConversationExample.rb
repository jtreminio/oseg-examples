require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

template_params = ChatwootClient::NewConversationRequestMessageTemplateParams.new
template_params.name = "sample_issue_resolution"
template_params.category = "UTILITY"
template_params.language = "en_US"
template_params.processed_params = JSON.parse(<<-EOD
    {
        "1": "Chatwoot"
    }
    EOD
)

conversation_message_create = ChatwootClient::ConversationMessageCreate.new
conversation_message_create.content = "content_string"
conversation_message_create.content_type = "cards"
conversation_message_create.template_params = template_params

begin
    response = ChatwootClient::MessagesApi.new.create_a_new_message_in_a_conversation(
        0, # account_id
        0, # conversation_id
        conversation_message_create, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesApi#create_a_new_message_in_a_conversation: #{e}"
end
