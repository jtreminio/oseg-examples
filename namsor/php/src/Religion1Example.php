<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\IndianApi(config: $config))->religion1(
        sub_division_iso31662: "IN-UP",
        first_name: "Akash",
        last_name: "Sharma",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling IndianApi#religion1: {$e->getMessage()}";
}
