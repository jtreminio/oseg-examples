require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_data_export_events_usage

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBetaApi#get_data_export_events_usage: #{e}"
end
