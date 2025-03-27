require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_contact_create_update_payload = ChatwootClient::PublicContactCreateUpdatePayload.new

begin
    response = ChatwootClient::ContactsAPIApi.new.create_a_contact(
        "inbox_identifier_string", # inbox_identifier
        public_contact_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsAPIApi#create_a_contact: #{e}"
end
