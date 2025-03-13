require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TeamsApi.new.get_team_maintainers(
        nil, # team_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#get_team_maintainers: #{e}"
end
