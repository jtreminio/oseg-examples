<?php

namespace OSEG\ChatwootExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use Chatwoot;

$config = Chatwoot\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("userApiKey", "USER_API_KEY");

$portal_create_update_payload = (new Chatwoot\Client\Model\PortalCreateUpdatePayload())
    ->setArchived(null)
    ->setColor("add color HEX string, \"#fffff\"")
    ->setCustomDomain("https://chatwoot.help/.")
    ->setHeaderText("Handbook")
    ->setHomepageLink("https://www.chatwoot.com/")
    ->setName(null)
    ->setSlug(null)
    ->setPageTitle(null)
    ->setAccountId(null);

try {
    $response = (new Chatwoot\Client\Api\HelpCenterApi(config: $config))->addNewPortalToAccount(
        account_id: null,
        data: portal_create_update_payload,
    );

    print_r($response);
} catch (Chatwoot\Client\ApiException $e) {
    echo "Exception when calling HelpCenterApi#addNewPortalToAccount: {$e->getMessage()}";
}
