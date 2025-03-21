require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::InsightsPullRequestsBetaApi.new.get_pull_requests(
        "projectKey_string", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling InsightsPullRequestsBetaApi#get_pull_requests: #{e}"
end
