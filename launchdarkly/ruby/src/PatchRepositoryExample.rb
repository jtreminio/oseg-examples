require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

patch_operation_1 = LaunchDarklyClient::PatchOperation.new
patch_operation_1.op = "replace"
patch_operation_1.path = "/defaultBranch"

patch_operation = [
    patch_operation_1,
]

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.patch_repository(
        nil, # repo
        patch_operation,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#patch_repository: #{e}"
end
