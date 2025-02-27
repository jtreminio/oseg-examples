import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    post_insight_group_params = models.PostInsightGroupParams(
        name="Production - All Apps",
        key="default-production-all-apps",
        projectKey="default",
        environmentKey="production",
        applicationKeys=[
            "billing-service",
            "inventory-service",
        ],
    )

    try:
        response = api.InsightsScoresBetaApi(api_client).create_insight_group(
            post_insight_group_params=post_insight_group_params,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InsightsScoresBetaApi#create_insight_group: %s\n" % e)
