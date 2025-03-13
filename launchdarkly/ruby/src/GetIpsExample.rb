require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::OtherApi.new.get_ips

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OtherApi#get_ips: #{e}"
end
