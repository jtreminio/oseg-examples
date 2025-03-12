require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::InboxesApi.new.get_inbox_members(
        nil, # account_id
        nil, # inbox_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#get_inbox_members: #{e}"
end
