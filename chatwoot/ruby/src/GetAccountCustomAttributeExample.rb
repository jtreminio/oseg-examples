require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::CustomAttributesApi.new.get_account_custom_attribute(
        nil, # account_id
        nil, # attribute_model
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#get_account_custom_attribute: #{e}"
end
