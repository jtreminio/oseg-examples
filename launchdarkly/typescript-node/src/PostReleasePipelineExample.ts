import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const phases1Audiences1ConfigurationReleaseGuardianConfiguration: models.ReleaseGuardianConfiguration = {
  monitoringWindowMilliseconds: 60000,
  rolloutWeight: 50,
  rollbackOnRegression: true,
  randomizationUnit: "user",
};

const phases1Audiences1Configuration: models.AudienceConfiguration = {
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

const phases1Audiences1: models.AudiencePost = {
  environmentKey: "the-environment-key",
  name: "Some name",
  segmentKeys: [
  ],
  configuration: phases1Audiences1Configuration,
};

const phases1Audiences = [
  phases1Audiences1,
];

const phases1: models.CreatePhaseInput = {
  name: "Phase 1 - Testing",
  audiences: phases1Audiences,
};

const phases = [
  phases1,
];

const createReleasePipelineInput: models.CreateReleasePipelineInput = {
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

apiCaller.postReleasePipeline(
  "the-project-key", // projectKey
  createReleasePipelineInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#postReleasePipeline:");
  console.log(error.body);
});
