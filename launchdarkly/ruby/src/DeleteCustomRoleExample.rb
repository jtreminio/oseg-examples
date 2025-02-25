require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::CustomRolesApi.new.delete_custom_role(
        nil, # custom_role_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRoles#delete_custom_role: #{e}"
end
