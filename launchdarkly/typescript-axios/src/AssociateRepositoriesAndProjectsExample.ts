import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const mappings1: api.InsightsRepositoryProject = {
  repositoryKey: "launchdarkly/LaunchDarkly-Docs",
  projectKey: "default",
};

const mappings = [
  mappings1,
];

const insightsRepositoryProjectMappings: api.InsightsRepositoryProjectMappings = {
  mappings: mappings,
};

new api.InsightsRepositoriesBetaApi(configuration).associateRepositoriesAndProjects(
  insightsRepositoryProjectMappings,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsRepositoriesBetaApi#associateRepositoriesAndProjects:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
