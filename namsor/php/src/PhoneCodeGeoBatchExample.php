<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_with_phone_numbers_1 = (new Namsor\Client\Model\FirstLastNamePhoneNumberGeoIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Teniola")
    ->setLastName("Apata")
    ->setPhoneNumber("08186472651")
    ->setCountryIso2("NG")
    ->setCountryIso2Alt("CI");

$personal_names_with_phone_numbers = [
    $personal_names_with_phone_numbers_1,
];

$batch_first_last_name_phone_number_geo_in = (new Namsor\Client\Model\BatchFirstLastNamePhoneNumberGeoIn())
    ->setPersonalNamesWithPhoneNumbers($personal_names_with_phone_numbers);

try {
    $response = (new Namsor\Client\Api\SocialApi(config: $config))->phoneCodeGeoBatch(
        batch_first_last_name_phone_number_geo_in: $batch_first_last_name_phone_number_geo_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling SocialApi#phoneCodeGeoBatch: {$e->getMessage()}";
}
