require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_scheduled_changes_input = LaunchDarklyClient::FlagScheduledChangesInput.new
flag_scheduled_changes_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "replaceScheduledChangesInstructions",
            "value": [
                {
                    "kind": "turnFlagOff"
                }
            ]
        }
    ]
    EOD
)
flag_scheduled_changes_input.comment = "Optional comment describing the update to the scheduled changes"

begin
    response = LaunchDarklyClient::ScheduledChangesApi.new.patch_flag_config_scheduled_change(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        "id_string", # id
        flag_scheduled_changes_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChangesApi#patch_flag_config_scheduled_change: #{e}"
end
