import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.UsersApi(api_client).get_search_users(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            q=None,
            limit=None,
            offset=None,
            after=None,
            sort=None,
            search_after=None,
            filter=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UsersApi#get_search_users: %s\n" % e)
