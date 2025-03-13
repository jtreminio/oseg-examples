<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$upsert_context_kind_payload = (new LaunchDarkly\Client\Model\UpsertContextKindPayload())
    ->setName("organization")
    ->setDescription("An example context kind for organizations")
    ->setHideInTargeting(false)
    ->setArchived(false)
    ->setVersion(1);

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->putContextKind(
        project_key: null,
        key: null,
        upsert_context_kind_payload: $upsert_context_kind_payload,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ContextsApi#putContextKind: {$e->getMessage()}";
}
