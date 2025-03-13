require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ProjectsApi.new.delete_project(
        nil, # project_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#delete_project: #{e}"
end
