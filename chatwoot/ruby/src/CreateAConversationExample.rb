require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
end

public_conversation_create_payload = ChatwootClient::PublicConversationCreatePayload.new

begin
    response = ChatwootClient::ConversationsAPIApi.new.create_a_conversation(
        nil, # inbox_identifier
        nil, # contact_identifier
        public_conversation_create_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsAPIApi#create_a_conversation: #{e}"
end
