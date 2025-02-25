import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.UserSettingsApi(api_client).get_expiring_flags_for_user(
            project_key=None,
            user_key=None,
            environment_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UserSettings#get_expiring_flags_for_user: %s\n" % e)
