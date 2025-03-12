require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
end

assign_a_conversation_request = ChatwootClient::AssignAConversationRequest.new
assign_a_conversation_request.assignee_id = nil
assign_a_conversation_request.team_id = nil

begin
    response = ChatwootClient::ConversationAssignmentApi.new.assign_a_conversation(
        nil, # account_id
        nil, # conversation_id
        assign_a_conversation_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationAssignmentApi#assign_a_conversation: #{e}"
end
