<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameIn())
    ->setId("id")
    ->setFirstName("firstName")
    ->setLastName("lastName");

$personal_names_2 = (new Namsor\Client\Model\FirstLastNameIn())
    ->setId("id")
    ->setFirstName("firstName")
    ->setLastName("lastName");

$personal_names = [
    $personal_names_1,
    $personal_names_2,
];

$batch_first_last_name_in = (new Namsor\Client\Model\BatchFirstLastNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\JapaneseApi(config: $config))->genderJapaneseNamePinyinBatch(
        batch_first_last_name_in: $batch_first_last_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling JapaneseApi#genderJapaneseNamePinyinBatch: {$e->getMessage()}";
}
