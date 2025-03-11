import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    delete_agent_in_inbox_request = models.DeleteAgentInInboxRequest(
        inbox_id=None,
        user_ids=[
        ],
    )

    try:
        api.InboxesApi(api_client).delete_agent_in_inbox(
            account_id=None,
            delete_agent_in_inbox_request=delete_agent_in_inbox_request,
        )
    except ApiException as e:
        print("Exception when calling InboxesApi#delete_agent_in_inbox: %s\n" % e)
