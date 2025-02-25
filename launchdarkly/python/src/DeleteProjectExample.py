import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ProjectsApi(api_client).delete_project(
            project_key=None,
        )
    except ApiException as e:
        print("Exception when calling Projects#delete_project: %s\n" % e)
