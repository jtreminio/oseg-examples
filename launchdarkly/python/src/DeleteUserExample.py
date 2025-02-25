import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.UsersApi(api_client).delete_user(
            project_key=None,
            environment_key=None,
            user_key=None,
        )
    except ApiException as e:
        print("Exception when calling Users#delete_user: %s\n" % e)
