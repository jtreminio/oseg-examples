require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

integration_delivery_configuration_post = LaunchDarklyClient::IntegrationDeliveryConfigurationPost.new
integration_delivery_configuration_post.config = JSON.parse(<<-EOD
    {
        "optional": "example value for optional formVariables property for sample-integration",
        "required": "example value for required formVariables property for sample-integration"
    }
    EOD
)
integration_delivery_configuration_post.on = false
integration_delivery_configuration_post.name = "Sample integration"
integration_delivery_configuration_post.tags = [
    "example-tag",
]

begin
    response = LaunchDarklyClient::IntegrationDeliveryConfigurationsBetaApi.new.create_integration_delivery_configuration(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "integrationKey_string", # integration_key
        integration_delivery_configuration_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationDeliveryConfigurationsBetaApi#create_integration_delivery_configuration: #{e}"
end
