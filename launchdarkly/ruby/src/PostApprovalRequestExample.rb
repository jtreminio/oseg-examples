require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

create_approval_request_request = LaunchDarklyClient::CreateApprovalRequestRequest.new
create_approval_request_request.resource_id = "proj/projKey:env/envKey:flag/flagKey"
create_approval_request_request.description = "Requesting to update targeting"
create_approval_request_request.instructions = []
create_approval_request_request.comment = "optional comment"
create_approval_request_request.notify_member_ids = [
    "1234a56b7c89d012345e678f",
]
create_approval_request_request.notify_team_keys = [
    "example-reviewer-team",
]

begin
    response = LaunchDarklyClient::ApprovalsApi.new.post_approval_request(
        create_approval_request_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#post_approval_request: #{e}"
end
