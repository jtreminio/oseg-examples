import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.ReleasesBetaApi(configuration).deleteReleaseByFlagKey(
  "projectKey_string", // projectKey
  "flagKey_string", // flagKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ReleasesBetaApi#deleteReleaseByFlagKey:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
