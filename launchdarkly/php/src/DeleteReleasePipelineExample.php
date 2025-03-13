<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\ReleasePipelinesBetaApi(config: $config))->deleteReleasePipeline(
        project_key: "projectKey_string",
        pipeline_key: "pipelineKey_string",
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasePipelinesBetaApi#deleteReleasePipeline: {$e->getMessage()}";
}
