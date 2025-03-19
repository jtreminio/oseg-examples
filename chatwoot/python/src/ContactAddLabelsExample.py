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
    contact_add_labels_request = models.ContactAddLabelsRequest(
        labels=[
        ],
    )

    try:
        response = api.ContactLabelsApi(api_client).contact_add_labels(
            account_id=0,
            contact_identifier="contact_identifier_string",
            data=contact_add_labels_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactLabelsApi#contact_add_labels: %s\n" % e)
