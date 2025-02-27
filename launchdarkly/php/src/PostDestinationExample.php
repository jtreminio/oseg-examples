<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$destination_post = (new LaunchDarkly\Client\Model\DestinationPost())
    ->setName(null)
    ->setKind(LaunchDarkly\Client\Model\DestinationPost::KIND_GOOGLE_PUBSUB)
    ->setOn(null);

try {
    $response = (new LaunchDarkly\Client\Api\DataExportDestinationsApi(config: $config))->postDestination(
        project_key: null,
        environment_key: null,
        destination_post: $destination_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling DataExportDestinationsApi#postDestination: {$e->getMessage()}";
}
