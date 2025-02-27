require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ProjectsApi.new.get_projects

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#get_projects: #{e}"
end
