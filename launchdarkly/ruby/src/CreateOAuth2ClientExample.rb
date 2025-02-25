require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

oauth_client_post = LaunchDarklyClient::OauthClientPost.new
oauth_client_post.name = nil
oauth_client_post.redirect_uri = nil
oauth_client_post.description = nil

begin
    response = LaunchDarklyClient::OAuth2ClientsApi.new.create_o_auth2_client(
        oauth_client_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OAuth2Clients#create_o_auth2_client: #{e}"
end
