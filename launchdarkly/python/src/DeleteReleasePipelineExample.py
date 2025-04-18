import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    try:
        api.ReleasePipelinesBetaApi(api_client).delete_release_pipeline(
            project_key="projectKey_string",
            pipeline_key="pipelineKey_string",
        )
    except ApiException as e:
        print("Exception when calling ReleasePipelinesBetaApi#delete_release_pipeline: %s\n" % e)
