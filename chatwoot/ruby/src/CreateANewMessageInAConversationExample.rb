require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

template_params = ChatwootClient::ConversationMessageCreateTemplateParams.new
template_params.name = "sample_issue_resolution"
template_params.category = "UTILITY"
template_params.language = "en_US"

conversation_message_create = ChatwootClient::ConversationMessageCreate.new
conversation_message_create.content = nil
conversation_message_create.message_type = nil
conversation_message_create.private = nil
conversation_message_create.content_type = "cards"
conversation_message_create.template_params = template_params

begin
    response = ChatwootClient::MessagesApi.new.create_a_new_message_in_a_conversation(
        nil, # account_id
        nil, # conversation_id
        conversation_message_create, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesApi#create_a_new_message_in_a_conversation: #{e}"
end
