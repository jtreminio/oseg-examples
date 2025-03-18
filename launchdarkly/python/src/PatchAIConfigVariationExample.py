import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    messages_1 = models.Message(
        content="content",
        role="role",
    )

    messages_2 = models.Message(
        content="content",
        role="role",
    )

    messages = [
        messages_1,
        messages_2,
    ]

    ai_config_variation_patch = models.AIConfigVariationPatch(
        modelConfigKey="modelConfigKey",
        name="name",
        published=True,
        model={},
        messages=messages,
    )

    try:
        response = api.AIConfigsBetaApi(api_client).patch_ai_config_variation(
            ld_api_version="beta",
            project_key="projectKey_string",
            config_key="configKey_string",
            variation_key="variationKey_string",
            ai_config_variation_patch=ai_config_variation_patch,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AIConfigsBetaApi#patch_ai_config_variation: %s\n" % e)
