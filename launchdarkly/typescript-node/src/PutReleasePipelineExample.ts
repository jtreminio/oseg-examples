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

const phases1Audiences1: models.AudiencePost = {
  environmentKey: "environmentKey_string",
  name: "name_string",
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

const updateReleasePipelineInput: models.UpdateReleasePipelineInput = {
  name: "Standard Pipeline",
  description: "Standard pipeline to roll out to production",
  tags: [
    "example-tag",
  ],
  phases: phases,
};

apiCaller.putReleasePipeline(
  "projectKey_string", // projectKey
  "pipelineKey_string", // pipelineKey
  updateReleasePipelineInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#putReleasePipeline:");
  console.log(error.body);
});
