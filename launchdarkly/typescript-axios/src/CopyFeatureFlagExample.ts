import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const source: api.FlagCopyConfigEnvironment = {
  key: "source-env-key-123abc",
  currentVersion: 1,
};

const target: api.FlagCopyConfigEnvironment = {
  key: "target-env-key-123abc",
  currentVersion: 1,
};

const flagCopyConfigPost: api.FlagCopyConfigPost = {
  comment: "optional comment",
  source: source,
  target: target,
};

new api.FeatureFlagsApi(configuration).copyFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  flagCopyConfigPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling FeatureFlagsApi#copyFeatureFlag:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
