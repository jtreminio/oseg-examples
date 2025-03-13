require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApprovalsApi.new.get_approvals_for_flag(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#get_approvals_for_flag: #{e}"
end
