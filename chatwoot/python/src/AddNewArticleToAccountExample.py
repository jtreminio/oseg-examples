import json
from datetime import date, datetime
from pprint import pprint

from chatwoot_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"userApiKey": "USER_API_KEY"},
)

with ApiClient(configuration) as api_client:
    article_create_update_payload = models.ArticleCreateUpdatePayload(
        content=None,
        position=None,
        status=None,
        title=None,
        slug=None,
        views=None,
        portal_id=None,
        account_id=None,
        author_id=None,
        category_id=None,
        folder_id=None,
        associated_article_id=None,
    )

    try:
        response = api.HelpCenterApi(api_client).add_new_article_to_account(
            account_id=None,
            portal_id=None,
            article_create_update_payload=article_create_update_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling HelpCenterApi#add_new_article_to_account: %s\n" % e)
