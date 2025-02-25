require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AccountUsageBetaApi.new.get_mau_usage

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AccountUsageBeta#get_mau_usage: #{e}"
end
