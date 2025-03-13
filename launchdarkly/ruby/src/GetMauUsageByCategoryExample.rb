require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_mau_usage_by_category

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBetaApi#get_mau_usage_by_category: #{e}"
end
