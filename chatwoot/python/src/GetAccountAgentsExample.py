import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AgentsApi(api_client).get_account_agents(
            account_id=0,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AgentsApi#get_account_agents: %s\n" % e)
