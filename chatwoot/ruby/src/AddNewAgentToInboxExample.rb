require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

add_new_agent_to_inbox_request = ChatwootClient::AddNewAgentToInboxRequest.new
add_new_agent_to_inbox_request.inbox_id = nil
add_new_agent_to_inbox_request.user_ids = [
]

begin
    response = ChatwootClient::InboxesApi.new.add_new_agent_to_inbox(
        nil, # account_id
        add_new_agent_to_inbox_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#add_new_agent_to_inbox: #{e}"
end
