require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsScoresBetaApi.new.get_insights_scores(
        nil, # project_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsScoresBeta#get_insights_scores: #{e}"
end
