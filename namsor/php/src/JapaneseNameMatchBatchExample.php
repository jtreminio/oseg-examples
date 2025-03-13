<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1_name1 = (new Namsor\Client\Model\FirstLastNameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("Tessai")
    ->setLastName("Tomioka");

$personal_names_1_name2 = (new Namsor\Client\Model\PersonalNameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c43")
    ->setName("富岡 鉄斎");

$personal_names_1 = (new Namsor\Client\Model\MatchPersonalFirstLastNameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c41")
    ->setName1($personal_names_1_name1)
    ->setName2($personal_names_1_name2);

$personal_names = [
    $personal_names_1,
];

$batch_match_personal_first_last_name_in = (new Namsor\Client\Model\BatchMatchPersonalFirstLastNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\JapaneseApi(config: $config))->japaneseNameMatchBatch(
        batch_match_personal_first_last_name_in: $batch_match_personal_first_last_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling JapaneseApi#japaneseNameMatchBatch: {$e->getMessage()}";
}
