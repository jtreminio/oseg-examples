import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    add_new_agent_to_account_request = models.AddNewAgentToAccountRequest(
        email="email_string",
        name="name_string",
        role="agent",
    )

    try:
        response = api.AgentsApi(api_client).add_new_agent_to_account(
            account_id=0,
            data=add_new_agent_to_account_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AgentsApi#add_new_agent_to_account: %s\n" % e)
