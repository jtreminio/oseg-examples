<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\ChineseApi(config: $config))->pinyinChineseName(
        chinese_name: "赵丽颖",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling ChineseApi#pinyinChineseName: {$e->getMessage()}";
}
