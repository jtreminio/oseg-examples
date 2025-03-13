require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::EnvironmentsApi.new.delete_environment(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling EnvironmentsApi#delete_environment: #{e}"
end
