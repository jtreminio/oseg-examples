<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\UsersApi(config: $config))->getSearchUsers(
        project_key: null,
        environment_key: null,
        q: null,
        limit: null,
        offset: null,
        after: null,
        sort: null,
        search_after: null,
        filter: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling UsersApi#getSearchUsers: {$e->getMessage()}";
}
