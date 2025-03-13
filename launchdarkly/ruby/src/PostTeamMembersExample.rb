require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TeamsApi.new.post_team_members(
        "teamKey_string", # team_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#post_team_members: #{e}"
end
