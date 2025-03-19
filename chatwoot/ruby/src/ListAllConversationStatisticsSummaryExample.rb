require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::ReportsApi.new.list_all_conversation_statistics_summary(
        0, # account_id
        "account", # type
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling ReportsApi#list_all_conversation_statistics_summary: #{e}"
end
