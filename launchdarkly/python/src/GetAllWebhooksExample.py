import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.WebhooksApi(api_client).get_all_webhooks()

        pprint(response)
    except ApiException as e:
        print("Exception when calling WebhooksApi#get_all_webhooks: %s\n" % e)
