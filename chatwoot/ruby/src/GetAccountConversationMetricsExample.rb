require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ReportsApi.new.get_account_conversation_metrics(
        nil, # account_id
        nil, # type
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ReportsApi#get_account_conversation_metrics: #{e}"
end
