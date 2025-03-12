require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsAPIApi.new.list_all_contact_conversations(
        nil, # inbox_identifier
        nil, # contact_identifier
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#list_all_contact_conversations: #{e}"
end
