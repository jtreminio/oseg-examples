require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::OAuth2ClientsApi.new.get_o_auth_clients

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2ClientsApi#get_o_auth_clients: #{e}"
end
