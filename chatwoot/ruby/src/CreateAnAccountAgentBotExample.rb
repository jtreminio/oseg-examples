require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

agent_bot_create_update_payload = ChatwootClient::AgentBotCreateUpdatePayload.new

begin
    response = ChatwootClient::AccountAgentBotsApi.new.create_an_account_agent_bot(
        0, # account_id
        agent_bot_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#create_an_account_agent_bot: #{e}"
end
