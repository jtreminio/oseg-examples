require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

oauth_client_post = LaunchDarklyClient::OauthClientPost.new

begin
    response = LaunchDarklyClient::OAuth2ClientsApi.new.create_o_auth2_client(
        oauth_client_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2ClientsApi#create_o_auth2_client: #{e}"
end
