import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.AutomationRuleApi(api_client).get_account_automation_rule(
            account_id=None,
            page=1,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AutomationRuleApi#get_account_automation_rule: %s\n" % e)
