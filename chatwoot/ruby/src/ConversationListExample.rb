require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ConversationsApi.new.conversation_list(
        0, # account_id
        {
            assignee_type: "all",
            status: "open",
            q: nil,
            inbox_id: nil,
            team_id: nil,
            labels: nil,
            page: 1,
        },
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#conversation_list: #{e}"
end
