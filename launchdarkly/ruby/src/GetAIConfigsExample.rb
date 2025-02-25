require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.get_ai_configs(
        nil, # ld_api_version
        "default", # project_key
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBeta#get_ai_configs: #{e}"
end
