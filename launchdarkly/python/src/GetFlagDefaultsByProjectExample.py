import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ProjectsApi(api_client).get_flag_defaults_by_project(
            project_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Projects#get_flag_defaults_by_project: %s\n" % e)
