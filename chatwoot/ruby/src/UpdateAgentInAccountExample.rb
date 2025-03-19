require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

update_agent_in_account_request = ChatwootClient::UpdateAgentInAccountRequest.new
update_agent_in_account_request.role = "agent"

begin
    response = ChatwootClient::AgentsApi.new.update_agent_in_account(
        0, # account_id
        0, # id
        update_agent_in_account_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#update_agent_in_account: #{e}"
end
