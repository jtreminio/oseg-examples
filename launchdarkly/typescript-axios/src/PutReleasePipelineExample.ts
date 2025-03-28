import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const phases1Audiences1ConfigurationReleaseGuardianConfiguration: api.ReleaseGuardianConfiguration = {
  monitoringWindowMilliseconds: 60000,
  rolloutWeight: 50,
  rollbackOnRegression: true,
  randomizationUnit: "user",
};

const phases1Audiences1Configuration: api.AudienceConfiguration = {
  releaseStrategy: "releaseStrategy_string",
  requireApproval: true,
  notifyMemberIds: [
    "1234a56b7c89d012345e678f",
  ],
  notifyTeamKeys: [
    "example-reviewer-team",
  ],
  releaseGuardianConfiguration: phases1Audiences1ConfigurationReleaseGuardianConfiguration,
};

const phases1Audiences1: api.AudiencePost = {
  environmentKey: "environmentKey_string",
  name: "name_string",
  segmentKeys: [
  ],
  configuration: phases1Audiences1Configuration,
};

const phases1Audiences = [
  phases1Audiences1,
];

const phases1: api.CreatePhaseInput = {
  name: "Phase 1 - Testing",
  audiences: phases1Audiences,
};

const phases = [
  phases1,
];

const updateReleasePipelineInput: api.UpdateReleasePipelineInput = {
  name: "Standard Pipeline",
  description: "Standard pipeline to roll out to production",
  tags: [
    "example-tag",
  ],
  phases: phases,
};

new api.ReleasePipelinesBetaApi(configuration).putReleasePipeline(
  "projectKey_string", // projectKey
  "pipelineKey_string", // pipelineKey
  updateReleasePipelineInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasePipelinesBetaApi#putReleasePipeline:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
