<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$flag_link_post = (new LaunchDarkly\Client\Model\FlagLinkPost())
    ->setKey("flag-link-key-123abc")
    ->setDeepLink("https://example.com/archives/123123123")
    ->setTitle("Example link title")
    ->setDescription("Example link description");

try {
    $response = (new LaunchDarkly\Client\Api\FlagLinksBetaApi(config: $config))->createFlagLink(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        flag_link_post: $flag_link_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling FlagLinksBetaApi#createFlagLink: {$e->getMessage()}";
}
