import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    phases_1_audiences_1_configuration_release_guardian_configuration = models.ReleaseGuardianConfiguration(
        monitoringWindowMilliseconds=60000,
        rolloutWeight=50,
        rollbackOnRegression=True,
        randomizationUnit="user",
    )

    phases_1_audiences_1_configuration = models.AudienceConfiguration(
        releaseStrategy=None,
        requireApproval=True,
        notifyMemberIds=[
            "1234a56b7c89d012345e678f",
        ],
        notifyTeamKeys=[
            "example-reviewer-team",
        ],
        releaseGuardianConfiguration=phases_1_audiences_1_configuration_release_guardian_configuration,
    )

    phases_1_audiences_1 = models.AudiencePost(
        environmentKey=None,
        name=None,
        segmentKeys=[
        ],
        configuration=phases_1_audiences_1_configuration,
    )

    phases_1_audiences = [
        phases_1_audiences_1,
    ]

    phases_1 = models.CreatePhaseInput(
        name="Phase 1 - Testing",
        audiences=phases_1_audiences,
    )

    phases = [
        phases_1,
    ]

    update_release_pipeline_input = models.UpdateReleasePipelineInput(
        name="Standard Pipeline",
        description="Standard pipeline to roll out to production",
        tags=[
            "example-tag",
        ],
        phases=phases,
    )

    try:
        response = api.ReleasePipelinesBetaApi(api_client).put_release_pipeline(
            project_key=None,
            pipeline_key=None,
            update_release_pipeline_input=update_release_pipeline_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasePipelinesBetaApi#put_release_pipeline: %s\n" % e)
