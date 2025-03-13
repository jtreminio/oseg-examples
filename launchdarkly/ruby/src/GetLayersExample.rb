require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::LayersApi.new.get_layers(
        "projectKey_string", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling LayersApi#get_layers: #{e}"
end
