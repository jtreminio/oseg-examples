require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

post_approval_request_apply_request = LaunchDarklyClient::PostApprovalRequestApplyRequest.new
post_approval_request_apply_request.comment = "Looks good, thanks for updating"

begin
    response = LaunchDarklyClient::ApprovalsApi.new.post_approval_request_apply(
        "id_string", # id
        post_approval_request_apply_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#post_approval_request_apply: #{e}"
end
