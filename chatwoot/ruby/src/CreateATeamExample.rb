require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
    # config.api_key["agentBotApiKey"] = "AGENT_BOT_API_KEY"
    # config.api_key["platformAppApiKey"] = "PLATFORM_APP_API_KEY"
end

team_create_update_payload = ChatwootClient::TeamCreateUpdatePayload.new
team_create_update_payload.name = nil
team_create_update_payload.description = nil
team_create_update_payload.allow_auto_assign = nil

begin
    response = ChatwootClient::TeamsApi.new.create_a_team(
        nil, # account_id
        team_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#create_a_team: #{e}"
end
