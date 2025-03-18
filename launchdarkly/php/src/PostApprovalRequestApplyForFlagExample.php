<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$post_approval_request_apply_request = (new LaunchDarkly\Client\Model\PostApprovalRequestApplyRequest())
    ->setComment("Looks good, thanks for updating");

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestApplyForFlag(
        project_key: "projectKey_string",
        feature_flag_key: "featureFlagKey_string",
        environment_key: "environmentKey_string",
        id: "id_string",
        post_approval_request_apply_request: $post_approval_request_apply_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequestApplyForFlag: {$e->getMessage()}";
}
