require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

post_insight_group_params = LaunchDarklyClient::PostInsightGroupParams.new
post_insight_group_params.name = "Production - All Apps"
post_insight_group_params.key = "default-production-all-apps"
post_insight_group_params.project_key = "default"
post_insight_group_params.environment_key = "production"
post_insight_group_params.application_keys = [
    "billing-service",
    "inventory-service",
]

begin
    response = LaunchDarklyClient::InsightsScoresBetaApi.new.create_insight_group(
        post_insight_group_params,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsScoresBeta#create_insight_group: #{e}"
end
