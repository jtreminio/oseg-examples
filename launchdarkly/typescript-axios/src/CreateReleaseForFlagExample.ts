import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const createReleaseInput: api.CreateReleaseInput = {
  releasePipelineKey: "releasePipelineKey_string",
};

new api.ReleasesBetaApi(configuration).createReleaseForFlag(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
  createReleaseInput,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasesBetaApi#createReleaseForFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
