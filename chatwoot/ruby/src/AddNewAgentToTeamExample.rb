require "json"
require "chatwoot_client"

ChatwootClient.configure do |config|
    config.api_key["userApiKey"] = "USER_API_KEY"
end

add_new_agent_to_team_request = ChatwootClient::AddNewAgentToTeamRequest.new
add_new_agent_to_team_request.user_ids = [
]

begin
    response = ChatwootClient::TeamsApi.new.add_new_agent_to_team(
        nil, # account_id
        nil, # team_id
        add_new_agent_to_team_request, # data
    )

    p response
rescue ChatwootClient::ApiError => e
    puts "Exception when calling TeamsApi#add_new_agent_to_team: #{e}"
end
