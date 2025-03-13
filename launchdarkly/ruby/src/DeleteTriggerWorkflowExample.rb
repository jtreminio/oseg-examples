require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagTriggersApi.new.delete_trigger_workflow(
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#delete_trigger_workflow: #{e}"
end
