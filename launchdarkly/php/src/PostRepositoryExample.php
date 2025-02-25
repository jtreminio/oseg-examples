<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("ApiKey", "YOUR_API_KEY");

$repository_post = (new LaunchDarkly\Client\Model\RepositoryPost())
    ->setName("LaunchDarkly-Docs")
    ->setSourceLink("https://github.com/launchdarkly/LaunchDarkly-Docs")
    ->setCommitUrlTemplate(<<<'EOD'
        https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}
        EOD)
    ->setHunkUrlTemplate(<<<'EOD'
        https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}
        EOD)
    ->setType(LaunchDarkly\Client\Model\RepositoryPost::TYPE_GITHUB)
    ->setDefaultBranch("main");

try {
    $response = (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->postRepository(
        repository_post: $repository_post,
    );

    print_r($response);
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferences#postRepository: {$e->getMessage()}";
}
