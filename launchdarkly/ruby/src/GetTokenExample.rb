require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccessTokensApi.new.get_token(
        nil, # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccessTokens#get_token: #{e}"
end
