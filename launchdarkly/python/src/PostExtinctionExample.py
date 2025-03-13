import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    extinction_1 = models.Extinction(
        revision="a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
        message="Remove flag for launched feature",
        time=1706701522000,
        flagKey="enable-feature",
        projKey="default",
    )

    extinction = [
        extinction_1,
    ]

    try:
        api.CodeReferencesApi(api_client).post_extinction(
            repo="repo_string",
            branch="branch_string",
            extinction=extinction,
        )
    except ApiException as e:
        print("Exception when calling CodeReferencesApi#post_extinction: %s\n" % e)
