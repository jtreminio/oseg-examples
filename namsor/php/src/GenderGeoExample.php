<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->genderGeo(
        first_name: "Keith",
        last_name: "Haring",
        country_iso2: "US",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#genderGeo: {$e->getMessage()}";
}
