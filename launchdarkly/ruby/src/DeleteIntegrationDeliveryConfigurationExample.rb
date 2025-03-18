require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.delete_integration_delivery_configuration(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "integrationKey_string", # integration_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#delete_integration_delivery_configuration: #{e}"
end
