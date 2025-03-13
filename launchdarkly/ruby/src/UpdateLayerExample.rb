require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

layer_patch_input = LaunchDarklyClient::LayerPatchInput.new
layer_patch_input.instructions = JSON.parse(<<-EOD
    [
        {
            "experimentKey": "checkout-button-color",
            "kind": "updateExperimentReservation",
            "reservationPercent": 25
        }
    ]
    EOD
)
layer_patch_input.comment = "Example comment describing the update"
layer_patch_input.environment_key = "production"

begin
    response = LaunchDarklyClient::LayersApi.new.update_layer(
        "projectKey_string", # project_key
        "layerKey_string", # layer_key
        layer_patch_input,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling LayersApi#update_layer: #{e}"
end
