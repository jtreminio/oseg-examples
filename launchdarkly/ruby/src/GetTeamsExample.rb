require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TeamsApi.new.get_teams

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TeamsApi#get_teams: #{e}"
end
