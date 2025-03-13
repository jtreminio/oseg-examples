require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

flag_trigger_input = LaunchDarklyClient::FlagTriggerInput.new
flag_trigger_input.comment = "optional comment"
flag_trigger_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "disableTrigger"
        }
    ]
    EOD
)

begin
    response = LaunchDarklyClient::FlagTriggersApi.new.patch_trigger_workflow(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "featureFlagKey_string", # feature_flag_key
        "id_string", # id
        flag_trigger_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#patch_trigger_workflow: #{e}"
end
