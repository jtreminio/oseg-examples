<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$post_approval_request_apply_request = (new LaunchDarkly\Client\Model\PostApprovalRequestApplyRequest())
    ->setComment("Looks good, thanks for updating");

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestApplyForFlag(
        project_key: null,
        feature_flag_key: null,
        environment_key: null,
        id: null,
        post_approval_request_apply_request: $post_approval_request_apply_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequestApplyForFlag: {$e->getMessage()}";
}
