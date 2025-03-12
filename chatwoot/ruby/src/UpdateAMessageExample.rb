require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_message_update_payload = ChatwootClient::PublicMessageUpdatePayload.new

begin
    response = ChatwootClient::MessagesAPIApi.new.update_a_message(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
        nil, # message_id
        public_message_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesAPIApi#update_a_message: #{e}"
end
