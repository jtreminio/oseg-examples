require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

model_config_post = LaunchDarklyClient::ModelConfigPost.new
model_config_post.id = "id"
model_config_post.key = "key"
model_config_post.name = "name"
model_config_post.icon = "icon"
model_config_post.provider = "provider"
model_config_post.tags = [
    "tags",
    "tags",
]
model_config_post.params = {}
model_config_post.custom_params = {}

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.post_model_config(
        nil, # ld_api_version
        "default", # project_key
        model_config_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#post_model_config: #{e}"
end
