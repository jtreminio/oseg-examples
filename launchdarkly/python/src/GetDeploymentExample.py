import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsDeploymentsBetaApi(api_client).get_deployment(
            deployment_id="deploymentID_string",
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsDeploymentsBetaApi#get_deployment: %s\n" % e)
