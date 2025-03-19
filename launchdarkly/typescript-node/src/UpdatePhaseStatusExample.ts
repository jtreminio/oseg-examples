import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasesBetaApi();
apiCaller.setApiKey(api.ReleasesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const audiences1ReleaseGuardianConfiguration: models.ReleaseGuardianConfigurationInput = {
  monitoringWindowMilliseconds: 60000,
  rolloutWeight: 50,
  rollbackOnRegression: true,
  randomizationUnit: "user",
};

const audiences1: models.ReleaserAudienceConfigInput = {
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
  releaseGuardianConfiguration: audiences1ReleaseGuardianConfiguration,
};

const audiences = [
  audiences1,
];

const updatePhaseStatusInput: models.UpdatePhaseStatusInput = {
  audiences: audiences,
};

apiCaller.updatePhaseStatus(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  "phaseId_string", // phaseId
  updatePhaseStatusInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasesBetaApi#updatePhaseStatus:");
  console.log(error.body);
});
