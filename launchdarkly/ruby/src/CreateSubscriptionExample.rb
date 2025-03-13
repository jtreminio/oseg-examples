require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

statements_1 = LaunchDarklyClient::StatementPost.new
statements_1.effect = "allow"
statements_1.resources = [
    "proj/*:env/*:flag/*;testing-tag",
]
statements_1.actions = [
    "*",
]

statements = [
    statements_1,
]

subscription_post = LaunchDarklyClient::SubscriptionPost.new
subscription_post.name = "Example audit log subscription."
subscription_post.config = JSON.parse(<<-EOD
    {
        "optional": "an optional property",
        "required": "the required property",
        "url": "https://example.com"
    }
    EOD
)
subscription_post.on = false
subscription_post.tags = [
    "testing-tag",
]
subscription_post.statements = statements

begin
    response = LaunchDarklyClient::IntegrationAuditLogSubscriptionsApi.new.create_subscription(
        nil, # integration_key
        subscription_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationAuditLogSubscriptionsApi#create_subscription: #{e}"
end
