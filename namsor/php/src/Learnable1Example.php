<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    (new Namsor\Client\Api\AdminApi(config: $config))->learnable1(
        source: "source",
        learnable: true,
    );
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling AdminApi#learnable1: {$e->getMessage()}";
}
