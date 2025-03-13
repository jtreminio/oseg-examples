require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

mappings_1 = LaunchDarklyClient::InsightsRepositoryProject.new
mappings_1.repository_key = "launchdarkly/LaunchDarkly-Docs"
mappings_1.project_key = "default"

mappings = [
    mappings_1,
]

insights_repository_project_mappings = LaunchDarklyClient::InsightsRepositoryProjectMappings.new
insights_repository_project_mappings.mappings = mappings

begin
    response = LaunchDarklyClient::InsightsRepositoriesBetaApi.new.associate_repositories_and_projects(
        insights_repository_project_mappings,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsRepositoriesBetaApi#associate_repositories_and_projects: #{e}"
end
