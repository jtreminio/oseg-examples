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
  releaseStrategy: "the-release-strategy",
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
  environmentKey: "the-environment-key",
  name: "Some name",
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

const createReleasePipelineInput: api.CreateReleasePipelineInput = {
  key: "standard-pipeline",
  name: "Standard Pipeline",
  description: "Standard pipeline to roll out to production",
  isProjectDefault: false,
  isLegacy: false,
  tags: [
    "example-tag",
  ],
  phases: phases,
};

new api.ReleasePipelinesBetaApi(configuration).postReleasePipeline(
  "the-project-key", // projectKey
  createReleasePipelineInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasePipelinesBetaApi#postReleasePipeline:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
