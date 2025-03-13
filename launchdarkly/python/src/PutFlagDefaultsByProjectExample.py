import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    boolean_defaults = models.BooleanFlagDefaults(
        trueDisplayName="True",
        falseDisplayName="False",
        trueDescription="serve true",
        falseDescription="serve false",
        onVariation=0,
        offVariation=1,
    )

    default_client_side_availability = models.DefaultClientSideAvailability(
        usingMobileKey=True,
        usingEnvironmentId=True,
    )

    upsert_flag_defaults_payload = models.UpsertFlagDefaultsPayload(
        temporary=True,
        tags=[
            "tag-1",
            "tag-2",
        ],
        booleanDefaults=boolean_defaults,
        defaultClientSideAvailability=default_client_side_availability,
    )

    try:
        response = api.ProjectsApi(api_client).put_flag_defaults_by_project(
            project_key="projectKey_string",
            upsert_flag_defaults_payload=upsert_flag_defaults_payload,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ProjectsApi#put_flag_defaults_by_project: %s\n" % e)
