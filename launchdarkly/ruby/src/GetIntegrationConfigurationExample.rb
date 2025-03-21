require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationsBetaApi.new.get_integration_configuration(
        "integrationConfigurationId_string", # integration_configuration_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBetaApi#get_integration_configuration: #{e}"
end
