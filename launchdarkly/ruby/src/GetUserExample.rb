require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::UsersApi.new.get_user(
        nil, # project_key
        nil, # environment_key
        nil, # user_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UsersApi#get_user: #{e}"
end
