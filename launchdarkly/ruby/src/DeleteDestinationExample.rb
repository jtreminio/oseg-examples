require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::DataExportDestinationsApi.new.delete_destination(
        nil, # project_key
        nil, # environment_key
        nil, # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinations#delete_destination: #{e}"
end
