require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::ScheduledChangesApi.new.delete_flag_config_scheduled_changes(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChangesApi#delete_flag_config_scheduled_changes: #{e}"
end
