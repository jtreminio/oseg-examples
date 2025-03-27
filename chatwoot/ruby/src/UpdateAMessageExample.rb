require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_message_update_payload = ChatwootClient::PublicMessageUpdatePayload.new

begin
    response = ChatwootClient::MessagesAPIApi.new.update_a_message(
        "inbox_identifier_string", # inbox_identifier
        "contact_identifier_string", # contact_identifier
        0, # conversation_id
        0, # message_id
        public_message_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesAPIApi#update_a_message: #{e}"
end
