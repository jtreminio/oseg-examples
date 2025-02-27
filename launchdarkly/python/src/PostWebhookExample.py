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
            "proj/test",
        ],
        actions=[
            "*",
        ],
    )

    statements = [
        statements_1,
    ]

    webhook_post = models.WebhookPost(
        url="https://example.com",
        sign=False,
        on=True,
        name="apidocs test webhook",
        tags=[
            "example-tag",
        ],
        statements=statements,
    )

    try:
        response = api.WebhooksApi(api_client).post_webhook(
            webhook_post=webhook_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling WebhooksApi#post_webhook: %s\n" % e)
