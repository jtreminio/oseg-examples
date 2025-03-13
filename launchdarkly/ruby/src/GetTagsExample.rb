require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::TagsApi.new.get_tags

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling TagsApi#get_tags: #{e}"
end
