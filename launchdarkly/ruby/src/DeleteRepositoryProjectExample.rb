require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::InsightsRepositoriesBetaApi.new.delete_repository_project(
        nil, # repository_key
        nil, # project_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsRepositoriesBetaApi#delete_repository_project: #{e}"
end
