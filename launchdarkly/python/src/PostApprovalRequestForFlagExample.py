import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    create_flag_config_approval_request_request = models.CreateFlagConfigApprovalRequestRequest(
        description="Requesting to update targeting",
        instructions=[],
        comment="optional comment",
        executionDate=1706701522000,
        operatingOnId="6297ed79dee7dc14e1f9a80c",
        notifyMemberIds=[
            "1234a56b7c89d012345e678f",
        ],
        notifyTeamKeys=[
            "example-reviewer-team",
        ],
        integrationConfig=None,
    )

    try:
        response = api.ApprovalsApi(api_client).post_approval_request_for_flag(
            project_key=None,
            feature_flag_key=None,
            environment_key=None,
            create_flag_config_approval_request_request=create_flag_config_approval_request_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApprovalsApi#post_approval_request_for_flag: %s\n" % e)
