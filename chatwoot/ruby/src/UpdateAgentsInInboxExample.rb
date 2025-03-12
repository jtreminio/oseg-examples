require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

update_agents_in_inbox_request = ChatwootClient::UpdateAgentsInInboxRequest.new
update_agents_in_inbox_request.inbox_id = nil
update_agents_in_inbox_request.user_ids = [
]

begin
    response = ChatwootClient::InboxesApi.new.update_agents_in_inbox(
        nil, # account_id
        update_agents_in_inbox_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#update_agents_in_inbox: #{e}"
end
