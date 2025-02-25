require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccessTokensApi.new.get_tokens

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccessTokens#get_tokens: #{e}"
end
