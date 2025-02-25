require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

team_post_input = LaunchDarklyClient::TeamPostInput.new
team_post_input.key = "team-key-123abc"
team_post_input.name = "Example team"
team_post_input.description = "An example team"
team_post_input.custom_role_keys = [
    "example-role1",
    "example-role2",
]
team_post_input.member_ids = [
    "12ab3c45de678910fgh12345",
]

begin
    response = LaunchDarklyClient::TeamsApi.new.post_team(
        team_post_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Teams#post_team: #{e}"
end
