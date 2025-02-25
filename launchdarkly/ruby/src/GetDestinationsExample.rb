require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::DataExportDestinationsApi.new.get_destinations

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinations#get_destinations: #{e}"
end
