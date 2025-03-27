import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    automation_rule_create_update_payload = models.AutomationRuleCreateUpdatePayload(
        name="Add label on message create event",
        description="Add label support and sales on message create event if incoming message content contains text help",
        event_name="message_created",
        actions=json.loads("""
            [
                {
                    "action_name": "add_label",
                    "action_params": [
                        "support"
                    ]
                }
            ]
        """),
        conditions=json.loads("""
            [
                {
                    "attribute_key": "content",
                    "filter_operator": "contains",
                    "query_operator": "nil",
                    "values": [
                        "help"
                    ]
                }
            ]
        """),
    )

    try:
        response = api.AutomationRuleApi(api_client).add_new_automation_rule_to_account(
            account_id=0,
            data=automation_rule_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AutomationRuleApi#add_new_automation_rule_to_account: %s\n" % e)
