require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_flags_request = LaunchDarklyClient::PatchFlagsRequest.new
patch_flags_request.instructions = JSON.parse(<<-EOD
    [
        {
            "kind": "addExpireUserTargetDate",
            "userKey": "sandy",
            "value": 1686412800000,
            "variationId": "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d"
        }
    ]
    EOD
)
patch_flags_request.comment = "optional comment"

begin
    response = LaunchDarklyClient::FeatureFlagsApi.new.patch_expiring_targets(
        nil, # project_key
        nil, # environment_key
        nil, # feature_flag_key
        patch_flags_request,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FeatureFlagsApi#patch_expiring_targets: #{e}"
end
