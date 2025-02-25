import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    upsert_context_kind_payload = models.UpsertContextKindPayload(
        name="organization",
        description="An example context kind for organizations",
        hideInTargeting=False,
        archived=False,
        version=1,
    )

    try:
        response = api.ContextsApi(api_client).put_context_kind(
            project_key=None,
            key=None,
            upsert_context_kind_payload=upsert_context_kind_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling Contexts#put_context_kind: %s\n" % e)
