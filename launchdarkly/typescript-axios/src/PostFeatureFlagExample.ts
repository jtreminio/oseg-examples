import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const clientSideAvailability: api.ClientSideAvailabilityPost = {
  usingEnvironmentId: true,
  usingMobileKey: true,
};

const featureFlagBody: api.FeatureFlagBody = {
  name: "My Flag",
  key: "flag-key-123abc",
  clientSideAvailability: clientSideAvailability,
};

new api.FeatureFlagsApi(configuration).postFeatureFlag(
  "projectKey_string", // projectKey
  featureFlagBody,
  undefined, // clone
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#postFeatureFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
