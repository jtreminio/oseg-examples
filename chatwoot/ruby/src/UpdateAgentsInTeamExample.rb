require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

update_agents_in_team_request = ChatwootClient::UpdateAgentsInTeamRequest.new
update_agents_in_team_request.user_ids = [
]

begin
    response = ChatwootClient::TeamsApi.new.update_agents_in_team(
        nil, # account_id
        nil, # team_id
        update_agents_in_team_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#update_agents_in_team: #{e}"
end
