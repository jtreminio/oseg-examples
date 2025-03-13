require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

policy_1 = LaunchDarklyClient::StatementPost.new
policy_1.effect = "allow"
policy_1.resources = [
    "proj/*:env/production:flag/*",
]
policy_1.actions = [
    "updateOn",
]

policy = [
    policy_1,
]

custom_role_post = LaunchDarklyClient::CustomRolePost.new
custom_role_post.name = "Ops team"
custom_role_post.key = "role-key-123abc"
custom_role_post.description = "An example role for members of the ops team"
custom_role_post.base_permissions = "reader"
custom_role_post.policy = policy

begin
    response = LaunchDarklyClient::CustomRolesApi.new.post_custom_role(
        custom_role_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling CustomRolesApi#post_custom_role: #{e}"
end
