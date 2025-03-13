<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->chineseNameCandidates(
        chinese_surname_latin: "Hong",
        chinese_given_name_latin: "Yu",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#chineseNameCandidates: {$e->getMessage()}";
}
