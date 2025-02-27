<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameGeoIn())
    ->setId("0d7d6417-0bbb-4205-951d-b3473f605b56")
    ->setFirstName("Keith")
    ->setLastName("Haring")
    ->setCountryIso2("US");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_geo_in = (new Namsor\Client\Model\BatchFirstLastNameGeoIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->diasporaBatch(
        batch_first_last_name_geo_in: $batch_first_last_name_geo_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#diasporaBatch: {$e->getMessage()}";
}
