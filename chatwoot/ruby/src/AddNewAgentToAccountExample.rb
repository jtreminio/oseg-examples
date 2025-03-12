require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

add_new_agent_to_account_request = ChatwootClient::AddNewAgentToAccountRequest.new
add_new_agent_to_account_request.email = nil
add_new_agent_to_account_request.name = nil
add_new_agent_to_account_request.role = nil
add_new_agent_to_account_request.availability_status = nil
add_new_agent_to_account_request.auto_offline = nil

begin
    response = ChatwootClient::AgentsApi.new.add_new_agent_to_account(
        nil, # account_id
        add_new_agent_to_account_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#add_new_agent_to_account: #{e}"
end
