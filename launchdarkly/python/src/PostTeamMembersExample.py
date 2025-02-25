import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.TeamsApi(api_client).post_team_members(
            team_key=None,
            file=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Teams#post_team_members: %s\n" % e)
