<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameGeoSubdivisionIn())
    ->setId("id")
    ->setFirstName("firstName")
    ->setLastName("lastName")
    ->setCountryIso2("countryIso2")
    ->setSubdivisionIso("subdivisionIso");

$personal_names_2 = (new Namsor\Client\Model\FirstLastNameGeoSubdivisionIn())
    ->setId("id")
    ->setFirstName("firstName")
    ->setLastName("lastName")
    ->setCountryIso2("countryIso2")
    ->setSubdivisionIso("subdivisionIso");

$personal_names = [
    $personal_names_1,
    $personal_names_2,
];

$batch_first_last_name_geo_subdivision_in = (new Namsor\Client\Model\BatchFirstLastNameGeoSubdivisionIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->religionBatch(
        batch_first_last_name_geo_subdivision_in: $batch_first_last_name_geo_subdivision_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#religionBatch: {$e->getMessage()}";
}
