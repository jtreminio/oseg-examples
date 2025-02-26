require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::CodeReferencesApi.new.delete_repository(
        nil, # repo
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferencesApi#delete_repository: #{e}"
end
