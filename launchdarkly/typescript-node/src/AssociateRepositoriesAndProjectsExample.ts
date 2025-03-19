import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsRepositoriesBetaApi();
apiCaller.setApiKey(api.InsightsRepositoriesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const mappings1: models.InsightsRepositoryProject = {
  repositoryKey: "launchdarkly/LaunchDarkly-Docs",
  projectKey: "default",
};

const mappings = [
  mappings1,
];

const insightsRepositoryProjectMappings: models.InsightsRepositoryProjectMappings = {
  mappings: mappings,
};

apiCaller.associateRepositoriesAndProjects(
  insightsRepositoryProjectMappings,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsRepositoriesBetaApi#associateRepositoriesAndProjects:");
  console.log(error.body);
});
