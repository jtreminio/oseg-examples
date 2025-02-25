require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "add"
patch_operation_1.path = "/tags/0"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::ProjectsApi.new.patch_project(
        nil, # project_key
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Projects#patch_project: #{e}"
end
