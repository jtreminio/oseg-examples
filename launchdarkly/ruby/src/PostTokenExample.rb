require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

access_token_post = LaunchDarklyClient::AccessTokenPost.new
access_token_post.role = "reader"

begin
    response = LaunchDarklyClient::AccessTokensApi.new.post_token(
        access_token_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccessTokensApi#post_token: #{e}"
end
