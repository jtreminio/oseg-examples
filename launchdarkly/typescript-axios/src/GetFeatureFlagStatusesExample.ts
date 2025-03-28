import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FeatureFlagsApi(configuration).getFeatureFlagStatuses(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#getFeatureFlagStatuses:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
