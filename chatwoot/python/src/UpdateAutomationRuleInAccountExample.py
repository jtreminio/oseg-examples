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
        active=None,
    )

    try:
        response = api.AutomationRuleApi(api_client).update_automation_rule_in_account(
            account_id=None,
            id=None,
            automation_rule_create_update_payload=automation_rule_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AutomationRuleApi#update_automation_rule_in_account: %s\n" % e)
