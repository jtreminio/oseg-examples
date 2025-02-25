import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.FeatureFlagsApi();
apiCaller.setApiKey(api.FeatureFlagsApiApiKeys.ApiKey, "YOUR_API_KEY");

const patch1 = new models.PatchOperation();
patch1.op = "replace";
patch1.path = "/description";

const patch = [
  patch1,
];

const patchWithComment = new models.PatchWithComment();
patchWithComment.patch = patch;

apiCaller.patchFeatureFlag(
  undefined, // projectKey
  undefined, // featureFlagKey
  patchWithComment,
  undefined, // ignoreConflicts
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling FeatureFlags#patchFeatureFlag:");
  console.log(error.body);
});
