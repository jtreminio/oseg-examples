import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    instructions_1 = models.PatchSegmentExpiringTargetInstruction(
        kind="updateExpiringTarget",
        contextKey="user@email.com",
        contextKind="user",
        targetType="included",
        value=1587582000000,
        version=0,
    )

    instructions = [
        instructions_1,
    ]

    patch_segment_expiring_target_input_rep = models.PatchSegmentExpiringTargetInputRep(
        comment="optional comment",
        instructions=instructions,
    )

    try:
        response = api.SegmentsApi(api_client).patch_expiring_targets_for_segment(
            project_key=None,
            environment_key=None,
            segment_key=None,
            patch_segment_expiring_target_input_rep=patch_segment_expiring_target_input_rep,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling SegmentsApi#patch_expiring_targets_for_segment: %s\n" % e)
