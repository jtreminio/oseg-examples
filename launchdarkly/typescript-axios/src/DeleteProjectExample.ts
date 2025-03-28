import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ProjectsApi(configuration).deleteProject(
  "projectKey_string", // projectKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#deleteProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
