import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    repository_post = models.RepositoryPost(
        name="LaunchDarkly-Docs",
        sourceLink="https://github.com/launchdarkly/LaunchDarkly-Docs",
        commitUrlTemplate="https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}",
        hunkUrlTemplate="https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}",
        type="github",
        defaultBranch="main",
    )

    try:
        response = api.CodeReferencesApi(api_client).post_repository(
            repository_post=repository_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CodeReferences#post_repository: %s\n" % e)
