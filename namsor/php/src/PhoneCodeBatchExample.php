<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_with_phone_numbers_1 = (new Namsor\Client\Model\FirstLastNamePhoneNumberIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Jamini")
    ->setLastName("Roy")
    ->setPhoneNumber("09804201420");

$personal_names_with_phone_numbers = [
    $personal_names_with_phone_numbers_1,
];

$batch_first_last_name_phone_number_in = (new Namsor\Client\Model\BatchFirstLastNamePhoneNumberIn())
    ->setPersonalNamesWithPhoneNumbers($personal_names_with_phone_numbers);

try {
    $response = (new Namsor\Client\Api\SocialApi(config: $config))->phoneCodeBatch(
        batch_first_last_name_phone_number_in: $batch_first_last_name_phone_number_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling SocialApi#phoneCodeBatch: {$e->getMessage()}";
}
