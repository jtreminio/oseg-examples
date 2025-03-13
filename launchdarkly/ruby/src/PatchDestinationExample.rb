require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/config/topic"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::DataExportDestinationsApi.new.patch_destination(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "id_string", # id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinationsApi#patch_destination: #{e}"
end
