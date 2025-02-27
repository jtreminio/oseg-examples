import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    oauth_client_post = models.OauthClientPost(
        name=None,
        redirectUri=None,
        description=None,
    )

    try:
        response = api.OAuth2ClientsApi(api_client).create_o_auth2_client(
            oauth_client_post=oauth_client_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling OAuth2ClientsApi#create_o_auth2_client: %s\n" % e)
