require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsApi.new.conversation_list_meta(
        nil, # account_id
        {
            status: "open",
            q: nil,
            inbox_id: nil,
            team_id: nil,
            labels: nil,
        },
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#conversation_list_meta: #{e}"
end
