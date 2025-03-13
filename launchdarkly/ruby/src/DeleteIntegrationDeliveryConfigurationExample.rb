require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.delete_integration_delivery_configuration(
        nil, # project_key
        nil, # environment_key
        nil, # integration_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#delete_integration_delivery_configuration: #{e}"
end
