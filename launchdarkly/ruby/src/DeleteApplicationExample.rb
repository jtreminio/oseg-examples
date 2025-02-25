require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ApplicationsBetaApi.new.delete_application(
        nil, # application_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ApplicationsBeta#delete_application: #{e}"
end
