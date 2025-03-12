require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

contact_update = ChatwootClient::ContactUpdate.new
contact_update.name = nil
contact_update.email = nil
contact_update.phone_number = nil
contact_update.avatar_url = nil
contact_update.identifier = nil
contact_update.avatar = nil

begin
    response = ChatwootClient::ContactsApi.new.contact_update(
        nil, # account_id
        nil, # id
        contact_update, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_update: #{e}"
end
