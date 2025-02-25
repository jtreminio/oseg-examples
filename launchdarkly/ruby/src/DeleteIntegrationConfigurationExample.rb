require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationsBetaApi.new.delete_integration_configuration(
        nil, # integration_configuration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBeta#delete_integration_configuration: #{e}"
end
