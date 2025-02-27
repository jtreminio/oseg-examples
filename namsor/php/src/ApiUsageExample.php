<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\AdminApi(config: $config))->apiUsage();

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling AdminApi#apiUsage: {$e->getMessage()}";
}
