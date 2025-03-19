<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();

try {
    (new Chatwoot\Client\Api\CSATSurveyPageApi(config: $config))->getCsatSurveyPage(
        conversation_uuid: 0,
    );
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling CSATSurveyPageApi#getCsatSurveyPage: {$e->getMessage()}";
}
