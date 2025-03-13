require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::OtherApi.new.get_openapi_spec
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling OtherApi#get_openapi_spec: #{e}"
end
