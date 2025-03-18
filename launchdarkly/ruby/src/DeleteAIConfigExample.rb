require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AIConfigsBetaApi.new.delete_ai_config(
        "beta", # ld_api_version
        "default", # project_key
        "configKey_string", # config_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#delete_ai_config: #{e}"
end
