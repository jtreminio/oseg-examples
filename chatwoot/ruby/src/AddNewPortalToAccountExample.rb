require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

portal_create_update_payload = ChatwootClient::PortalCreateUpdatePayload.new
portal_create_update_payload.archived = nil
portal_create_update_payload.color = "add color HEX string, \"#fffff\""
portal_create_update_payload.custom_domain = "https://chatwoot.help/."
portal_create_update_payload.header_text = "Handbook"
portal_create_update_payload.homepage_link = "https://www.chatwoot.com/"
portal_create_update_payload.name = nil
portal_create_update_payload.slug = nil
portal_create_update_payload.page_title = nil
portal_create_update_payload.account_id = nil

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_portal_to_account(
        nil, # account_id
        portal_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_portal_to_account: #{e}"
end
