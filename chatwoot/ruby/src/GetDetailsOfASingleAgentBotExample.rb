require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AgentBotsApi.new.get_details_of_a_single_agent_bot(
        0, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#get_details_of_a_single_agent_bot: #{e}"
end
