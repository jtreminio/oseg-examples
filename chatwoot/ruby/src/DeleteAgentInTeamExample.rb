require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["api_access_token"] = "USER_API_KEY"
end

delete_agent_in_team_request = ChatwootClient::DeleteAgentInTeamRequest.new
delete_agent_in_team_request.user_ids = [
]

begin
    ChatwootClient::TeamsApi.new.delete_agent_in_team(
        0, # account_id
        0, # team_id
        delete_agent_in_team_request, # data
    )
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#delete_agent_in_team: #{e}"
end
