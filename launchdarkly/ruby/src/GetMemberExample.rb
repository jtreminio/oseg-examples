require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountMembersApi.new.get_member(
        "id_string", # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountMembersApi#get_member: #{e}"
end
