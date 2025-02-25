require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsScoresBetaApi.new.get_insight_groups

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsScoresBeta#get_insight_groups: #{e}"
end
