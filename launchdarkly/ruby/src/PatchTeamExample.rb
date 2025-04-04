require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

team_patch_input = LaunchDarklyClient::TeamPatchInput.new
team_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "updateDescription",
            "value": "New description for the team"
        }
    ]
    EOD
)
team_patch_input.comment = "Optional comment about the update"

begin
    response = LaunchDarklyClient::TeamsApi.new.patch_team(
        "teamKey_string", # team_key
        team_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#patch_team: #{e}"
end
