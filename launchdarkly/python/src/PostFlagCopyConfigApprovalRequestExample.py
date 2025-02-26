import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    source = models.SourceFlag(
        key="environment-key-123abc",
        version=1,
    )

    create_copy_flag_config_approval_request_request = models.CreateCopyFlagConfigApprovalRequestRequest(
        description="copy flag settings to another environment",
        comment="optional comment",
        notifyMemberIds=[
            "1234a56b7c89d012345e678f",
        ],
        notifyTeamKeys=[
            "example-reviewer-team",
        ],
        includedActions=[
            "updateOn",
        ],
        excludedActions=[
            "updateOn",
        ],
        source=source,
    )

    try:
        response = api.ApprovalsApi(api_client).post_flag_copy_config_approval_request(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            create_copy_flag_config_approval_request_request=create_copy_flag_config_approval_request_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApprovalsApi#post_flag_copy_config_approval_request: %s\n" % e)
