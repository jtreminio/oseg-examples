import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    update_agents_in_inbox_request = models.UpdateAgentsInInboxRequest(
        inbox_id=None,
        user_ids=[
        ],
    )

    try:
        response = api.InboxesApi(api_client).update_agents_in_inbox(
            account_id=None,
            update_agents_in_inbox_request=update_agents_in_inbox_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InboxesApi#update_agents_in_inbox: %s\n" % e)
