require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApplicationsBetaApi.new.get_applications

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBetaApi#get_applications: #{e}"
end
