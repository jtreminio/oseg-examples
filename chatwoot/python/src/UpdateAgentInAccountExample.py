import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    update_agent_in_account_request = models.UpdateAgentInAccountRequest(
        role=None,
        availability=None,
        auto_offline=None,
    )

    try:
        response = api.AgentsApi(api_client).update_agent_in_account(
            account_id=None,
            id=None,
            update_agent_in_account_request=update_agent_in_account_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AgentsApi#update_agent_in_account: %s\n" % e)
