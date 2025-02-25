require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.get_branches(
        nil, # repo
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferences#get_branches: #{e}"
end
