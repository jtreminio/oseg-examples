<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$capability_config_audit_log_events_hook_statements_1 = (new LaunchDarkly\Client\Model\StatementPost())
    ->setEffect(LaunchDarkly\Client\Model\StatementPost::EFFECT_ALLOW)
    ->setResources([
        "proj/*:env/*:flag/*;testing-tag",
    ])
    ->setNotResources([
    ])
    ->setActions([
        "*",
    ])
    ->setNotActions([
    ]);

$capability_config_audit_log_events_hook_statements = [
    $capability_config_audit_log_events_hook_statements_1,
];

$capability_config_approvals_additional_form_variables = [
];

$capability_config_approvals = (new LaunchDarkly\Client\Model\ApprovalsCapabilityConfig())
    ->setAdditionalFormVariables($capability_config_approvals_additional_form_variables);

$capability_config_audit_log_events_hook = (new LaunchDarkly\Client\Model\AuditLogEventsHookCapabilityConfigPost())
    ->setStatements($capability_config_audit_log_events_hook_statements);

$capability_config = (new LaunchDarkly\Client\Model\CapabilityConfigPost())
    ->setApprovals($capability_config_approvals)
    ->setAuditLogEventsHook($capability_config_audit_log_events_hook);

$integration_configuration_post = (new LaunchDarkly\Client\Model\IntegrationConfigurationPost())
    ->setName("Example integration configuration")
    ->setConfigValues(json_decode(<<<'EOD'
        {
            "optional": "an optional property",
            "required": "the required property",
            "url": "https://example.com"
        }
    EOD, true))
    ->setEnabled(true)
    ->setTags([
        "ops",
    ])
    ->setCapabilityConfig($capability_config);

try {
    $response = (new LaunchDarkly\Client\Api\IntegrationsBetaApi(config: $config))->createIntegrationConfiguration(
        integration_key: null,
        integration_configuration_post: $integration_configuration_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationsBetaApi#createIntegrationConfiguration: {$e->getMessage()}";
}
