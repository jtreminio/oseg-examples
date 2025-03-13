require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::IntegrationsBetaApi.new.get_all_integration_configurations(
        "integrationKey_string", # integration_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBetaApi#get_all_integration_configurations: #{e}"
end
