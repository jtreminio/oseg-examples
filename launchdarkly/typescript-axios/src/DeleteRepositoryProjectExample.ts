import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.InsightsRepositoriesBetaApi(configuration).deleteRepositoryProject(
  "repositoryKey_string", // repositoryKey
  "projectKey_string", // projectKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling InsightsRepositoriesBetaApi#deleteRepositoryProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
