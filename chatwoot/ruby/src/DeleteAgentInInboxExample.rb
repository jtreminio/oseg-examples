require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

delete_agent_in_inbox_request = ChatwootClient::DeleteAgentInInboxRequest.new
delete_agent_in_inbox_request.inbox_id = nil
delete_agent_in_inbox_request.user_ids = [
]

begin
    ChatwootClient::InboxesApi.new.delete_agent_in_inbox(
        nil, # account_id
        delete_agent_in_inbox_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#delete_agent_in_inbox: #{e}"
end
