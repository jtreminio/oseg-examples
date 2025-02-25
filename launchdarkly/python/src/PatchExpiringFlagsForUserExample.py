import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    instructions_1 = models.InstructionUserRequest(
        kind="addExpireUserTargetDate",
        flagKey="sample-flag-key",
        variationId="ce12d345-a1b2-4fb5-a123-ab123d4d5f5d",
        value=16534692,
        version=1,
    )

    instructions = [
        instructions_1,
    ]

    patch_users_request = models.PatchUsersRequest(
        comment="optional comment",
        instructions=instructions,
    )

    try:
        response = api.UserSettingsApi(api_client).patch_expiring_flags_for_user(
            project_key="the-project-key",
            user_key="the-user-key",
            environment_key="the-environment-key",
            patch_users_request=patch_users_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling UserSettings#patch_expiring_flags_for_user: %s\n" % e)
