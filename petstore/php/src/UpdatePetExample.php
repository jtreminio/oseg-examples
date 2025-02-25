<?php

namespace OSEG\PetStoreExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use OpenAPI;

$config = OpenAPI\Client\Configuration::getDefaultConfiguration();
$config->setAccessToken("YOUR_ACCESS_TOKEN");

$category = (new OpenAPI\Client\Model\Category())
    ->setId(12345)
    ->setName("Category_Name");

$tags_1 = (new OpenAPI\Client\Model\Tag())
    ->setId(12345)
    ->setName("tag_1");

$tags_2 = (new OpenAPI\Client\Model\Tag())
    ->setId(98765)
    ->setName("tag_2");

$tags = [
    $tags_1,
    $tags_2,
];

$pet = (new OpenAPI\Client\Model\Pet())
    ->setName("My pet name")
    ->setPhotoUrls([
        "https://example.com/picture_1.jpg",
        "https://example.com/picture_2.jpg",
    ])
    ->setId(12345)
    ->setStatus(OpenAPI\Client\Model\Pet::STATUS_AVAILABLE)
    ->setCategory($category)
    ->setTags($tags);

try {
    $response = (new OpenAPI\Client\Api\PetApi(config: $config))->updatePet(
        pet: $pet,
    );

    print_r($response);
} catch (OpenAPI\Client\ApiException $e) {
    echo "Exception when calling Pet#updatePet: {$e->getMessage()}";
}
