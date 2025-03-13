require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::DataExportDestinationsApi.new.delete_destination(
        "projectKey_string", # project_key
        "environmentKey_string", # environment_key
        "id_string", # id
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling DataExportDestinationsApi#delete_destination: #{e}"
end
