require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

members_patch_input = LaunchDarklyClient::MembersPatchInput.new
members_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "replaceMembersRoles",
            "memberIDs": [
                "1234a56b7c89d012345e678f",
                "507f1f77bcf86cd799439011"
            ],
            "value": "reader"
        }
    ]
    EOD
)
members_patch_input.comment = "Optional comment about the update"

begin
    response = LaunchDarklyClient::AccountMembersBetaApi.new.patch_members(
        members_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersBetaApi#patch_members: #{e}"
end
