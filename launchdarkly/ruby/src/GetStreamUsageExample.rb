require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_stream_usage(
        "source_string", # source
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBetaApi#get_stream_usage: #{e}"
end
