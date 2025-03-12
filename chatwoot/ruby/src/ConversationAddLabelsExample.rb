require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

conversation_add_labels_request = ChatwootClient::ConversationAddLabelsRequest.new
conversation_add_labels_request.labels = [
]

begin
    response = ChatwootClient::ConversationLabelsApi.new.conversation_add_labels(
        nil, # account_id
        nil, # conversation_id
        conversation_add_labels_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationLabelsApi#conversation_add_labels: #{e}"
end
