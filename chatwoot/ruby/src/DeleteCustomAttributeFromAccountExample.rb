require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

begin
    ChatwootClient::CustomAttributesApi.new.delete_custom_attribute_from_account(
        0, # account_id
        0, # id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomAttributesApi#delete_custom_attribute_from_account: #{e}"
end
