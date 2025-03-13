require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.get_integration_delivery_configuration_by_id(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "integrationKey_string", # integration_key
        "id_string", # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#get_integration_delivery_configuration_by_id: #{e}"
end
