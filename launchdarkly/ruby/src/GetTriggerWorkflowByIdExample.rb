require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::FlagTriggersApi.new.get_trigger_workflow_by_id(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#get_trigger_workflow_by_id: #{e}"
end
