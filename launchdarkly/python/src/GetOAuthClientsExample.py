import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.OAuth2ClientsApi(api_client).get_o_auth_clients()

        pprint(response)
    except ApiException as e:
        print("Exception when calling OAuth2ClientsApi#get_o_auth_clients: %s\n" % e)
