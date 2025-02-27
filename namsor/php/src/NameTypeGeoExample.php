<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

try {
    $response = (new Namsor\Client\Api\GeneralApi(config: $config))->nameTypeGeo(
        proper_noun: "Edi Gathegi",
        country_iso2: "KE",
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling GeneralApi#nameTypeGeo: {$e->getMessage()}";
}
