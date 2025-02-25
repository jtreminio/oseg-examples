require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsFlagEventsBetaApi.new.get_flag_events(
        nil, # project_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsFlagEventsBeta#get_flag_events: #{e}"
end
