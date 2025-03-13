require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApplicationsBetaApi.new.delete_application(
        nil, # application_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBetaApi#delete_application: #{e}"
end
