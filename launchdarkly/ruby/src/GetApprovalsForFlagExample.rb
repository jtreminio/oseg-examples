require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApprovalsApi.new.get_approvals_for_flag(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#get_approvals_for_flag: #{e}"
end
