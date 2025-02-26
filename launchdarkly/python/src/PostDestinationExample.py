import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    destination_post = models.DestinationPost(
        kind="google-pubsub",
    )

    try:
        response = api.DataExportDestinationsApi(api_client).post_destination(
            project_key=None,
            environment_key=None,
            destination_post=destination_post,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling DataExportDestinationsApi#post_destination: %s\n" % e)
