require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
    # config.api_key["api_access_token"] = "AGENT_BOT_API_KEY"
    # config.api_key["api_access_token"] = "PLATFORM_APP_API_KEY"
end

team_create_update_payload = ChatwootClient::TeamCreateUpdatePayload.new

begin
    response = ChatwootClient::TeamsApi.new.update_a_team(
        0, # account_id
        0, # team_id
        team_create_update_payload, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#update_a_team: #{e}"
end
