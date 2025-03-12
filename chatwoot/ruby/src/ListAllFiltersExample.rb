require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::CustomFiltersApi.new.list_all_filters(
        nil, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomFiltersApi#list_all_filters: #{e}"
end
