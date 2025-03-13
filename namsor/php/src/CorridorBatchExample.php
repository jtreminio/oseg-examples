<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$corridor_from_to_1_first_last_name_geo_from = (new Namsor\Client\Model\FirstLastNameGeoIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Ada")
    ->setLastName("Lovelace")
    ->setCountryIso2("GB");

$corridor_from_to_1_first_last_name_geo_to = (new Namsor\Client\Model\FirstLastNameGeoIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Nicolas")
    ->setLastName("Tesla")
    ->setCountryIso2("US");

$corridor_from_to_1 = (new Namsor\Client\Model\CorridorIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstLastNameGeoFrom($corridor_from_to_1_first_last_name_geo_from)
    ->setFirstLastNameGeoTo($corridor_from_to_1_first_last_name_geo_to);

$corridor_from_to = [
    $corridor_from_to_1,
];

$batch_corridor_in = (new Namsor\Client\Model\BatchCorridorIn())
    ->setCorridorFromTo($corridor_from_to);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->corridorBatch(
        batch_corridor_in: $batch_corridor_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#corridorBatch: {$e->getMessage()}";
}
