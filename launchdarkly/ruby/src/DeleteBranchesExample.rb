require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::CodeReferencesApi.new.delete_branches(
        nil, # repo
        [
            "branch-to-be-deleted",
            "another-branch-to-be-deleted",
        ], # request_body
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#delete_branches: #{e}"
end
