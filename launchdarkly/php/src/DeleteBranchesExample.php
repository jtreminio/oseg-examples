<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->deleteBranches(
        repo: null,
        request_body: [
            "branch-to-be-deleted",
            "another-branch-to-be-deleted",
        ],
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferencesApi#deleteBranches: {$e->getMessage()}";
}
