import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.UserSettingsApi(api_client).get_user_flag_setting(
            project_key=None,
            environment_key=None,
            user_key=None,
            feature_flag_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UserSettingsApi#get_user_flag_setting: %s\n" % e)
