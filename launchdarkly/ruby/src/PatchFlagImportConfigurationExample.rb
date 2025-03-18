require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/exampleField"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::FlagImportConfigurationsBetaApi.new.patch_flag_import_configuration(
        "projectKey_string", # project_key
        "integrationKey_string", # integration_key
        "integrationId_string", # integration_id
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling FlagImportConfigurationsBetaApi#patch_flag_import_configuration: #{e}"
end
