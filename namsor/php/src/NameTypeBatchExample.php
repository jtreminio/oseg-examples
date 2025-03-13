<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("X-API-KEY", "YOUR_API_KEY");

$proper_nouns_1 = (new Namsor\Client\Model\NameIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setName("Zippo");

$proper_nouns = [
    $proper_nouns_1,
];

$batch_name_in = (new Namsor\Client\Model\BatchNameIn())
    ->setProperNouns($proper_nouns);

try {
    $response = (new Namsor\Client\Api\GeneralApi(config: $config))->nameTypeBatch(
        batch_name_in: $batch_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling GeneralApi#nameTypeBatch: {$e->getMessage()}";
}
