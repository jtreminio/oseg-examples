require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

experiment_patch_input = LaunchDarklyClient::ExperimentPatchInput.new
experiment_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "updateName",
            "value": "Updated experiment name"
        }
    ]
    EOD
)
experiment_patch_input.comment = "Example comment describing the update"

begin
    response = LaunchDarklyClient::ExperimentsApi.new.patch_experiment(
        nil, # project_key
        nil, # environment_key
        nil, # experiment_key
        experiment_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Experiments#patch_experiment: #{e}"
end
