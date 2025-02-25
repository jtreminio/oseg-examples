<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ContextsApi(config: $config))->getContextAttributeValues(
        project_key: null,
        environment_key: null,
        attribute_name: null,
        filter: null,
        limit: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Contexts#getContextAttributeValues: {$e->getMessage()}";
}
