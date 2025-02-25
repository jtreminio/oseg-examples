import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    access_token_post = models.AccessTokenPost(
        role="reader",
    )

    try:
        response = api.AccessTokensApi(api_client).post_token(
            access_token_post=access_token_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AccessTokens#post_token: %s\n" % e)
