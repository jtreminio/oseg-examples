require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

member_teams_post_input = LaunchDarklyClient::MemberTeamsPostInput.new
member_teams_post_input.team_keys = [
    "team1",
    "team2",
]

begin
    response = LaunchDarklyClient::AccountMembersApi.new.post_member_teams(
        nil, # id
        member_teams_post_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembers#post_member_teams: #{e}"
end
