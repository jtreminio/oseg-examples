require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

contact_create = ChatwootClient::ContactCreate.new
contact_create.inbox_id = nil
contact_create.name = nil
contact_create.email = nil
contact_create.phone_number = nil
contact_create.avatar_url = nil
contact_create.identifier = nil
contact_create.avatar = nil

begin
    response = ChatwootClient::ContactsApi.new.contact_create(
        nil, # account_id
        contact_create, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_create: #{e}"
end
