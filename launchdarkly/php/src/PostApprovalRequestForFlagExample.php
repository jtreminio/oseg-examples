<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$create_flag_config_approval_request_request = (new LaunchDarkly\Client\Model\CreateFlagConfigApprovalRequestRequest())
    ->setDescription("Requesting to update targeting")
    ->setInstructions(json_decode(<<<'EOD'
        []
    EOD, true))
    ->setComment("optional comment")
    ->setExecutionDate(1706701522000)
    ->setOperatingOnId("6297ed79dee7dc14e1f9a80c")
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setIntegrationConfig(null);

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestForFlag(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        create_flag_config_approval_request_request: $create_flag_config_approval_request_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Approvals#postApprovalRequestForFlag: {$e->getMessage()}";
}
