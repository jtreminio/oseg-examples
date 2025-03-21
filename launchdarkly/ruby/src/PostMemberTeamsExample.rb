require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

member_teams_post_input = LaunchDarklyClient::MemberTeamsPostInput.new
member_teams_post_input.team_keys = [
    "team1",
    "team2",
]

begin
    response = LaunchDarklyClient::AccountMembersApi.new.post_member_teams(
        "id_string", # id
        member_teams_post_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#post_member_teams: #{e}"
end
