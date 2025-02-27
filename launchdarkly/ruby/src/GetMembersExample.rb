require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountMembersApi.new.get_members

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#get_members: #{e}"
end
