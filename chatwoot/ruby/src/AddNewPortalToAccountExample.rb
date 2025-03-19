require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

portal_create_update_payload = ChatwootClient::PortalCreateUpdatePayload.new
portal_create_update_payload.color = "add color HEX string, \"#fffff\""
portal_create_update_payload.custom_domain = "https://chatwoot.help/."
portal_create_update_payload.header_text = "Handbook"
portal_create_update_payload.homepage_link = "https://www.chatwoot.com/"
portal_create_update_payload.config = JSON.parse(<<-EOD
    {
        "allowed_locales": [
            "en",
            "es"
        ],
        "default_locale": "en"
    }
    EOD
)

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_portal_to_account(
        0, # account_id
        portal_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_portal_to_account: #{e}"
end
