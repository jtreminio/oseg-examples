<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$create_approval_request_request = (new LaunchDarkly\Client\Model\CreateApprovalRequestRequest())
    ->setResourceId("proj/projKey:env/envKey:flag/flagKey")
    ->setDescription("Requesting to update targeting")
    ->setInstructions([])
    ->setComment("optional comment")
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setIntegrationConfig(null);

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequest(
        create_approval_request_request: $create_approval_request_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequest: {$e->getMessage()}";
}
