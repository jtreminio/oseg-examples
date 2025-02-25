require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::RelayProxyConfigurationsApi.new.delete_relay_auto_config(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurations#delete_relay_auto_config: #{e}"
end
