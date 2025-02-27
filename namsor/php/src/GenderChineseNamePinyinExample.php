<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->genderChineseNamePinyin(
        chinese_surname_latin: "Dèng",
        chinese_given_name_latin: "Qīngyún",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#genderChineseNamePinyin: {$e->getMessage()}";
}
