require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::AccountAgentBotsApi.new.delete_an_account_agent_bot(
        nil, # account_id
        nil, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#delete_an_account_agent_bot: #{e}"
end
