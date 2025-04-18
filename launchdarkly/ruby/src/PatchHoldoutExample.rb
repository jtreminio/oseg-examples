require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

holdout_patch_input = LaunchDarklyClient::HoldoutPatchInput.new
holdout_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "updateName",
            "value": "Updated holdout name"
        }
    ]
    EOD
)
holdout_patch_input.comment = "Optional comment describing the update"

begin
    response = LaunchDarklyClient::HoldoutsBetaApi.new.patch_holdout(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "holdoutKey_string", # holdout_key
        holdout_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling HoldoutsBetaApi#patch_holdout: #{e}"
end
