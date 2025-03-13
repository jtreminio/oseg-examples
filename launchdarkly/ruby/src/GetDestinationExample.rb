require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::DataExportDestinationsApi.new.get_destination(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "id_string", # id
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinationsApi#get_destination: #{e}"
end
