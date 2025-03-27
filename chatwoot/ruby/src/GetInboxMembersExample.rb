require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::InboxesApi.new.get_inbox_members(
        0, # account_id
        0, # inbox_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxesApi#get_inbox_members: #{e}"
end
