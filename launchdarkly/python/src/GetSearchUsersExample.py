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
            project_key=None,
            environment_key=None,
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
        print("Exception when calling Users#get_search_users: %s\n" % e)
