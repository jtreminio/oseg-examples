require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

category_create_update_payload = ChatwootClient::CategoryCreateUpdatePayload.new
category_create_update_payload.locale = "en/es"

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_category_to_account(
        0, # account_id
        0, # portal_id
        category_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_category_to_account: #{e}"
end
