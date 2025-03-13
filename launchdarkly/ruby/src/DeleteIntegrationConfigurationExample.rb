require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationsBetaApi.new.delete_integration_configuration(
        "integrationConfigurationId_string", # integration_configuration_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBetaApi#delete_integration_configuration: #{e}"
end
