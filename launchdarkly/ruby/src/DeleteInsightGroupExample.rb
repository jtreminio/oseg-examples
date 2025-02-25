require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::InsightsScoresBetaApi.new.delete_insight_group(
        nil, # insight_group_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsScoresBeta#delete_insight_group: #{e}"
end
