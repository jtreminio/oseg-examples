require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::EnvironmentsApi.new.get_environment(
        nil, # project_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Environments#get_environment: #{e}"
end
