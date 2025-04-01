import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

new api.FeatureFlagsApi(configuration).deleteFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#deleteFeatureFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
