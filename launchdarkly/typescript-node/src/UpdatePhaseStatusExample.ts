import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const audiences1ReleaseGuardianConfiguration = new models.ReleaseGuardianConfigurationInput();
audiences1ReleaseGuardianConfiguration.monitoringWindowMilliseconds = 60000;
audiences1ReleaseGuardianConfiguration.rolloutWeight = 50;
audiences1ReleaseGuardianConfiguration.rollbackOnRegression = true;
audiences1ReleaseGuardianConfiguration.randomizationUnit = "user";

const audiences1 = new models.ReleaserAudienceConfigInput();
audiences1.audienceId = undefined;
audiences1.notifyMemberIds = [
  "1234a56b7c89d012345e678f",
];
audiences1.notifyTeamKeys = [
  "example-reviewer-team",
];
audiences1.releaseGuardianConfiguration = audiences1ReleaseGuardianConfiguration;

const audiences = [
  audiences1,
];

const updatePhaseStatusInput = new models.UpdatePhaseStatusInput();
updatePhaseStatusInput.status = undefined;
updatePhaseStatusInput.audiences = audiences;

apiCaller.updatePhaseStatus(
  undefined, // projectKey
  undefined, // flagKey
  undefined, // phaseId
  updatePhaseStatusInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBeta#updatePhaseStatus:");
  console.log(error.body);
});
