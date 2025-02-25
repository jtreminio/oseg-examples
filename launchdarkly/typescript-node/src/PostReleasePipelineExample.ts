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
phases1Audiences1Configuration.releaseStrategy = "the-release-strategy";
phases1Audiences1Configuration.requireApproval = true;
phases1Audiences1Configuration.notifyMemberIds = [
  "1234a56b7c89d012345e678f",
];
phases1Audiences1Configuration.notifyTeamKeys = [
  "example-reviewer-team",
];
phases1Audiences1Configuration.releaseGuardianConfiguration = phases1Audiences1ConfigurationReleaseGuardianConfiguration;

const phases1Audiences1 = new models.AudiencePost();
phases1Audiences1.environmentKey = "the-environment-key";
phases1Audiences1.name = "Some name";
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

const createReleasePipelineInput = new models.CreateReleasePipelineInput();
createReleasePipelineInput.key = "standard-pipeline";
createReleasePipelineInput.name = "Standard Pipeline";
createReleasePipelineInput.description = "Standard pipeline to roll out to production";
createReleasePipelineInput.isProjectDefault = false;
createReleasePipelineInput.isLegacy = false;
createReleasePipelineInput.tags = [
  "example-tag",
];
createReleasePipelineInput.phases = phases;

apiCaller.postReleasePipeline(
  "the-project-key", // projectKey
  createReleasePipelineInput,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReleasePipelinesBeta#postReleasePipeline:");
  console.log(error.body);
});
