require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

custom_attribute_create_update_payload = ChatwootClient::CustomAttributeCreateUpdatePayload.new
custom_attribute_create_update_payload.attribute_values = [
]

begin
    response = ChatwootClient::CustomAttributesApi.new.update_custom_attribute_in_account(
        0, # account_id
        0, # id
        custom_attribute_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#update_custom_attribute_in_account: #{e}"
end
