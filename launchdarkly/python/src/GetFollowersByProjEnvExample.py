import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.FollowFlagsApi(api_client).get_followers_by_proj_env(
            project_key=None,
            environment_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FollowFlags#get_followers_by_proj_env: %s\n" % e)
