import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ExperimentsApi(configuration).getExperimentationSettings(
  "projectKey_string", // projectKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#getExperimentationSettings:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
