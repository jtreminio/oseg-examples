<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameGenderIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setFirstName("LiYing")
    ->setLastName("Zhao")
    ->setGender("female");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_gender_in = (new Namsor\Client\Model\BatchFirstLastNameGenderIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->chineseNameCandidatesGenderBatch(
        batch_first_last_name_gender_in: $batch_first_last_name_gender_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#chineseNameCandidatesGenderBatch: {$e->getMessage()}";
}
