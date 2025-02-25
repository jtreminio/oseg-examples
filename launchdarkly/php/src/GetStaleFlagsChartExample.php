<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

try {
    $response = (new LaunchDarkly\Client\Api\InsightsChartsBetaApi(config: $config))->getStaleFlagsChart(
        project_key: null,
        environment_key: null,
        application_key: null,
        group_by: null,
        maintainer_id: null,
        maintainer_team_key: null,
        expand: null,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling InsightsChartsBeta#getStaleFlagsChart: {$e->getMessage()}";
}
