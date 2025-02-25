require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
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
        nil, # project_key
        nil, # feature_flag_key
        nil, # environment_key
        nil, # id
        flag_scheduled_changes_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChanges#patch_flag_config_scheduled_change: #{e}"
end
