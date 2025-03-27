require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

payload_1 = ChatwootClient::ContactFilterRequestPayloadInner.new
payload_1.attribute_key = "browser_language"
payload_1.filter_operator = "not_equal_to"
payload_1.query_operator = "AND"
payload_1.values = [
    "en",
]

payload_2 = ChatwootClient::ContactFilterRequestPayloadInner.new
payload_2.attribute_key = "status"
payload_2.filter_operator = "equal_to"
payload_2.values = [
    "pending",
]

payload = [
    payload_1,
    payload_2,
]

conversation_filter_request = ChatwootClient::ConversationFilterRequest.new
conversation_filter_request.payload = payload

begin
    response = ChatwootClient::ConversationsApi.new.conversation_filter(
        123, # account_id
        conversation_filter_request, # body
        {
            page: 1,
        },
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ConversationsApi#conversation_filter: #{e}"
end
