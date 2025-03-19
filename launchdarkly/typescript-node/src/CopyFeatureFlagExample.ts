import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const source: models.FlagCopyConfigEnvironment = {
  key: "source-env-key-123abc",
  currentVersion: 1,
};

const target: models.FlagCopyConfigEnvironment = {
  key: "target-env-key-123abc",
  currentVersion: 1,
};

const flagCopyConfigPost: models.FlagCopyConfigPost = {
  comment: "optional comment",
  source: source,
  target: target,
};

apiCaller.copyFeatureFlag(
  "projectKey_string", // projectKey
  "featureFlagKey_string", // featureFlagKey
  flagCopyConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlagsApi#copyFeatureFlag:");
  console.log(error.body);
});
