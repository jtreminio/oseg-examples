require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

teams_patch_input = LaunchDarklyClient::TeamsPatchInput.new
teams_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "addMembersToTeams",
            "memberIDs": [
                "1234a56b7c89d012345e678f"
            ],
            "teamKeys": [
                "example-team-1",
                "example-team-2"
            ]
        }
    ]
    EOD
)
teams_patch_input.comment = "Optional comment about the update"

begin
    response = LaunchDarklyClient::TeamsBetaApi.new.patch_teams(
        teams_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsBetaApi#patch_teams: #{e}"
end
