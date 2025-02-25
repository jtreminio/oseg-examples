require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ScheduledChangesApi.new.get_feature_flag_scheduled_change(
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChanges#get_feature_flag_scheduled_change: #{e}"
end
