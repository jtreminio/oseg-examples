require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_message_create_payload = ChatwootClient::PublicMessageCreatePayload.new

begin
    response = ChatwootClient::MessagesAPIApi.new.create_a_message(
        "inbox_identifier_string", # inbox_identifier
        "contact_identifier_string", # contact_identifier
        0, # conversation_id
        public_message_create_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesAPIApi#create_a_message: #{e}"
end
