import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsDeploymentsBetaApi(api_client).get_deployments(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            application_key=None,
            limit=None,
            expand=None,
            var_from=None,
            to=None,
            after=None,
            before=None,
            kind=None,
            status=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsDeploymentsBetaApi#get_deployments: %s\n" % e)
