require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AccessTokensApi.new.delete_token(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccessTokens#delete_token: #{e}"
end
