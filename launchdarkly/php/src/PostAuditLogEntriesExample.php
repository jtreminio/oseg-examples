<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$statement_post_1 = (new LaunchDarkly\Client\Model\StatementPost())
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

$statement_post = [
    $statement_post_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\AuditLogApi(config: $config))->postAuditLogEntries(
        before: null,
        after: null,
        q: null,
        limit: null,
        statement_post: $statement_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AuditLogApi#postAuditLogEntries: {$e->getMessage()}";
}
