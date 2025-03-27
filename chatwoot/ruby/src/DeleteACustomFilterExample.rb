require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::CustomFiltersApi.new.delete_a_custom_filter(
        0, # account_id
        0, # custom_filter_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomFiltersApi#delete_a_custom_filter: #{e}"
end
