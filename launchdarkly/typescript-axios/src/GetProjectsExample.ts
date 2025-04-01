import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ProjectsApi(configuration).getProjects().then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#getProjects:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
