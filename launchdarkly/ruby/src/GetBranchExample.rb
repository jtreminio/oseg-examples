require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.get_branch(
        "repo_string", # repo
        "branch_string", # branch
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#get_branch: #{e}"
end
