import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    patch_1 = models.PatchOperation(
        op="replace",
        path="/description",
    )

    patch_2 = models.PatchOperation(
        op="add",
        path="/tags/0",
    )

    patch = [
        patch_1,
        patch_2,
    ]

    patch_with_comment = models.PatchWithComment(
        patch=patch,
    )

    try:
        response = api.SegmentsApi(api_client).patch_segment(
            project_key=None,
            environment_key=None,
            segment_key=None,
            patch_with_comment=patch_with_comment,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Segments#patch_segment: %s\n" % e)
