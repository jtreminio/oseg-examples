require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AgentBotsApi.new.get_details_of_a_single_agent_bot(
        nil, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentBotsApi#get_details_of_a_single_agent_bot: #{e}"
end
