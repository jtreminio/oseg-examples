<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$statements_1 = (new LaunchDarkly\Client\Model\StatementPost())
    ->setEffect(LaunchDarkly\Client\Model\StatementPost::EFFECT_ALLOW)
    ->setResources([
        "proj/test",
    ])
    ->setNotResources(null)
    ->setActions([
        "*",
    ])
    ->setNotActions(null);

$statements = [
    $statements_1,
];

$webhook_post = (new LaunchDarkly\Client\Model\WebhookPost())
    ->setUrl("https://example.com")
    ->setSign(false)
    ->setOn(true)
    ->setName("apidocs test webhook")
    ->setSecret(null)
    ->setTags([
        "example-tag",
    ])
    ->setStatements($statements);

try {
    $response = (new LaunchDarkly\Client\Api\WebhooksApi(config: $config))->postWebhook(
        webhook_post: $webhook_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling WebhooksApi#postWebhook: {$e->getMessage()}";
}
