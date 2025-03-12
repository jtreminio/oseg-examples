require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::AgentBotsApi.new.delete_an_agent_bot(
        nil, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#delete_an_agent_bot: #{e}"
end
