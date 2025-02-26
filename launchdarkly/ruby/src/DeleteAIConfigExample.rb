require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    LaunchDarklyClient::AIConfigsBetaApi.new.delete_ai_config(
        nil, # ld_api_version
        "default", # project_key
        nil, # config_key
    )
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#delete_ai_config: #{e}"
end
