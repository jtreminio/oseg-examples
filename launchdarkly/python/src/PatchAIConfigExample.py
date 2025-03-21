import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    ai_config_patch = models.AIConfigPatch(
        description="description",
        name="name",
        tags=[
            "tags",
            "tags",
        ],
    )

    try:
        response = api.AIConfigsBetaApi(api_client).patch_ai_config(
            ld_api_version="beta",
            project_key="projectKey_string",
            config_key="configKey_string",
            ai_config_patch=ai_config_patch,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#patch_ai_config: %s\n" % e)
