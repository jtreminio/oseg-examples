require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.get_ai_config_metrics_by_variation(
        "beta", # ld_api_version
        "projectKey_string", # project_key
        "configKey_string", # config_key
        123, # from
        456, # to
        "env_string", # env
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#get_ai_config_metrics_by_variation: #{e}"
end
