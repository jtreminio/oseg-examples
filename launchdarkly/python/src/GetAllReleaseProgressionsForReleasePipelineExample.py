import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        response = api.ReleasePipelinesBetaApi(api_client).get_all_release_progressions_for_release_pipeline(
            project_key=None,
            pipeline_key=None,
            filter=None,
            limit=None,
            offset=None,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasePipelinesBetaApi#get_all_release_progressions_for_release_pipeline: %s\n" % e)
