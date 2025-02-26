import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    create_release_input = models.CreateReleaseInput(
        releasePipelineKey=None,
        releaseVariationId=None,
    )

    try:
        response = api.ReleasesBetaApi(api_client).create_release_for_flag(
            project_key=None,
            flag_key=None,
            create_release_input=create_release_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasesBetaApi#create_release_for_flag: %s\n" % e)
