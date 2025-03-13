import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    statements_1 = models.StatementPost(
        effect="allow",
        resources=[
            "proj/*:env/*:flag/*;testing-tag",
        ],
        actions=[
            "*",
        ],
    )

    statements = [
        statements_1,
    ]

    subscription_post = models.SubscriptionPost(
        name="Example audit log subscription.",
        config=json.loads("""
            {
                "optional": "an optional property",
                "required": "the required property",
                "url": "https://example.com"
            }
        """),
        on=False,
        tags=[
            "testing-tag",
        ],
        statements=statements,
    )

    try:
        response = api.IntegrationAuditLogSubscriptionsApi(api_client).create_subscription(
            integration_key="integrationKey_string",
            subscription_post=subscription_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling IntegrationAuditLogSubscriptionsApi#create_subscription: %s\n" % e)
