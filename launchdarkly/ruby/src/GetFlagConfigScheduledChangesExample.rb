require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ScheduledChangesApi.new.get_flag_config_scheduled_changes(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChangesApi#get_flag_config_scheduled_changes: #{e}"
end
