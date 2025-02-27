<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameSubdivisionIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Akash")
    ->setLastName("Sharma")
    ->setSubdivisionIso("IN-PB");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_subdivision_in = (new Namsor\Client\Model\BatchFirstLastNameSubdivisionIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\IndianApi(config: $config))->religionIndianBatch(
        batch_first_last_name_subdivision_in: $batch_first_last_name_subdivision_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling IndianApi#religionIndianBatch: {$e->getMessage()}";
}
