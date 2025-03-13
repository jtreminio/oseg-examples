require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
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
        "beta", # ld_api_version
        "projectKey_string", # project_key
        "configKey_string", # config_key
        {
            ai_config_patch: ai_config_patch,
        },
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#patch_ai_config: #{e}"
end
