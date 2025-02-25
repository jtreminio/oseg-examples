require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_stream_usage_sdkversion(
        nil, # source
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBeta#get_stream_usage_sdkversion: #{e}"
end
