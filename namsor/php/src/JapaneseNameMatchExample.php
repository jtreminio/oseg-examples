<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\JapaneseApi(config: $config))->japaneseNameMatch(
        japanese_surname_latin: "Tessai",
        japanese_given_name_latin: "Tomioka",
        japanese_name: "富岡 鉄斎",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling JapaneseApi#japaneseNameMatch: {$e->getMessage()}";
}
