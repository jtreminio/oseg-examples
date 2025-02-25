import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AccountUsageBetaApi(api_client).get_evaluations_usage(
            project_key=None,
            environment_key=None,
            feature_flag_key=None,
            var_from=None,
            to=None,
            tz=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccountUsageBeta#get_evaluations_usage: %s\n" % e)
