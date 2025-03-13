require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::OAuth2ClientsApi.new.delete_o_auth_client(
        "clientId_string", # client_id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2ClientsApi#delete_o_auth_client: #{e}"
end
