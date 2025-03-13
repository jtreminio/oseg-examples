<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->corridor(
        country_iso2_from: "GB",
        first_name_from: "Ada",
        last_name_from: "Lovelace",
        country_iso2_to: "US",
        first_name_to: "Nicolas",
        last_name_to: "Tesla",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#corridor: {$e->getMessage()}";
}
