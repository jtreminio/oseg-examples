require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

create_flag_config_approval_request_request = LaunchDarklyClient::CreateFlagConfigApprovalRequestRequest.new
create_flag_config_approval_request_request.description = "Requesting to update targeting"
create_flag_config_approval_request_request.instructions = JSON.parse(<<-EOD
    []
    EOD
)
create_flag_config_approval_request_request.comment = "optional comment"
create_flag_config_approval_request_request.execution_date = 1706701522000
create_flag_config_approval_request_request.operating_on_id = "6297ed79dee7dc14e1f9a80c"
create_flag_config_approval_request_request.notify_member_ids = [
    "1234a56b7c89d012345e678f",
]
create_flag_config_approval_request_request.notify_team_keys = [
    "example-reviewer-team",
]
create_flag_config_approval_request_request.integration_config = nil

begin
    response = LaunchDarklyClient::ApprovalsApi.new.post_approval_request_for_flag(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        create_flag_config_approval_request_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Approvals#post_approval_request_for_flag: #{e}"
end
