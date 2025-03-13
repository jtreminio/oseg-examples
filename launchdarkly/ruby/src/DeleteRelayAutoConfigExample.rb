require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::RelayProxyConfigurationsApi.new.delete_relay_auto_config(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurationsApi#delete_relay_auto_config: #{e}"
end
