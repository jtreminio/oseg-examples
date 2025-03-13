import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsChartsBetaApi(api_client).get_release_frequency_chart(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            application_key=None,
            has_experiments=None,
            var_global=None,
            group_by=None,
            var_from=None,
            to=None,
            bucket_type=None,
            bucket_ms=None,
            expand=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsChartsBetaApi#get_release_frequency_chart: %s\n" % e)
