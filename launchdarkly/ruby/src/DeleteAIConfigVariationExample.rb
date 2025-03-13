require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AIConfigsBetaApi.new.delete_ai_config_variation(
        nil, # ld_api_version
        nil, # project_key
        nil, # config_key
        nil, # variation_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#delete_ai_config_variation: #{e}"
end
