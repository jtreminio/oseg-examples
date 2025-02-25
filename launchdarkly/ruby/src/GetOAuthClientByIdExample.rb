require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::OAuth2ClientsApi.new.get_o_auth_client_by_id(
        nil, # client_id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2Clients#get_o_auth_client_by_id: #{e}"
end
