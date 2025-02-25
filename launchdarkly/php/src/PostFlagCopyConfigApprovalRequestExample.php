<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$source = (new LaunchDarkly\Client\Model\SourceFlag())
    ->setKey("environment-key-123abc")
    ->setVersion(1);

$create_copy_flag_config_approval_request_request = (new LaunchDarkly\Client\Model\CreateCopyFlagConfigApprovalRequestRequest())
    ->setDescription("copy flag settings to another environment")
    ->setComment("optional comment")
    ->setNotifyMemberIds([
        "1234a56b7c89d012345e678f",
    ])
    ->setNotifyTeamKeys([
        "example-reviewer-team",
    ])
    ->setIncludedActions([
        LaunchDarkly\Client\Model\CreateCopyFlagConfigApprovalRequestRequest::INCLUDED_ACTIONS_UPDATE_ON,
    ])
    ->setExcludedActions([
        LaunchDarkly\Client\Model\CreateCopyFlagConfigApprovalRequestRequest::EXCLUDED_ACTIONS_UPDATE_ON,
    ])
    ->setSource($source);

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postFlagCopyConfigApprovalRequest(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        create_copy_flag_config_approval_request_request: $create_copy_flag_config_approval_request_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling Approvals#postFlagCopyConfigApprovalRequest: {$e->getMessage()}";
}
