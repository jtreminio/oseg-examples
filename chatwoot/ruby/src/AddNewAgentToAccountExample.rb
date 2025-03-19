require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

add_new_agent_to_account_request = ChatwootClient::AddNewAgentToAccountRequest.new
add_new_agent_to_account_request.email = "email_string"
add_new_agent_to_account_request.name = "name_string"
add_new_agent_to_account_request.role = "agent"

begin
    response = ChatwootClient::AgentsApi.new.add_new_agent_to_account(
        0, # account_id
        add_new_agent_to_account_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AgentsApi#add_new_agent_to_account: #{e}"
end
