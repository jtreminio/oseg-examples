require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

post_approval_request_apply_request = LaunchDarklyClient::PostApprovalRequestApplyRequest.new
post_approval_request_apply_request.comment = "Looks good, thanks for updating"

begin
    response = LaunchDarklyClient::ApprovalsApi.new.post_approval_request_apply_for_flag(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
        post_approval_request_apply_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#post_approval_request_apply_for_flag: #{e}"
end
