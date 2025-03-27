require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
end

payload_1 = ChatwootClient::ContactFilterRequestPayloadInner.new
payload_1.attribute_key = "name"
payload_1.filter_operator = "equal_to"
payload_1.query_operator = "AND"
payload_1.values = [
    "en",
]

payload_2 = ChatwootClient::ContactFilterRequestPayloadInner.new
payload_2.attribute_key = "country_code"
payload_2.filter_operator = "equal_to"
payload_2.values = [
    "us",
]

payload = [
    payload_1,
    payload_2,
]

contact_filter_request = ChatwootClient::ContactFilterRequest.new
contact_filter_request.payload = payload

begin
    response = ChatwootClient::ContactsApi.new.contact_filter(
        0, # account_id
        contact_filter_request, # body
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_filter: #{e}"
end
