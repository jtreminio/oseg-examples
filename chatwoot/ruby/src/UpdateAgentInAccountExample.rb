require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

update_agent_in_account_request = ChatwootClient::UpdateAgentInAccountRequest.new
update_agent_in_account_request.role = nil
update_agent_in_account_request.availability = nil
update_agent_in_account_request.auto_offline = nil

begin
    response = ChatwootClient::AgentsApi.new.update_agent_in_account(
        nil, # account_id
        nil, # id
        update_agent_in_account_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#update_agent_in_account: #{e}"
end
