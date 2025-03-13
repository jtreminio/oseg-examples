require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

post_flag_scheduled_changes_input = LaunchDarklyClient::PostFlagScheduledChangesInput.new
post_flag_scheduled_changes_input.execution_date = 1718467200000
post_flag_scheduled_changes_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "turnFlagOn"
        }
    ]
    EOD
)
post_flag_scheduled_changes_input.comment = "Optional comment describing the scheduled changes"

begin
    response = LaunchDarklyClient::ScheduledChangesApi.new.post_flag_config_scheduled_changes(
        "projectKey_string", # project_key
        "featureFlagKey_string", # feature_flag_key
        "environmentKey_string", # environment_key
        post_flag_scheduled_changes_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ScheduledChangesApi#post_flag_config_scheduled_changes: #{e}"
end
