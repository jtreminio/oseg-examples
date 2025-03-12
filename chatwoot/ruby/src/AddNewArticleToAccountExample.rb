require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

article_create_update_payload = ChatwootClient::ArticleCreateUpdatePayload.new
article_create_update_payload.content = nil
article_create_update_payload.position = nil
article_create_update_payload.status = nil
article_create_update_payload.title = nil
article_create_update_payload.slug = nil
article_create_update_payload.views = nil
article_create_update_payload.portal_id = nil
article_create_update_payload.account_id = nil
article_create_update_payload.author_id = nil
article_create_update_payload.category_id = nil
article_create_update_payload.folder_id = nil
article_create_update_payload.associated_article_id = nil

begin
    response = ChatwootClient::HelpCenterApi.new.add_new_article_to_account(
        nil, # account_id
        nil, # portal_id
        article_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling HelpCenterApi#add_new_article_to_account: #{e}"
end
