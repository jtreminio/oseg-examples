import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.UserSettingsApi(api_client).get_user_flag_settings(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            user_key="userKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UserSettingsApi#get_user_flag_settings: %s\n" % e)
