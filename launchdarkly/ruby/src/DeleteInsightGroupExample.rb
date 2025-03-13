require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::InsightsScoresBetaApi.new.delete_insight_group(
        "insightGroupKey_string", # insight_group_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsScoresBetaApi#delete_insight_group: #{e}"
end
