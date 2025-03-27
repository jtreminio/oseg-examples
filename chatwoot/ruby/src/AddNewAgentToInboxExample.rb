require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

add_new_agent_to_inbox_request = ChatwootClient::AddNewAgentToInboxRequest.new
add_new_agent_to_inbox_request.inbox_id = "inbox_id_string"
add_new_agent_to_inbox_request.user_ids = [
]

begin
    response = ChatwootClient::InboxesApi.new.add_new_agent_to_inbox(
        0, # account_id
        add_new_agent_to_inbox_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#add_new_agent_to_inbox: #{e}"
end
