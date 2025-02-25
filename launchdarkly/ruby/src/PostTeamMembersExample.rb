require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TeamsApi.new.post_team_members(
        nil, # team_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Teams#post_team_members: #{e}"
end
