require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsRepositoriesBetaApi.new.get_insights_repositories

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsRepositoriesBetaApi#get_insights_repositories: #{e}"
end
