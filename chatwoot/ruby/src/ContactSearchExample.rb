require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ContactsApi.new.contact_search(
        nil, # account_id
        {
            q: nil,
            sort: nil,
            page: 1,
        },
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ContactsApi#contact_search: #{e}"
end
