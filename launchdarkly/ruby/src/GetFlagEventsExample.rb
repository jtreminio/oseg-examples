require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsFlagEventsBetaApi.new.get_flag_events(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsFlagEventsBetaApi#get_flag_events: #{e}"
end
