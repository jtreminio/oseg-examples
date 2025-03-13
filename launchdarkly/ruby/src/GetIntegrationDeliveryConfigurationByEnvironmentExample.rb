require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.get_integration_delivery_configuration_by_environment(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#get_integration_delivery_configuration_by_environment: #{e}"
end
