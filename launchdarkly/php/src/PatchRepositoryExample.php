<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$patch_operation_1 = (new LaunchDarkly\Client\Model\PatchOperation())
    ->setOp("replace")
    ->setPath("/defaultBranch");

$patch_operation = [
    $patch_operation_1,
];

try {
    $response = (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->patchRepository(
        repo: "repo_string",
        patch_operation: $patch_operation,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferencesApi#patchRepository: {$e->getMessage()}";
}
