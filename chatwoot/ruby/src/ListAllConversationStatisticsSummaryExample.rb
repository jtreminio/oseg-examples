require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ReportsApi.new.list_all_conversation_statistics_summary(
        nil, # account_id
        nil, # type
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ReportsApi#list_all_conversation_statistics_summary: #{e}"
end
