require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::ExperimentsApi.new.get_experimentation_settings(
        nil, # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling Experiments#get_experimentation_settings: #{e}"
end
