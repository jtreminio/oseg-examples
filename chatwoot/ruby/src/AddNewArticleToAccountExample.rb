require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

article_create_update_payload = ChatwootClient::ArticleCreateUpdatePayload.new
article_create_update_payload.meta = JSON.parse(<<-EOD
    {
        "description": "article description",
        "tags": [
            "article_name"
        ],
        "title": "article title"
    }
    EOD
)

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_article_to_account(
        0, # account_id
        0, # portal_id
        article_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_article_to_account: #{e}"
end
