import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    portal_create_update_payload = models.PortalCreateUpdatePayload(
        archived=None,
        color="add color HEX string, \"#fffff\"",
        custom_domain="https://chatwoot.help/.",
        header_text="Handbook",
        homepage_link="https://www.chatwoot.com/",
        name=None,
        slug=None,
        page_title=None,
        account_id=None,
    )

    try:
        response = api.HelpCenterApi(api_client).update_new_portal_to_account(
            account_id=None,
            portal_create_update_payload=portal_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HelpCenterApi#update_new_portal_to_account: %s\n" % e)
