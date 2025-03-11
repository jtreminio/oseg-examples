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
    channel = models.UpdateInboxRequestChannel(
        website_url=None,
        welcome_title=None,
        welcome_tagline=None,
        agent_away_message=None,
        widget_color=None,
    )

    update_inbox_request = models.UpdateInboxRequest(
        enable_auto_assignment=None,
        name=None,
        avatar=None,
        channel=channel,
    )

    try:
        response = api.InboxesApi(api_client).update_inbox(
            account_id=None,
            id=None,
            update_inbox_request=update_inbox_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling InboxesApi#update_inbox: %s\n" % e)
