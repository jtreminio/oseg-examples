require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::EnvironmentsApi.new.delete_environment(
        nil, # project_key
        nil, # environment_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Environments#delete_environment: #{e}"
end
