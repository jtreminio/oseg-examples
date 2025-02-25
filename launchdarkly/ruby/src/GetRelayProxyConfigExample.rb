require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::RelayProxyConfigurationsApi.new.get_relay_proxy_config(
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurations#get_relay_proxy_config: #{e}"
end
