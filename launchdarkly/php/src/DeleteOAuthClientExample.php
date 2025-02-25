<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\OAuth2ClientsApi(config: $config))->deleteOAuthClient(
        client_id: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling OAuth2Clients#deleteOAuthClient: {$e->getMessage()}";
}
