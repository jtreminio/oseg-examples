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
        releaseStrategy="the-release-strategy",
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
        environmentKey="the-environment-key",
        name="Some name",
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

    create_release_pipeline_input = models.CreateReleasePipelineInput(
        key="standard-pipeline",
        name="Standard Pipeline",
        description="Standard pipeline to roll out to production",
        isProjectDefault=False,
        isLegacy=False,
        tags=[
            "example-tag",
        ],
        phases=phases,
    )

    try:
        response = api.ReleasePipelinesBetaApi(api_client).post_release_pipeline(
            project_key="the-project-key",
            create_release_pipeline_input=create_release_pipeline_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasePipelinesBetaApi#post_release_pipeline: %s\n" % e)
