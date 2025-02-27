<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\PersonalNameIn())
    ->setId("0f472330-11a9-49ad-a0f5-bcac90a3f6bf")
    ->setName("Keith Haring");

$personal_names = [
    $personal_names_1,
];

$batch_personal_name_in = (new Namsor\Client\Model\BatchPersonalNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->genderFullBatch(
        batch_personal_name_in: $batch_personal_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#genderFullBatch: {$e->getMessage()}";
}
