<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->getRootStatistic();

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferencesApi#getRootStatistic: {$e->getMessage()}";
}
