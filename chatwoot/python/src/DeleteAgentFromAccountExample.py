import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.AgentsApi(api_client).delete_agent_from_account(
            account_id=None,
            id=None,
        )
    except ApiException as e:
        print("Exception when calling AgentsApi#delete_agent_from_account: %s\n" % e)
