import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    capability_config_audit_log_events_hook_statements_1 = models.StatementPost(
        effect="allow",
        resources=[
            "proj/*:env/*:flag/*;testing-tag",
        ],
        notResources=[
        ],
        actions=[
            "*",
        ],
        notActions=[
        ],
    )

    capability_config_audit_log_events_hook_statements = [
        capability_config_audit_log_events_hook_statements_1,
    ]

    capability_config_approvals_additional_form_variables = [
    ]

    capability_config_approvals = models.ApprovalsCapabilityConfig(
        additionalFormVariables=capability_config_approvals_additional_form_variables,
    )

    capability_config_audit_log_events_hook = models.AuditLogEventsHookCapabilityConfigPost(
        statements=capability_config_audit_log_events_hook_statements,
    )

    capability_config = models.CapabilityConfigPost(
        approvals=capability_config_approvals,
        auditLogEventsHook=capability_config_audit_log_events_hook,
    )

    integration_configuration_post = models.IntegrationConfigurationPost(
        name="Example integration configuration",
        configValues=json.loads("""
            {
                "optional": "an optional property",
                "required": "the required property",
                "url": "https://example.com"
            }
        """),
        enabled=True,
        tags=[
            "ops",
        ],
        capabilityConfig=capability_config,
    )

    try:
        response = api.IntegrationsBetaApi(api_client).create_integration_configuration(
            integration_key=None,
            integration_configuration_post=integration_configuration_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationsBetaApi#create_integration_configuration: %s\n" % e)
