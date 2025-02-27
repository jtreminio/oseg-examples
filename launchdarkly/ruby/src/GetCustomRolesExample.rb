require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::CustomRolesApi.new.get_custom_roles

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRolesApi#get_custom_roles: #{e}"
end
