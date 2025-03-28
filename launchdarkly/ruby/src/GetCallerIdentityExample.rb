require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::OtherApi.new.get_caller_identity

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OtherApi#get_caller_identity: #{e}"
end
