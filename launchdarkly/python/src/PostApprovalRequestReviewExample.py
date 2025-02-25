import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    post_approval_request_review_request = models.PostApprovalRequestReviewRequest(
        kind="approve",
        comment="Looks good, thanks for updating",
    )

    try:
        response = api.ApprovalsApi(api_client).post_approval_request_review(
            id=None,
            post_approval_request_review_request=post_approval_request_review_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Approvals#post_approval_request_review: %s\n" % e)
