<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\PersonalNameGeoIn())
    ->setId("id")
    ->setName("name")
    ->setCountryIso2("countryIso2");

$personal_names_2 = (new Namsor\Client\Model\PersonalNameGeoIn())
    ->setId("id")
    ->setName("name")
    ->setCountryIso2("countryIso2");

$personal_names = [
    $personal_names_1,
    $personal_names_2,
];

$batch_personal_name_geo_in = (new Namsor\Client\Model\BatchPersonalNameGeoIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->communityEngageFullBatch(
        batch_personal_name_geo_in: $batch_personal_name_geo_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#communityEngageFullBatch: {$e->getMessage()}";
}
