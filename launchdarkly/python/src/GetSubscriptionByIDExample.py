import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.IntegrationAuditLogSubscriptionsApi(api_client).get_subscription_by_id(
            integration_key=None,
            id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationAuditLogSubscriptionsApi#get_subscription_by_id: %s\n" % e)
