import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const audiences1ReleaseGuardianConfiguration: api.ReleaseGuardianConfigurationInput = {
  monitoringWindowMilliseconds: 60000,
  rolloutWeight: 50,
  rollbackOnRegression: true,
  randomizationUnit: "user",
};

const audiences1: api.ReleaserAudienceConfigInput = {
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

const updatePhaseStatusInput: api.UpdatePhaseStatusInput = {
  audiences: audiences,
};

new api.ReleasesBetaApi(configuration).updatePhaseStatus(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  "phaseId_string", // phaseId
  updatePhaseStatusInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasesBetaApi#updatePhaseStatus:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
