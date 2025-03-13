<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\ReleasePipelinesBetaApi(config: $config))->getAllReleasePipelines(
        project_key: null,
        filter: null,
        limit: null,
        offset: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasePipelinesBetaApi#getAllReleasePipelines: {$e->getMessage()}";
}
