require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ApplicationsBetaApi.new.get_application_versions(
        "applicationKey_string", # application_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBetaApi#get_application_versions: #{e}"
end
