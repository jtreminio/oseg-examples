<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$access_token_post = (new LaunchDarkly\Client\Model\AccessTokenPost())
    ->setName(null)
    ->setDescription(null)
    ->setRole(LaunchDarkly\Client\Model\AccessTokenPost::ROLE_READER)
    ->setServiceToken(null)
    ->setDefaultApiVersion(null)
    ->setCustomRoleIds(null);

try {
    $response = (new LaunchDarkly\Client\Api\AccessTokensApi(config: $config))->postToken(
        access_token_post: $access_token_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling AccessTokensApi#postToken: {$e->getMessage()}";
}
