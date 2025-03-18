require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.list_model_configs(
        "beta", # ld_api_version
        "default", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#list_model_configs: #{e}"
end
