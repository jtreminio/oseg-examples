require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.get_ai_config_metrics(
        nil, # ld_api_version
        nil, # project_key
        nil, # config_key
        123, # from
        456, # to
        nil, # env
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#get_ai_config_metrics: #{e}"
end
