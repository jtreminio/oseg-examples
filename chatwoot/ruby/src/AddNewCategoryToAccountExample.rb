require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

category_create_update_payload = ChatwootClient::CategoryCreateUpdatePayload.new
category_create_update_payload.description = nil
category_create_update_payload.locale = "en/es"
category_create_update_payload.name = nil
category_create_update_payload.slug = nil
category_create_update_payload.position = nil
category_create_update_payload.portal_id = nil
category_create_update_payload.account_id = nil
category_create_update_payload.associated_category_id = nil
category_create_update_payload.parent_category_id = nil

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_category_to_account(
        nil, # account_id
        nil, # portal_id
        category_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_category_to_account: #{e}"
end
