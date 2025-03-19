require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

agent_bot_create_update_payload = ChatwootClient::AgentBotCreateUpdatePayload.new

begin
    response = ChatwootClient::AgentBotsApi.new.update_an_agent_bot(
        0, # id
        agent_bot_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#update_an_agent_bot: #{e}"
end
