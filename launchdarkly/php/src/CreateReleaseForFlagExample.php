<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$create_release_input = (new LaunchDarkly\Client\Model\CreateReleaseInput())
    ->setReleasePipelineKey("releasePipelineKey_string");

try {
    $response = (new LaunchDarkly\Client\Api\ReleasesBetaApi(config: $config))->createReleaseForFlag(
        project_key: "projectKey_string",
        flag_key: "flagKey_string",
        create_release_input: $create_release_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasesBetaApi#createReleaseForFlag: {$e->getMessage()}";
}
