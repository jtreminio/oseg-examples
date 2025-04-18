require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AIConfigsBetaApi.new.delete_model_config(
        "beta", # ld_api_version
        "default", # project_key
        "modelConfigKey_string", # model_config_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#delete_model_config: #{e}"
end
