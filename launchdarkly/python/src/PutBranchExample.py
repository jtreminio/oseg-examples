import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    references_1_hunks_1 = models.HunkRep(
        startingLineNumber=45,
        lines="var enableFeature = 'enable-feature';",
        projKey="default",
        flagKey="enable-feature",
        aliases=[
            "enableFeature",
            "EnableFeature",
        ],
    )

    references_1_hunks = [
        references_1_hunks_1,
    ]

    references_1 = models.ReferenceRep(
        path="/main/index.js",
        hint="javascript",
        hunks=references_1_hunks,
    )

    references = [
        references_1,
    ]

    put_branch = models.PutBranch(
        name="main",
        head="a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
        syncTime=1706701522000,
        updateSequenceId=25,
        commitTime=1706701522000,
        references=references,
    )

    try:
        api.CodeReferencesApi(api_client).put_branch(
            repo=None,
            branch=None,
            put_branch=put_branch,
        )
    except ApiException as e:
        print("Exception when calling CodeReferencesApi#put_branch: %s\n" % e)
