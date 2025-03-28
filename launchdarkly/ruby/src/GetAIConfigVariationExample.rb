require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.get_ai_config_variation(
        "beta", # ld_api_version
        "default", # project_key
        "default", # config_key
        "default", # variation_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#get_ai_config_variation: #{e}"
end
