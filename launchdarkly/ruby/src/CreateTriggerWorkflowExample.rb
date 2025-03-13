require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

trigger_post = LaunchDarklyClient::TriggerPost.new
trigger_post.integration_key = "generic-trigger"
trigger_post.comment = "example comment"
trigger_post.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "turnFlagOn"
        }
    ]
    EOD
)

begin
    response = LaunchDarklyClient::FlagTriggersApi.new.create_trigger_workflow(
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
        trigger_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagTriggersApi#create_trigger_workflow: #{e}"
end
