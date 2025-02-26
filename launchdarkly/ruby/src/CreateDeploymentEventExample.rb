require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

post_deployment_event_input = LaunchDarklyClient::PostDeploymentEventInput.new
post_deployment_event_input.project_key = "default"
post_deployment_event_input.environment_key = "production"
post_deployment_event_input.application_key = "billing-service"
post_deployment_event_input.version = "a90a8a2"
post_deployment_event_input.event_type = "started"
post_deployment_event_input.application_name = "Billing Service"
post_deployment_event_input.application_kind = "server"
post_deployment_event_input.version_name = "v1.0.0"
post_deployment_event_input.event_time = 1706701522000
post_deployment_event_input.event_metadata = JSON.parse(<<-EOD
    {
        "buildSystemVersion": "v1.2.3"
    }
    EOD
)
post_deployment_event_input.deployment_metadata = JSON.parse(<<-EOD
    {
        "buildNumber": "1234"
    }
    EOD
)

begin
    LaunchDarklyClient::InsightsDeploymentsBetaApi.new.create_deployment_event(
        post_deployment_event_input,
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsDeploymentsBetaApi#create_deployment_event: #{e}"
end
