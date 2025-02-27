<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\IndianApi(config: $config))->religion(
        sub_division_iso31662: "IN-UP",
        personal_name_full: "Akash Sharma",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling IndianApi#religion: {$e->getMessage()}";
}
