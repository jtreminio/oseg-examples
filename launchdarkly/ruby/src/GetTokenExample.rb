require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccessTokensApi.new.get_token(
        "id_string", # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccessTokensApi#get_token: #{e}"
end
