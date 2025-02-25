import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.InsightsRepositoriesBetaApi();
apiCaller.setApiKey(api.InsightsRepositoriesBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const mappings1 = new models.InsightsRepositoryProject();
mappings1.repositoryKey = "launchdarkly/LaunchDarkly-Docs";
mappings1.projectKey = "default";

const mappings = [
  mappings1,
];

const insightsRepositoryProjectMappings = new models.InsightsRepositoryProjectMappings();
insightsRepositoryProjectMappings.mappings = mappings;

apiCaller.associateRepositoriesAndProjects(
  insightsRepositoryProjectMappings,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling InsightsRepositoriesBeta#associateRepositoriesAndProjects:");
  console.log(error.body);
});
