import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    policy_1 = models.StatementPost(
        effect="allow",
        resources=[
            "proj/*:env/production:flag/*",
        ],
        actions=[
            "updateOn",
        ],
    )

    policy = [
        policy_1,
    ]

    custom_role_post = models.CustomRolePost(
        name="Ops team",
        key="role-key-123abc",
        description="An example role for members of the ops team",
        basePermissions="reader",
        policy=policy,
    )

    try:
        response = api.CustomRolesApi(api_client).post_custom_role(
            custom_role_post=custom_role_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling CustomRoles#post_custom_role: %s\n" % e)
