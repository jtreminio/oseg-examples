require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CustomRolesApi.new.get_custom_role(
        "customRoleKey_string", # custom_role_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRolesApi#get_custom_role: #{e}"
end
