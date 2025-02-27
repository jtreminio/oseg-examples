import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsPullRequestsBetaApi(api_client).get_pull_requests(
            project_key=None,
            environment_key=None,
            application_key=None,
            status=None,
            query=None,
            limit=None,
            expand=None,
            sort=None,
            var_from=None,
            to=None,
            after=None,
            before=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsPullRequestsBetaApi#get_pull_requests: %s\n" % e)
