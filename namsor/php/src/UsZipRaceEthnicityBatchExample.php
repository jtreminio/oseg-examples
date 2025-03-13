<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameGeoZippedIn())
    ->setId("728767f9-c5b2-4ed3-a071-828077f16552")
    ->setFirstName("Keith")
    ->setLastName("Haring")
    ->setCountryIso2("US")
    ->setZipCode("10019");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_geo_zipped_in = (new Namsor\Client\Model\BatchFirstLastNameGeoZippedIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->usZipRaceEthnicityBatch(
        batch_first_last_name_geo_zipped_in: $batch_first_last_name_geo_zipped_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#usZipRaceEthnicityBatch: {$e->getMessage()}";
}
