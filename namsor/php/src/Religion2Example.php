<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->religion2(
        country_iso2: "NG",
        sub_division_iso31662: "IN-UP",
        first_name: "Akash",
        last_name: "Sharma",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#religion2: {$e->getMessage()}";
}
