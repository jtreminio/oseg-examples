import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.InsightsRepositoriesBetaApi(api_client).delete_repository_project(
            repository_key=None,
            project_key=None,
        )
    except ApiException as e:
        print("Exception when calling InsightsRepositoriesBetaApi#delete_repository_project: %s\n" % e)
