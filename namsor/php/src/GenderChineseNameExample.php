<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->genderChineseName(
        chinese_name: "谢晓亮",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#genderChineseName: {$e->getMessage()}";
}
