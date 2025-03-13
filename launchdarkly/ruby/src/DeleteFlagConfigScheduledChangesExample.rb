require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ScheduledChangesApi.new.delete_flag_config_scheduled_changes(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChangesApi#delete_flag_config_scheduled_changes: #{e}"
end
