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
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestApply(
        id: null,
        post_approval_request_apply_request: $post_approval_request_apply_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequestApply: {$e->getMessage()}";
}
