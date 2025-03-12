require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

message_template_params = ChatwootClient::NewConversationRequestMessageTemplateParams.new
message_template_params.name = "sample_issue_resolution"
message_template_params.category = "UTILITY"
message_template_params.language = "en_US"

message = ChatwootClient::NewConversationRequestMessage.new
message.content = nil
message.template_params = message_template_params

new_conversation_request = ChatwootClient::NewConversationRequest.new
new_conversation_request.inbox_id = nil
new_conversation_request.source_id = nil
new_conversation_request.contact_id = nil
new_conversation_request.status = nil
new_conversation_request.assignee_id = nil
new_conversation_request.team_id = nil
new_conversation_request.message = message

begin
    response = ChatwootClient::ConversationsApi.new.new_conversation(
        nil, # account_id
        new_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#new_conversation: #{e}"
end
