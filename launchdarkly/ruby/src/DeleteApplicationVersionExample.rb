require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApplicationsBetaApi.new.delete_application_version(
        "applicationKey_string", # application_key
        "versionKey_string", # version_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBetaApi#delete_application_version: #{e}"
end
