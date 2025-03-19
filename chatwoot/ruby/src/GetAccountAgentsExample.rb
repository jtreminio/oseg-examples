require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::AgentsApi.new.get_account_agents(
        0, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#get_account_agents: #{e}"
end
