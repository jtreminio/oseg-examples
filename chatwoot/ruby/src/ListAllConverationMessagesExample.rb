require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::MessagesAPIApi.new.list_all_converation_messages(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesAPIApi#list_all_converation_messages: #{e}"
end
