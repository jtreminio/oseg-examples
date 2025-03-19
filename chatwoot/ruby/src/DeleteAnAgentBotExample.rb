require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::AgentBotsApi.new.delete_an_agent_bot(
        0, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#delete_an_agent_bot: #{e}"
end
