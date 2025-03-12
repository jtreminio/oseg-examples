require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

agent_bot_create_update_payload = ChatwootClient::AgentBotCreateUpdatePayload.new
agent_bot_create_update_payload.name = nil
agent_bot_create_update_payload.description = nil
agent_bot_create_update_payload.outgoing_url = nil

begin
    response = ChatwootClient::AccountAgentBotsApi.new.create_an_account_agent_bot(
        nil, # account_id
        agent_bot_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#create_an_account_agent_bot: #{e}"
end
