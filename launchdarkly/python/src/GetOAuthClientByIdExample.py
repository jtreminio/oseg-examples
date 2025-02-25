import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.OAuth2ClientsApi(api_client).get_o_auth_client_by_id(
            client_id=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling OAuth2Clients#get_o_auth_client_by_id: %s\n" % e)
