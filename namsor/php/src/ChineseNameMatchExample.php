<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->chineseNameMatch(
        chinese_surname_latin: "Yu",
        chinese_given_name_latin: "Hong",
        chinese_name: "喻红",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#chineseNameMatch: {$e->getMessage()}";
}
