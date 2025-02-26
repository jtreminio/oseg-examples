import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    policy_1 = models.Statement(
        effect="allow",
        resources=[
            "proj/*:env/*",
        ],
        actions=[
            "*",
        ],
    )

    policy = [
        policy_1,
    ]

    relay_auto_config_post = models.RelayAutoConfigPost(
        name="Sample Relay Proxy config for all proj and env",
        policy=policy,
    )

    try:
        response = api.RelayProxyConfigurationsApi(api_client).post_relay_auto_config(
            relay_auto_config_post=relay_auto_config_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling RelayProxyConfigurationsApi#post_relay_auto_config: %s\n" % e)
