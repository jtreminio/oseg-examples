<?php

namespace OSEG\PetStoreExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use OpenAPI;

$config = OpenAPI\Client\Configuration::getDefaultConfiguration();
$config->setAccessToken("YOUR_ACCESS_TOKEN");

try {
    (new OpenAPI\Client\Api\PetApi(config: $config))->updatePetWithForm(
        pet_id: 12345,
        name: "Pet's new name",
        status: "sold",
    );
} catch (OpenAPI\Client\ApiException $e) {
    echo "Exception when calling PetApi#updatePetWithForm: {$e->getMessage()}";
}
