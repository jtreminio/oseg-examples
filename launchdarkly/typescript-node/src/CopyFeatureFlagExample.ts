import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const source = new models.FlagCopyConfigEnvironment();
source.key = "source-env-key-123abc";
source.currentVersion = 1;

const target = new models.FlagCopyConfigEnvironment();
target.key = "target-env-key-123abc";
target.currentVersion = 1;

const flagCopyConfigPost = new models.FlagCopyConfigPost();
flagCopyConfigPost.comment = "optional comment";
flagCopyConfigPost.source = source;
flagCopyConfigPost.target = target;

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
