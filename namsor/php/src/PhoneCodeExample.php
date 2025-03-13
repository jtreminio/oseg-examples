<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\SocialApi(config: $config))->phoneCode(
        first_name: "Jamini",
        last_name: "Roy",
        phone_number: "09804201420",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling SocialApi#phoneCode: {$e->getMessage()}";
}
