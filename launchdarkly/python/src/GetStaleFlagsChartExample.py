import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsChartsBetaApi(api_client).get_stale_flags_chart(
            project_key=None,
            environment_key=None,
            application_key=None,
            group_by=None,
            maintainer_id=None,
            maintainer_team_key=None,
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsChartsBetaApi#get_stale_flags_chart: %s\n" % e)
