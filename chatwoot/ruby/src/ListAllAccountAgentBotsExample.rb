require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AccountAgentBotsApi.new.list_all_account_agent_bots(
        0, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#list_all_account_agent_bots: #{e}"
end
