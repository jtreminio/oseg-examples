import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    model_config_post = models.ModelConfigPost(
        id="id",
        key="key",
        name="name",
        icon="icon",
        provider="provider",
        tags=[
            "tags",
            "tags",
        ],
        params={},
        customParams={},
    )

    try:
        response = api.AIConfigsBetaApi(api_client).post_model_config(
            ld_api_version="beta",
            project_key="default",
            model_config_post=model_config_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#post_model_config: %s\n" % e)
