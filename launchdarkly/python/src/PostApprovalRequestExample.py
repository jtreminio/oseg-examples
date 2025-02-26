import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    create_approval_request_request = models.CreateApprovalRequestRequest(
        resourceId="proj/projKey:env/envKey:flag/flagKey",
        description="Requesting to update targeting",
        instructions=json.loads("""
            []
        """),
        comment="optional comment",
        notifyMemberIds=[
            "1234a56b7c89d012345e678f",
        ],
        notifyTeamKeys=[
            "example-reviewer-team",
        ],
        integrationConfig=None,
    )

    try:
        response = api.ApprovalsApi(api_client).post_approval_request(
            create_approval_request_request=create_approval_request_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ApprovalsApi#post_approval_request: %s\n" % e)
