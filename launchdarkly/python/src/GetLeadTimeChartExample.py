import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsChartsBetaApi(api_client).get_lead_time_chart(
            project_key="projectKey_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsChartsBetaApi#get_lead_time_chart: %s\n" % e)
