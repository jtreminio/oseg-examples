<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_operation_1 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("replace")
    ->setPath("/requireComments");

$patch_operation = [
    $patch_operation_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\EnvironmentsApi(config: $config))->patchEnvironment(
        project_key: "projectKey_string",
        environment_key: "environmentKey_string",
        patch_operation: $patch_operation,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling EnvironmentsApi#patchEnvironment: {$e->getMessage()}";
}
