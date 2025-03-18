import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    value_put = models.ValuePut(
        comment="make sure this context experiences a specific variation",
    )

    try:
        api.ContextSettingsApi(api_client).put_context_flag_setting(
            project_key="projectKey_string",
            environment_key="environmentKey_string",
            context_kind="contextKind_string",
            context_key="contextKey_string",
            feature_flag_key="featureFlagKey_string",
            value_put=value_put,
        )
    except ApiException as e:
        print("Exception when calling ContextSettingsApi#put_context_flag_setting: %s\n" % e)
