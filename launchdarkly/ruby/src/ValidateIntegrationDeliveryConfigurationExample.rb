require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.validate_integration_delivery_configuration(
        nil, # project_key
        nil, # environment_key
        nil, # integration_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#validate_integration_delivery_configuration: #{e}"
end
