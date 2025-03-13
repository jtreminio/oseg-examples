require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

source = LaunchDarklyClient::SourceFlag.new
source.key = "environment-key-123abc"
source.version = 1

create_copy_flag_config_approval_request_request = LaunchDarklyClient::CreateCopyFlagConfigApprovalRequestRequest.new
create_copy_flag_config_approval_request_request.description = "copy flag settings to another environment"
create_copy_flag_config_approval_request_request.comment = "optional comment"
create_copy_flag_config_approval_request_request.notify_member_ids = [
    "1234a56b7c89d012345e678f",
]
create_copy_flag_config_approval_request_request.notify_team_keys = [
    "example-reviewer-team",
]
create_copy_flag_config_approval_request_request.included_actions = [
    "updateOn",
]
create_copy_flag_config_approval_request_request.excluded_actions = [
    "updateOn",
]
create_copy_flag_config_approval_request_request.source = source

begin
    response = LaunchDarklyClient::ApprovalsApi.new.post_flag_copy_config_approval_request(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        create_copy_flag_config_approval_request_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#post_flag_copy_config_approval_request: #{e}"
end
