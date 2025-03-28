require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::RelayProxyConfigurationsApi.new.get_relay_proxy_config(
        "id_string", # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurationsApi#get_relay_proxy_config: #{e}"
end
