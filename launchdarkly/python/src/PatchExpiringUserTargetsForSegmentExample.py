import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    instructions_1 = models.PatchSegmentInstruction(
        kind="addExpireUserTargetDate",
        userKey="sample-user-key",
        targetType="included",
        value=16534692,
        version=0,
    )

    instructions = [
        instructions_1,
    ]

    patch_segment_request = models.PatchSegmentRequest(
        comment="optional comment",
        instructions=instructions,
    )

    try:
        response = api.SegmentsApi(api_client).patch_expiring_user_targets_for_segment(
            project_key="the-project-key",
            environment_key="the-environment-key",
            segment_key="the-segment-key",
            patch_segment_request=patch_segment_request,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Segments#patch_expiring_user_targets_for_segment: %s\n" % e)
