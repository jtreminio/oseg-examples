import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ReleasePipelinesBetaApi(configuration).getAllReleasePipelines(
  "projectKey_string", // projectKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasePipelinesBetaApi#getAllReleasePipelines:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
