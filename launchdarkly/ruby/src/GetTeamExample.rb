require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TeamsApi.new.get_team(
        "teamKey_string", # team_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#get_team: #{e}"
end
