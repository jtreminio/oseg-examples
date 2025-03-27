require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::TeamsApi.new.delete_a_team(
        0, # account_id
        0, # team_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#delete_a_team: #{e}"
end
