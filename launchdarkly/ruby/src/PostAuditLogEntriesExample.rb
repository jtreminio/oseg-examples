require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

statement_post_1 = LaunchDarklyClient::StatementPost.new
statement_post_1.effect = "allow"
statement_post_1.resources = [
    "proj/*:env/*:flag/*;testing-tag",
]
statement_post_1.not_resources = [
]
statement_post_1.actions = [
    "*",
]
statement_post_1.not_actions = [
]

statement_post = [
    statement_post_1,
]

begin
    response = LaunchDarklyClient::AuditLogApi.new.post_audit_log_entries(
        {
            before: nil,
            after: nil,
            q: nil,
            limit: nil,
            statement_post: statement_post,
        },
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling AuditLogApi#post_audit_log_entries: #{e}"
end
