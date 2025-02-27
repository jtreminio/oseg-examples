import json
from datetime import date, datetime
from pprint import pprint

from launchdarkly_client import ApiClient, ApiException, Configuration, api, models

configuration = Configuration(
    api_key={"ApiKey": "YOUR_API_KEY"},
)

with ApiClient(configuration) as api_client:
    audiences_1_release_guardian_configuration = models.ReleaseGuardianConfigurationInput(
        monitoringWindowMilliseconds=60000,
        rolloutWeight=50,
        rollbackOnRegression=True,
        randomizationUnit="user",
    )

    audiences_1 = models.ReleaserAudienceConfigInput(
        audienceId=None,
        notifyMemberIds=[
            "1234a56b7c89d012345e678f",
        ],
        notifyTeamKeys=[
            "example-reviewer-team",
        ],
        releaseGuardianConfiguration=audiences_1_release_guardian_configuration,
    )

    audiences = [
        audiences_1,
    ]

    update_phase_status_input = models.UpdatePhaseStatusInput(
        status=None,
        audiences=audiences,
    )

    try:
        response = api.ReleasesBetaApi(api_client).update_phase_status(
            project_key=None,
            flag_key=None,
            phase_id=None,
            update_phase_status_input=update_phase_status_input,
        )

        pprint(response)
    except ApiException as e:
        print("Exception when calling ReleasesBetaApi#update_phase_status: %s\n" % e)
