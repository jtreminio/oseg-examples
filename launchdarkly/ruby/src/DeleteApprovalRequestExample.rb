require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApprovalsApi.new.delete_approval_request(
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApprovalsApi#delete_approval_request: #{e}"
end
