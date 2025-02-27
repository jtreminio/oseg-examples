<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$proper_nouns_1 = (new Namsor\Client\Model\NameGeoIn())
    ->setId("e630dda5-13b3-42c5-8f1d-648aa8a21c42")
    ->setName("Edi Gathegi")
    ->setCountryIso2("KE");

$proper_nouns = [
    $proper_nouns_1,
];

$batch_name_geo_in = (new Namsor\Client\Model\BatchNameGeoIn())
    ->setProperNouns($proper_nouns);

try {
    $response = (new Namsor\Client\Api\GeneralApi(config: $config))->nameTypeGeoBatch(
        batch_name_geo_in: $batch_name_geo_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling GeneralApi#nameTypeGeoBatch: {$e->getMessage()}";
}
