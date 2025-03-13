<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$extinction_1 = (new LaunchDarkly\Client\Model\Extinction())
    ->setRevision("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
    ->setMessage("Remove flag for launched feature")
    ->setTime(1706701522000)
    ->setFlagKey("enable-feature")
    ->setProjKey("default");

$extinction = [
    $extinction_1,
];

try {
    (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->postExtinction(
        repo: null,
        branch: null,
        extinction: $extinction,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferencesApi#postExtinction: {$e->getMessage()}";
}
