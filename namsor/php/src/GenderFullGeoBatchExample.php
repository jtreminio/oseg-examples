<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\PersonalNameGeoIn())
    ->setId("3a2d203a-a6a4-42f9-acd1-1b5c56c7d39f")
    ->setName("Keith Haring")
    ->setCountryIso2("US");

$personal_names = [
    $personal_names_1,
];

$batch_personal_name_geo_in = (new Namsor\Client\Model\BatchPersonalNameGeoIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->genderFullGeoBatch(
        batch_personal_name_geo_in: $batch_personal_name_geo_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#genderFullGeoBatch: {$e->getMessage()}";
}
