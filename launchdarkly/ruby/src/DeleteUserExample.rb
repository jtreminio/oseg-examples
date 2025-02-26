require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::UsersApi.new.delete_user(
        nil, # project_key
        nil, # environment_key
        nil, # user_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UsersApi#delete_user: #{e}"
end
