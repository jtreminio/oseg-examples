import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    flag_link_post = models.FlagLinkPost(
        key="flag-link-key-123abc",
        deepLink="https://example.com/archives/123123123",
        title="Example link title",
        description="Example link description",
    )

    try:
        response = api.FlagLinksBetaApi(api_client).create_flag_link(
            project_key=None,
            feature_flag_key=None,
            flag_link_post=flag_link_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FlagLinksBeta#create_flag_link: %s\n" % e)
