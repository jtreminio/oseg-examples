require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AccountAgentBotsApi.new.list_all_account_agent_bots(
        nil, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#list_all_account_agent_bots: #{e}"
end
