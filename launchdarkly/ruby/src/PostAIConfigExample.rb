require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

ai_config_post = LaunchDarklyClient::AIConfigPost.new
ai_config_post.key = "key"
ai_config_post.name = "name"
ai_config_post.description = ""
ai_config_post.tags = [
    "tags",
    "tags",
]

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.post_ai_config(
        nil, # ld_api_version
        nil, # project_key
        ai_config_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#post_ai_config: #{e}"
end
