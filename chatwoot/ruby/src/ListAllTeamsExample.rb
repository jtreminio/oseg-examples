require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    response = ChatwootClient::TeamsApi.new.list_all_teams(
        0, # account_id
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#list_all_teams: #{e}"
end
