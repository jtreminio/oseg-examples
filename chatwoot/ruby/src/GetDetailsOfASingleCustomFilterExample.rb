require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::CustomFiltersApi.new.get_details_of_a_single_custom_filter(
        nil, # account_id
        nil, # custom_filter_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling CustomFiltersApi#get_details_of_a_single_custom_filter: #{e}"
end
