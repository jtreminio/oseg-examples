require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApprovalsApi.new.delete_approval_request(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Approvals#delete_approval_request: #{e}"
end
