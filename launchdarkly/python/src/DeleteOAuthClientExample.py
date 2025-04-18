import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.OAuth2ClientsApi(api_client).delete_o_auth_client(
            client_id="clientId_string",
        )
    except ApiException as e:
        print("Exception when calling OAuth2ClientsApi#delete_o_auth_client: %s\n" % e)
