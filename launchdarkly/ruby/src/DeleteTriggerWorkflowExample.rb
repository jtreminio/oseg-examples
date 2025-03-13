require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::FlagTriggersApi.new.delete_trigger_workflow(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "featureFlagKey_string", # feature_flag_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#delete_trigger_workflow: #{e}"
end
