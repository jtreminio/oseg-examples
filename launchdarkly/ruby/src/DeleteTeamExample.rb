require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::TeamsApi.new.delete_team(
        nil, # team_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#delete_team: #{e}"
end
