import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ReleasePipelinesBetaApi(configuration).getAllReleaseProgressionsForReleasePipeline(
  "projectKey_string", // projectKey
  "pipelineKey_string", // pipelineKey
  undefined, // filter
  undefined, // limit
  undefined, // offset
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasePipelinesBetaApi#getAllReleaseProgressionsForReleasePipeline:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
