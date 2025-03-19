require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

custom_attribute_create_update_payload = ChatwootClient::CustomAttributeCreateUpdatePayload.new
custom_attribute_create_update_payload.attribute_values = [
]

begin
    response = ChatwootClient::CustomAttributesApi.new.add_new_custom_attribute_to_account(
        0, # account_id
        custom_attribute_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#add_new_custom_attribute_to_account: #{e}"
end
