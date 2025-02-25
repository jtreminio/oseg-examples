require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CodeReferencesApi.new.get_root_statistic

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CodeReferences#get_root_statistic: #{e}"
end
