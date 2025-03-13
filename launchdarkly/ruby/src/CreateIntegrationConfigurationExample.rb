require "json"
require "launchdarkly_client"

LaunchDarklyClient.configure do |config|
    config.api_key["Authorization"] = "YOUR_API_KEY"
end

capability_config_audit_log_events_hook_statements_1 = LaunchDarklyClient::StatementPost.new
capability_config_audit_log_events_hook_statements_1.effect = "allow"
capability_config_audit_log_events_hook_statements_1.resources = [
    "proj/*:env/*:flag/*;testing-tag",
]
capability_config_audit_log_events_hook_statements_1.not_resources = [
]
capability_config_audit_log_events_hook_statements_1.actions = [
    "*",
]
capability_config_audit_log_events_hook_statements_1.not_actions = [
]

capability_config_audit_log_events_hook_statements = [
    capability_config_audit_log_events_hook_statements_1,
]

capability_config_approvals_additional_form_variables = [
]

capability_config_approvals = LaunchDarklyClient::ApprovalsCapabilityConfig.new
capability_config_approvals.additional_form_variables = capability_config_approvals_additional_form_variables

capability_config_audit_log_events_hook = LaunchDarklyClient::AuditLogEventsHookCapabilityConfigPost.new
capability_config_audit_log_events_hook.statements = capability_config_audit_log_events_hook_statements

capability_config = LaunchDarklyClient::CapabilityConfigPost.new
capability_config.approvals = capability_config_approvals
capability_config.audit_log_events_hook = capability_config_audit_log_events_hook

integration_configuration_post = LaunchDarklyClient::IntegrationConfigurationPost.new
integration_configuration_post.name = "Example integration configuration"
integration_configuration_post.config_values = JSON.parse(<<-EOD
    {
        "optional": "an optional property",
        "required": "the required property",
        "url": "https://example.com"
    }
    EOD
)
integration_configuration_post.enabled = true
integration_configuration_post.tags = [
    "ops",
]
integration_configuration_post.capability_config = capability_config

begin
    response = LaunchDarklyClient::IntegrationsBetaApi.new.create_integration_configuration(
        "integrationKey_string", # integration_key
        integration_configuration_post,
    )

    p response
rescue LaunchDarklyClient::ApiError => e
    puts "Exception when calling IntegrationsBetaApi#create_integration_configuration: #{e}"
end
