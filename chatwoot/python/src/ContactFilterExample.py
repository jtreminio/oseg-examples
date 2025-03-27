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
        attribute_key="name",
        filter_operator="equal_to",
        query_operator="AND",
        values=[
            "en",
        ],
    )

    payload_2 = models.ContactFilterRequestPayloadInner(
        attribute_key="country_code",
        filter_operator="equal_to",
        values=[
            "us",
        ],
    )

    payload = [
        payload_1,
        payload_2,
    ]

    contact_filter_request = models.ContactFilterRequest(
        payload=payload,
    )

    try:
        response = api.ContactsApi(api_client).contact_filter(
            account_id=0,
            body=contact_filter_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ContactsApi#contact_filter: %s\n" % e)
