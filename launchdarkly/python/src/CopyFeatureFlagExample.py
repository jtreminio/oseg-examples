import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    source = models.FlagCopyConfigEnvironment(
        key="source-env-key-123abc",
        currentVersion=1,
    )

    target = models.FlagCopyConfigEnvironment(
        key="target-env-key-123abc",
        currentVersion=1,
    )

    flag_copy_config_post = models.FlagCopyConfigPost(
        comment="optional comment",
        source=source,
        target=target,
    )

    try:
        response = api.FeatureFlagsApi(api_client).copy_feature_flag(
            project_key=None,
            feature_flag_key=None,
            flag_copy_config_post=flag_copy_config_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling FeatureFlagsApi#copy_feature_flag: %s\n" % e)
