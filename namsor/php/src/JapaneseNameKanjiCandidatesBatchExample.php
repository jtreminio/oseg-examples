<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Sanae")
    ->setLastName("Yamamoto");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_in = (new Namsor\Client\Model\BatchFirstLastNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\JapaneseApi(config: $config))->japaneseNameKanjiCandidatesBatch(
        batch_first_last_name_in: $batch_first_last_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling JapaneseApi#japaneseNameKanjiCandidatesBatch: {$e->getMessage()}";
}
