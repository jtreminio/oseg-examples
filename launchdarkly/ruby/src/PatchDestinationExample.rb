require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/config/topic"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::DataExportDestinationsApi.new.patch_destination(
        nil, # project_key
        nil, # environment_key
        nil, # id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinationsApi#patch_destination: #{e}"
end
