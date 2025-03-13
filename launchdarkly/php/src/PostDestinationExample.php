<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$destination_post = (new LaunchDarkly\Client\Model\DestinationPost())
    ->setKind(LaunchDarkly\Client\Model\DestinationPost::KIND_GOOGLE_PUBSUB);

try {
    $response = (new LaunchDarkly\Client\Api\DataExportDestinationsApi(config: $config))->postDestination(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        destination_post: $destination_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling DataExportDestinationsApi#postDestination: {$e->getMessage()}";
}
