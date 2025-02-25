import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    ai_config_post = models.AIConfigPost(
        key="key",
        name="name",
        description="",
        tags=[
            "tags",
            "tags",
        ],
    )

    try:
        response = api.AIConfigsBetaApi(api_client).post_ai_config(
            ld_api_version=None,
            project_key=None,
            ai_config_post=ai_config_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBeta#post_ai_config: %s\n" % e)
