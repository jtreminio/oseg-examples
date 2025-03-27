require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

contact_create = ChatwootClient::ContactCreate.new
contact_create.inbox_id = (0).to_f

begin
    response = ChatwootClient::ContactsApi.new.contact_create(
        0, # account_id
        contact_create, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_create: #{e}"
end
