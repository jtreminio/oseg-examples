<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$create_flag_config_approval_request_request = (new LaunchDarkly\Client\Model\CreateFlagConfigApprovalRequestRequest())
    ->setDescription("Requesting to update targeting")
    ->setInstructions([])
    ->setComment("optional comment")
    ->setExecutionDate(1706701522000)
    ->setOperatingOnId("6297ed79dee7dc14e1f9a80c")
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ]);

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestForFlag(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        create_flag_config_approval_request_request: $create_flag_config_approval_request_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequestForFlag: {$e->getMessage()}";
}
