<?php

namespace OSEG\PetStoreExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use OpenAPI;

$config = OpenAPI\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    (new OpenAPI\Client\Api\UserApi(config: $config))->deleteUser(
        username: "my_username",
    );
} catch (OpenAPI\Client\ApiException $e) {
    echo "Exception when calling UserApi#deleteUser: {$e->getMessage()}";
}
