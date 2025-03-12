require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

custom_attribute_create_update_payload = ChatwootClient::CustomAttributeCreateUpdatePayload.new
custom_attribute_create_update_payload.attribute_display_name = nil
custom_attribute_create_update_payload.attribute_display_type = nil
custom_attribute_create_update_payload.attribute_description = nil
custom_attribute_create_update_payload.attribute_key = nil
custom_attribute_create_update_payload.attribute_model = nil
custom_attribute_create_update_payload.attribute_values = [
]

begin
    response = ChatwootClient::CustomAttributesApi.new.update_custom_attribute_in_account(
        nil, # account_id
        nil, # id
        custom_attribute_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#update_custom_attribute_in_account: #{e}"
end
