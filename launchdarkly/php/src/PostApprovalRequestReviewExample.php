<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$post_approval_request_review_request = (new LaunchDarkly\Client\Model\PostApprovalRequestReviewRequest())
    ->setKind(LaunchDarkly\Client\Model\PostApprovalRequestReviewRequest::KIND_APPROVE)
    ->setComment("Looks good, thanks for updating");

try {
    $response = (new LaunchDarkly\Client\Api\ApprovalsApi(config: $config))->postApprovalRequestReview(
        id: null,
        post_approval_request_review_request: $post_approval_request_review_request,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling ApprovalsApi#postApprovalRequestReview: {$e->getMessage()}";
}
