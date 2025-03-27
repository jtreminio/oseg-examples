import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
    # api_key={"agentBotApiKey": "AGENT_BOT_API_KEY"},
    # api_key={"platformAppApiKey": "PLATFORM_APP_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ContactLabelsApi(api_client).list_all_labels_of_a_contact(
            account_id=0,
            contact_identifier="contact_identifier_string",
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactLabelsApi#list_all_labels_of_a_contact: %s\n" % e)
