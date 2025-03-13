<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\PersonalNameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setName("谢晓亮");

$personal_names = [
    $personal_names_1,
];

$batch_personal_name_in = (new Namsor\Client\Model\BatchPersonalNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->genderChineseNameBatch(
        batch_personal_name_in: $batch_personal_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#genderChineseNameBatch: {$e->getMessage()}";
}
