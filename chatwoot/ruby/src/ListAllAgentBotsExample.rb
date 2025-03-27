require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AgentBotsApi.new.list_all_agent_bots

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#list_all_agent_bots: #{e}"
end
