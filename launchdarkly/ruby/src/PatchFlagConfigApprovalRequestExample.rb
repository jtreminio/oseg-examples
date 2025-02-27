require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApprovalsBetaApi.new.patch_flag_config_approval_request(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsBetaApi#patch_flag_config_approval_request: #{e}"
end
