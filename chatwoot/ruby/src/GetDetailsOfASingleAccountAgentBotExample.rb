require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::AccountAgentBotsApi.new.get_details_of_a_single_account_agent_bot(
        0, # account_id
        0, # id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling AccountAgentBotsApi#get_details_of_a_single_account_agent_bot: #{e}"
end
