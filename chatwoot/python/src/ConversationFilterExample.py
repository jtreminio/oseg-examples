import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    payload_1 = models.ContactFilterRequestPayloadInner(
        attribute_key="browser_language",
        filter_operator="not_equal_to",
        query_operator="AND",
        values=[
            "en",
        ],
    )

    payload_2 = models.ContactFilterRequestPayloadInner(
        attribute_key="status",
        filter_operator="equal_to",
        values=[
            "pending",
        ],
    )

    payload = [
        payload_1,
        payload_2,
    ]

    conversation_filter_request = models.ConversationFilterRequest(
        payload=payload,
    )

    try:
        response = api.ConversationsApi(api_client).conversation_filter(
            account_id=123,
            body=conversation_filter_request,
            page=1,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsApi#conversation_filter: %s\n" % e)
