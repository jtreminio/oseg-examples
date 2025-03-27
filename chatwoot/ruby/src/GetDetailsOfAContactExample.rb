require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

begin
    response = ChatwootClient::ContactsAPIApi.new.get_details_of_a_contact(
        "inbox_identifier_string", # inbox_identifier
        "contact_identifier_string", # contact_identifier
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsAPIApi#get_details_of_a_contact: #{e}"
end
