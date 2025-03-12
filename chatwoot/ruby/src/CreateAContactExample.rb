require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_contact_create_update_payload = ChatwootClient::PublicContactCreateUpdatePayload.new
public_contact_create_update_payload.identifier = nil
public_contact_create_update_payload.identifier_hash = nil
public_contact_create_update_payload.email = nil
public_contact_create_update_payload.name = nil
public_contact_create_update_payload.phone_number = nil
public_contact_create_update_payload.avatar_url = nil

begin
    response = ChatwootClient::ContactsAPIApi.new.create_a_contact(
        nil, # inbox_identifier
        public_contact_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsAPIApi#create_a_contact: #{e}"
end
