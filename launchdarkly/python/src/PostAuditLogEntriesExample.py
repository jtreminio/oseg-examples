import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    statement_post_1 = models.StatementPost(
        effect="allow",
        resources=[
            "proj/*:env/*:flag/*;testing-tag",
        ],
        notResources=[
        ],
        actions=[
            "*",
        ],
        notActions=[
        ],
    )

    statement_post = [
        statement_post_1,
    ]

    try:
        response = api.AuditLogApi(api_client).post_audit_log_entries(
            before=None,
            after=None,
            q=None,
            limit=None,
            statement_post=statement_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling AuditLogApi#post_audit_log_entries: %s\n" % e)
