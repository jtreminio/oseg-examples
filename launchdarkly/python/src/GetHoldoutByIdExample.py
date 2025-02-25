import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.HoldoutsBetaApi(api_client).get_holdout_by_id(
            project_key=None,
            environment_key=None,
            holdout_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HoldoutsBeta#get_holdout_by_id: %s\n" % e)
