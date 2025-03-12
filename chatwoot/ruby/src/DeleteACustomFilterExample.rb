require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::CustomFiltersApi.new.delete_a_custom_filter(
        nil, # account_id
        nil, # custom_filter_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomFiltersApi#delete_a_custom_filter: #{e}"
end
