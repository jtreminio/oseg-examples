<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$statements_1 = (new LaunchDarkly\Client\Model\StatementPost())
    ->setEffect(LaunchDarkly\Client\Model\StatementPost::EFFECT_ALLOW)
    ->setResources([
        "proj/*:env/*:flag/*;testing-tag",
    ])
    ->setNotResources(null)
    ->setActions([
        "*",
    ])
    ->setNotActions(null);

$statements = [
    $statements_1,
];

$subscription_post = (new LaunchDarkly\Client\Model\SubscriptionPost())
    ->setName("Example audit log subscription.")
    ->setConfig(json_decode(<<<'EOD'
        {
            "optional": "an optional property",
            "required": "the required property",
            "url": "https://example.com"
        }
    EOD, true))
    ->setOn(false)
    ->setUrl(null)
    ->setApiKey(null)
    ->setTags([
        "testing-tag",
    ])
    ->setStatements($statements);

try {
    $response = (new LaunchDarkly\Client\Api\IntegrationAuditLogSubscriptionsApi(config: $config))->createSubscription(
        integration_key: null,
        subscription_post: $subscription_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling IntegrationAuditLogSubscriptionsApi#createSubscription: {$e->getMessage()}";
}
