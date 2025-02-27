<?php

namespace OSEG\NamsorExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Namsor;

$config = Namsor\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_key", "YOUR_API_KEY");

$personal_names_1 = (new Namsor\Client\Model\FirstLastNameIn())
    ->setId("9a3283bd-4efb-4b7b-906c-e3f3c03ea6a4")
    ->setFirstName("Keith")
    ->setLastName("Haring");

$personal_names = [
    $personal_names_1,
];

$batch_first_last_name_in = (new Namsor\Client\Model\BatchFirstLastNameIn())
    ->setPersonalNames($personal_names);

try {
    $response = (new Namsor\Client\Api\PersonalApi(config: $config))->countryFnLnBatch(
        batch_first_last_name_in: $batch_first_last_name_in,
    );

    print_r($response);
} catch (Namsor\Client\ApiException $e) {
    echo "Exception when calling PersonalApi#countryFnLnBatch: {$e->getMessage()}";
}
