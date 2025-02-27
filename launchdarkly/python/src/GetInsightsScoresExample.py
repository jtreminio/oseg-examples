import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsScoresBetaApi(api_client).get_insights_scores(
            project_key=None,
            environment_key=None,
            application_key=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsScoresBetaApi#get_insights_scores: %s\n" % e)
