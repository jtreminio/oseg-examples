require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    response = ChatwootClient::CustomAttributesApi.new.get_account_custom_attribute(
        0, # account_id
        "0", # attribute_model
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#get_account_custom_attribute: #{e}"
end
