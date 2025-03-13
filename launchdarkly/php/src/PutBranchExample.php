<?php

namespace OSEG\LaunchDarklyExamples;

require_once __DIR__ . '/../vendor/autoload.php';

use SplFileObject;
use LaunchDarkly;

$config = LaunchDarkly\Client\Configuration::getDefaultConfiguration();
$config->setApiKey("Authorization", "YOUR_API_KEY");

$references_1_hunks_1 = (new LaunchDarkly\Client\Model\HunkRep())
    ->setStartingLineNumber(45)
    ->setLines("var enableFeature = 'enable-feature';")
    ->setProjKey("default")
    ->setFlagKey("enable-feature")
    ->setAliases([
        "enableFeature",
        "EnableFeature",
    ]);

$references_1_hunks = [
    $references_1_hunks_1,
];

$references_1 = (new LaunchDarkly\Client\Model\ReferenceRep())
    ->setPath("/main/index.js")
    ->setHint("javascript")
    ->setHunks($references_1_hunks);

$references = [
    $references_1,
];

$put_branch = (new LaunchDarkly\Client\Model\PutBranch())
    ->setName("main")
    ->setHead("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
    ->setSyncTime(1706701522000)
    ->setUpdateSequenceId(25)
    ->setCommitTime(1706701522000)
    ->setReferences($references);

try {
    (new LaunchDarkly\Client\Api\CodeReferencesApi(config: $config))->putBranch(
        repo: null,
        branch: null,
        put_branch: $put_branch,
    );
} catch (LaunchDarkly\Client\ApiException $e) {
    echo "Exception when calling CodeReferencesApi#putBranch: {$e->getMessage()}";
}
