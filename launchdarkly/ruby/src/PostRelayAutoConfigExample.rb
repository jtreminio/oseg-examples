require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["ApiKey"] = "YOUR_API_KEY"
end

policy_1 = LaunchDarklyClient::Statement.new
policy_1.effect = "allow"
policy_1.resources = [
    "proj/*:env/*",
]
policy_1.actions = [
    "*",
]

policy = [
    policy_1,
]

relay_auto_config_post = LaunchDarklyClient::RelayAutoConfigPost.new
relay_auto_config_post.name = "Sample Relay Proxy config for all proj and env"
relay_auto_config_post.policy = policy

begin
    response = LaunchDarklyClient::RelayProxyConfigurationsApi.new.post_relay_auto_config(
        relay_auto_config_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling RelayProxyConfigurations#post_relay_auto_config: #{e}"
end
