require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApplicationsBetaApi.new.delete_application_version(
        nil, # application_key
        nil, # version_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBetaApi#delete_application_version: #{e}"
end
