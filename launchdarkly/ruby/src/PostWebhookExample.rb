require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

statements_1 = LaunchDarklyClient::StatementPost.new
statements_1.effect = "allow"
statements_1.resources = [
    "proj/test",
]
statements_1.actions = [
    "*",
]

statements = [
    statements_1,
]

webhook_post = LaunchDarklyClient::WebhookPost.new
webhook_post.url = "https://example.com"
webhook_post.sign = false
webhook_post.on = true
webhook_post.name = "apidocs test webhook"
webhook_post.tags = [
    "example-tag",
]
webhook_post.statements = statements

begin
    response = LaunchDarklyClient::WebhooksApi.new.post_webhook(
        webhook_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling WebhooksApi#post_webhook: #{e}"
end
