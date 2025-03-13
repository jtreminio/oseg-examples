require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::UsersApi.new.delete_user(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "userKey_string", # user_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling UsersApi#delete_user: #{e}"
end
