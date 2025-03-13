require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.get_statistics(
        "projectKey_string", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#get_statistics: #{e}"
end
