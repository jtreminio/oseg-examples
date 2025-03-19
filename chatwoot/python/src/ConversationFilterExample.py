import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
)

with ApiClient(configuration) as api_client:
    conversation_filter_request = models.ConversationFilterRequest(
        payload=json.loads("""
            [
                {
                    "attribute_key": "browser_language",
                    "filter_operator": "not_eq",
                    "query_operator": "AND",
                    "values": [
                        "en"
                    ]
                },
                {
                    "attribute_key": "status",
                    "filter_operator": "eq",
                    "query_operator": null,
                    "values": [
                        "pending"
                    ]
                }
            ]
        """),
    )

    try:
        response = api.ConversationsApi(api_client).conversation_filter(
            account_id=0,
            body=conversation_filter_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ConversationsApi#conversation_filter: %s\n" % e)
