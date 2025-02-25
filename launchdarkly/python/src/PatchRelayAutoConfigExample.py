import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_1 = models.PatchOperation(
        op="replace",
        path="/policy/0",
    )

    patch = [
        patch_1,
    ]

    patch_with_comment = models.PatchWithComment(
        patch=patch,
    )

    try:
        response = api.RelayProxyConfigurationsApi(api_client).patch_relay_auto_config(
            id=None,
            patch_with_comment=patch_with_comment,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling RelayProxyConfigurations#patch_relay_auto_config: %s\n" % e)
