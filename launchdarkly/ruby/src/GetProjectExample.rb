require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ProjectsApi.new.get_project(
        "projectKey_string", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#get_project: #{e}"
end
