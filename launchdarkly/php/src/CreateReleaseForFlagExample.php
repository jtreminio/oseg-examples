<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$create_release_input = (new LaunchDarkly\Client\Model\CreateReleaseInput())
    ->setReleasePipelineKey(null)
    ->setReleaseVariationId(null);

try {
    $response = (new LaunchDarkly\Client\Api\ReleasesBetaApi(config: $config))->createReleaseForFlag(
        project_key: null,
        flag_key: null,
        create_release_input: $create_release_input,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ReleasesBetaApi#createReleaseForFlag: {$e->getMessage()}";
}
