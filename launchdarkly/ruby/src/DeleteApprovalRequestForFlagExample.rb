require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApprovalsApi.new.delete_approval_request_for_flag(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Approvals#delete_approval_request_for_flag: #{e}"
end
