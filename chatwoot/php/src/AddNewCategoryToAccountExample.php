<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$category_create_update_payload = (new Chatwoot\Client\Model\CategoryCreateUpdatePayload())
    ->setDescription(null)
    ->setLocale("en/es")
    ->setName(null)
    ->setSlug(null)
    ->setPosition(null)
    ->setPortalId(null)
    ->setAccountId(null)
    ->setAssociatedCategoryId(null)
    ->setParentCategoryId(null);

try {
    $response = (new Chatwoot\Client\Api\HelpCenterApi(config: $config))->addNewCategoryToAccount(
        account_id: null,
        portal_id: null,
        data: category_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling HelpCenterApi#addNewCategoryToAccount: {$e->getMessage()}";
}
