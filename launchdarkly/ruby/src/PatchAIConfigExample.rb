require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

ai_config_patch = LaunchDarklyClient::AIConfigPatch.new
ai_config_patch.description = "description"
ai_config_patch.name = "name"
ai_config_patch.tags = [
    "tags",
    "tags",
]

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.patch_ai_config(
        nil, # ld_api_version
        nil, # project_key
        nil, # config_key
        {
            ai_config_patch: ai_config_patch,
        },
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#patch_ai_config: #{e}"
end
