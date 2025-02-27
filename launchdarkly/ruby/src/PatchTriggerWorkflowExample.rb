require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
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
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
        nil, # id
        flag_trigger_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#patch_trigger_workflow: #{e}"
end
