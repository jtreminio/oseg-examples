import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ReleasePipelinesBetaApi();
apiCaller.setApiKey(api.ReleasePipelinesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const phases1Audiences1ConfigurationReleaseGuardianConfiguration = new models.ReleaseGuardianConfiguration();
phases1Audiences1ConfigurationReleaseGuardianConfiguration.monitoringWindowMilliseconds = 60000;
phases1Audiences1ConfigurationReleaseGuardianConfiguration.rolloutWeight = 50;
phases1Audiences1ConfigurationReleaseGuardianConfiguration.rollbackOnRegression = true;
phases1Audiences1ConfigurationReleaseGuardianConfiguration.randomizationUnit = "user";

const phases1Audiences1Configuration = new models.AudienceConfiguration();
phases1Audiences1Configuration.releaseStrategy = undefined;
phases1Audiences1Configuration.requireApproval = true;
phases1Audiences1Configuration.notifyMemberIds = [
  "1234a56b7c89d012345e678f",
];
phases1Audiences1Configuration.notifyTeamKeys = [
  "example-reviewer-team",
];
phases1Audiences1Configuration.releaseGuardianConfiguration = phases1Audiences1ConfigurationReleaseGuardianConfiguration;

const phases1Audiences1 = new models.AudiencePost();
phases1Audiences1.environmentKey = undefined;
phases1Audiences1.name = undefined;
phases1Audiences1.segmentKeys = [
];
phases1Audiences1.configuration = phases1Audiences1Configuration;

const phases1Audiences = [
  phases1Audiences1,
];

const phases1 = new models.CreatePhaseInput();
phases1.name = "Phase 1 - Testing";
phases1.audiences = phases1Audiences;

const phases = [
  phases1,
];

const updateReleasePipelineInput = new models.UpdateReleasePipelineInput();
updateReleasePipelineInput.name = "Standard Pipeline";
updateReleasePipelineInput.description = "Standard pipeline to roll out to production";
updateReleasePipelineInput.tags = [
  "example-tag",
];
updateReleasePipelineInput.phases = phases;

apiCaller.putReleasePipeline(
  undefined, // projectKey
  undefined, // pipelineKey
  updateReleasePipelineInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBetaApi#putReleasePipeline:");
  console.log(error.body);
});
