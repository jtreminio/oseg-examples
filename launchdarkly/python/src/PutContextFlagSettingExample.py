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
            project_key=None,
            environment_key=None,
            context_kind=None,
            context_key=None,
            feature_flag_key=None,
            value_put=value_put,
        )
    except ApiException as e:
        print("Exception when calling ContextSettings#put_context_flag_setting: %s\n" % e)
