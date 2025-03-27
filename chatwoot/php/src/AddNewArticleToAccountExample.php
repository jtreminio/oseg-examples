<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("api_access_token", "USER_API_KEY");

$article_create_update_payload = (new Chatwoot\Client\Model\ArticleCreateUpdatePayload())
    ->setContent(null)
    ->setPosition(null)
    ->setStatus(null)
    ->setTitle(null)
    ->setSlug(null)
    ->setViews(null)
    ->setPortalId(null)
    ->setAccountId(null)
    ->setAuthorId(null)
    ->setCategoryId(null)
    ->setFolderId(null)
    ->setAssociatedArticleId(null)
    ->setMeta(json_decode(<<<'EOD'
        {
            "description": "article description",
            "tags": [
                "article_name"
            ],
            "title": "article title"
        }
    EOD, true));

try {
    $response = (new Chatwoot\Client\Api\HelpCenterApi(config: $config))->addNewArticleToAccount(
        account_id: 0,
        portal_id: 0,
        data: $article_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling HelpCenterApi#addNewArticleToAccount: {$e->getMessage()}";
}
