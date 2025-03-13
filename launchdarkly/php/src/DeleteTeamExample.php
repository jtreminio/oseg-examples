<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

try {
    (new LaunchDarkly\Client\Api\TeamsApi(config: $config))->deleteTeam(
        team_key: null,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling TeamsApi#deleteTeam: {$e->getMessage()}";
}
