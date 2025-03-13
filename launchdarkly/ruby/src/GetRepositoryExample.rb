require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.get_repository(
        "repo_string", # repo
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#get_repository: #{e}"
end
