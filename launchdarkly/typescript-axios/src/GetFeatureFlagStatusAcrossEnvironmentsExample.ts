import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FeatureFlagsApi(configuration).getFeatureFlagStatusAcrossEnvironments(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  undefined, // env
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#getFeatureFlagStatusAcrossEnvironments:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
