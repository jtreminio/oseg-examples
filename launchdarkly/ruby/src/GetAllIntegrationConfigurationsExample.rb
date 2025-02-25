require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationsBetaApi.new.get_all_integration_configurations(
        nil, # integration_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBeta#get_all_integration_configurations: #{e}"
end
