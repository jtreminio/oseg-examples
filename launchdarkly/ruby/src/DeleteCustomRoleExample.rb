require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::CustomRolesApi.new.delete_custom_role(
        "customRoleKey_string", # custom_role_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRolesApi#delete_custom_role: #{e}"
end
