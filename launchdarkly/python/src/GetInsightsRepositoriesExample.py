import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.InsightsRepositoriesBetaApi(api_client).get_insights_repositories()

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsRepositoriesBetaApi#get_insights_repositories: %s\n" % e)
