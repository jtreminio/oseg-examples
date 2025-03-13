<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$oauth_client_post = (new LaunchDarkly\Client\Model\OauthClientPost())
    ->setName(null)
    ->setRedirectUri(null)
    ->setDescription(null);

try {
    $response = (new LaunchDarkly\Client\Api\OAuth2ClientsApi(config: $config))->createOAuth2Client(
        oauth_client_post: $oauth_client_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling OAuth2ClientsApi#createOAuth2Client: {$e->getMessage()}";
}
