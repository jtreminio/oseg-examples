require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

begin
    ChatwootClient::TeamsApi.new.delete_a_team(
        nil, # account_id
        nil, # team_id
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#delete_a_team: #{e}"
end
