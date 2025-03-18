require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

messages_1 = LaunchDarklyClient::Message.new
messages_1.content = "content"
messages_1.role = "role"

messages_2 = LaunchDarklyClient::Message.new
messages_2.content = "content"
messages_2.role = "role"

messages = [
    messages_1,
    messages_2,
]

ai_config_variation_post = LaunchDarklyClient::AIConfigVariationPost.new
ai_config_variation_post.key = "key"
ai_config_variation_post.name = "name"
ai_config_variation_post.model = {}
ai_config_variation_post.model_config_key = "modelConfigKey"
ai_config_variation_post.messages = messages

begin
    response = LaunchDarklyClient::AIConfigsBetaApi.new.post_ai_config_variation(
        "beta", # ld_api_version
        "projectKey_string", # project_key
        "configKey_string", # config_key
        ai_config_variation_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AIConfigsBetaApi#post_ai_config_variation: #{e}"
end
