require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

begin
    response = ChatwootClient::InboxAPIApi.new.get_details_of_a_inbox(
        "inbox_identifier_string", # inbox_identifier
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling InboxAPIApi#get_details_of_a_inbox: #{e}"
end
