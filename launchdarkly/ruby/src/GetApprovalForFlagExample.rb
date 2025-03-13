require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApprovalsApi.new.get_approval_for_flag(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#get_approval_for_flag: #{e}"
end
