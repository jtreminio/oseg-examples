import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsFlagEventsBetaApi(api_client).get_flag_events(
            project_key=None,
            environment_key=None,
            application_key=None,
            query=None,
            impact_size=None,
            has_experiments=None,
            var_global=None,
            expand=None,
            limit=None,
            var_from=None,
            to=None,
            after=None,
            before=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsFlagEventsBeta#get_flag_events: %s\n" % e)
