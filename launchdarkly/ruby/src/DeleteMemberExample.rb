require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AccountMembersApi.new.delete_member(
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#delete_member: #{e}"
end
