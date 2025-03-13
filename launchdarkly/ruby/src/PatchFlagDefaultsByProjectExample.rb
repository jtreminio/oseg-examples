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
    response = LaunchDarklyClient::ProjectsApi.new.patch_flag_defaults_by_project(
        nil, # project_key
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling ProjectsApi#patch_flag_defaults_by_project: #{e}"
end
