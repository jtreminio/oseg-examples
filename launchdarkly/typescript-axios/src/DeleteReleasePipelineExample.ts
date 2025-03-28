import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ReleasePipelinesBetaApi(configuration).deleteReleasePipeline(
  "projectKey_string", // projectKey
  "pipelineKey_string", // pipelineKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasePipelinesBetaApi#deleteReleasePipeline:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
