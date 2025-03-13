require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FlagTriggersApi.new.get_trigger_workflows(
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#get_trigger_workflows: #{e}"
end
