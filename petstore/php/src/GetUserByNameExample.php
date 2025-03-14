<?php

namespace OSEG\PetStoreExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use OpenAPI;

$config = OpenAPI\Client\Configuration::getDefaultConfiguration();
$config->setAccessToken("YOUR_ACCESS_TOKEN");
// $config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new OpenAPI\Client\Api\UserApi(config: $config))->getUserByName(
        username: "my_username",
    );

    print_r($response);
} catch (OpenAPI\Client\ApiException $e) {
    echo "Exception when calling UserApi#getUserByName: {$e->getMessage()}";
}
