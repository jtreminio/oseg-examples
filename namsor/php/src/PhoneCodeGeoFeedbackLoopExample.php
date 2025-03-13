<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\SocialApi(config: $config))->phoneCodeGeoFeedbackLoop(
        first_name: "Teniola",
        last_name: "Apata",
        phone_number: "08186472651",
        phone_number_e164: "",
        country_iso2: "NG",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling SocialApi#phoneCodeGeoFeedbackLoop: {$e->getMessage()}";
}
