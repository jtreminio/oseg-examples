require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_message_create_payload = ChatwootClient::PublicMessageCreatePayload.new
public_message_create_payload.content = nil
public_message_create_payload.echo_id = nil

begin
    response = ChatwootClient::MessagesAPIApi.new.create_a_message(
        nil, # inbox_identifier
        nil, # contact_identifier
        nil, # conversation_id
        public_message_create_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling MessagesAPIApi#create_a_message: #{e}"
end
